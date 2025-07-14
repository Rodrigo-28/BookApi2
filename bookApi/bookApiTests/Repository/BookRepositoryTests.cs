using bookApi.Domian.Common;
using bookApi.Domian.Models;
using bookApi.infrastructure.Repositories;
using bookApi.infrastructure.Utils;
using bookApiTests.Repository.Helpers;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;

namespace bookApiTests.Repository
{
    public class BookRepositoryTests
    {
        [Fact]
        public async Task Create_ShouldAddBookWithGenres()
        {
            // Arrange
            var context = await TestDbContextFactory.CreateEmptyContextAsync();
            var repository = new BookRepository(context);
            var genre1 = new Genre { Id = 1, Name = "Fantasy" };
            var genre2 = new Genre { Id = 2, Name = "Sci-Fi" };
            context.Genres.AddRange(genre1, genre2);
            await context.SaveChangesAsync();

            var book = new Book
            {
                Title = "The Test Book",
                Author = "Rodrigo Dev",
                PublishYear = 2024,
                Description = "Testing in depth",
                PageCount = 300
            };
            var genreIds = new List<int> { 1, 2 };

            // Act
            var createdBook = await repository.Create(book, genreIds);

            // Assert
            var bookInDb = await context.Books
                .Include(b => b.BookGenres)
                .ThenInclude(bg => bg.Genre)
                .FirstOrDefaultAsync(b => b.Id == createdBook.Id);

            bookInDb.Should().NotBeNull();
            bookInDb!.BookGenres.Should().HaveCount(2);
            bookInDb.BookGenres.Select(bg => bg.GenreId).Should().Contain(new[] { 1, 2 });
            bookInDb.Title.Should().Be("The Test Book");
        }
        [Fact]
        public async Task GetOne_ShouldReturnBookResponse_WithUserBook_WhenUserIdIsProvided()
        {
            // Arrange
            var context = await TestDbContextFactory.CreateWithBookAndUserBookAsync("GetOne_WithUser");
            var repository = new BookRepository(context);

            // Act
            var result = await repository.GetOne(1, 1);

            // Assert
            result.Should().NotBeNull();
            result!.Book.Should().NotBeNull();
            result.Book.Id.Should().Be(1);
            result.UserBook.Should().NotBeNull();
            result.UserBook!.UserId.Should().Be(1);
            result.UserBook.BookId.Should().Be(1);
        }
        [Fact]
        public async Task Update_ShouldModifyBookTitle()
        {
            // Arrange
            var context = await TestDbContextFactory.CreateWithBookAndUserBookAsync("Update_Book");
            var repository = new BookRepository(context);
            var originalBook = await context.Books.FirstAsync(b => b.Id == 1);
            originalBook.Title = "1984 - Updated Title";

            // Act
            var updatedBook = await repository.Update(originalBook);

            // Assert
            updatedBook.Should().NotBeNull();
            updatedBook.Id.Should().Be(1);
            updatedBook.Title.Should().Be("1984 - Updated Title");
            var bookInDb = await context.Books.FindAsync(1);
            bookInDb!.Title.Should().Be("1984 - Updated Title");
        }

        [Fact]
        public async Task GetList_ShouldReturnPaginatedBooksWithoutFilters()
        {
            // Arrange
            var context = await TestDbContextFactory.CreateWithBasicBooksAsync("GetList_NoFilters");
            var repository = new BookRepository(context);
            // Act
            var result = await repository.GetList(userId: null, page: 1, pageSize: 10);
            // Assert
            result.Should().NotBeNull();
            result.Total.Should().Be(2);
            result.Page.Should().Be(1);
            result.Length.Should().Be(10);
            result.Data.Should().HaveCount(2);
        }
        [Fact]
        public async Task GetList_Should_Filter_By_PublishYear_GreaterThan()
        {
            //Arrange
            var context = await TestDbContextFactory.CreateWithBasicBooksAsync("filter_year");
            var repository = new BookRepository(context);
            int? userId = null;
            int page = 1;
            int pageSize = 10;
            var queryObject = new QueryObject
            {
                Filters = new List<FilterOption>
            {
                new FilterOption
                {
                    propertyName = "PublishYear",
                    type = FilterTypes.GreaterThan,
                    value = "1940"
                }
            }
            };
            string json = JsonSerializer.Serialize(queryObject);
            string encodeQuery = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));


            //Act
            var result = await repository.GetList(userId, page, pageSize, encodeQuery);
            // Assert
            result.Total.Should().Be(1);
            result.Data.Should().ContainSingle();
            result.Data.First().Book.Title.Should().Be("1984");



        }
        [Fact]
        public async Task GetList_Should_Filter_By_Search_Term()
        {
            // Arrange: 
            var context = await TestDbContextFactory.CreateWithBasicBooksAsync(nameof(GetList_Should_Filter_By_Search_Term));
            var repository = new BookRepository(context);
            int? userId = null;
            int page = 1;
            int pageSize = 10;

            var queryObject = new QueryObject
            {
                Search = "world",
                Filters = new List<FilterOption>(),  // Lista vacía para no romper el null-check
                Sorts = new List<SortOption>()
            };
            var json = JsonSerializer.Serialize(queryObject);
            var encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

            // Act
            var result = await repository.GetList(userId, page, pageSize, encoded);

            // Assert
            result.Total.Should().Be(1, "solo 'Brave New World' contiene 'world'");
            result.Data.Should().ContainSingle();

            result.Data.Single().Book.Title.Should().Be("Brave New World");
        }

        [Fact]
        public async Task GetList_Should_Sort_By_Title_Ascending()
        {
            // Arrange
            var context = await TestDbContextFactory.CreateWithBasicBooksAsync("sort_title_asc");
            var repository = new BookRepository(context);
            var queryObject = new QueryObject
            {
                Sorts = new List<SortOption>
                {
                    new SortOption
                    {
                        propertyName = "Title",
                        descending = false
                    }
                }
            };
            string json = JsonSerializer.Serialize(queryObject);
            string encodedQuery = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            // Act
            var result = await repository.GetList(null, page: 1, pageSize: 10, queryStr: encodedQuery);
            // Assert
            result.Data.Should().HaveCount(2);
            result.Data.ElementAt(0).Book.Title.Should().Be("1984");
            result.Data.ElementAt(1).Book.Title.Should().Be("Brave New World");
        }
        [Fact]
        public async Task GetUserShelf_ShouldReturnBooksOnlyForGivenUser()
        {

            // Arrange
            var context = await TestDbContextFactory.CreateWithShelfDataAsync("shelf_user_1");
            var repo = new BookRepository(context);
            // Act
            var result = await repo.GetUserShelf(userId: 1, page: 1, pageSize: 10);
            // Assert

            result.Should().NotBeNull();
            result.Total.Should().Be(2);
            result.Data.Should().HaveCount(2);
            result.Data.Select(b => b.Book.Title)
                 .Should().Contain(new[] { "1984", "The Hobbit" });
        }
        [Fact]
        public async Task Shelve_Should_AddBookToUserShelf()
        {
            // Arrange
            var context = await TestDbContextFactory.CreateEmptyContextAsync("shelve_test");
            var repository = new BookRepository(context);

            // Agregar estado de lectura necesario
            var readingStatus = new ReadingStatus { Id = 1, Name = "Reading" };
            context.ReadingStatuses.Add(readingStatus);

            // Agregar libro
            var book = new Book
            {
                Title = "Clean Code",
                Author = "Robert C. Martin",
                Description = "A book about writing clean code.",
                PublishYear = 2008,
                PageCount = 464,
                Deleted = false,
            };
            context.Books.Add(book);

            await context.SaveChangesAsync();

            // Crear UserBook
            var userBook = new UserBook
            {
                UserId = 1,
                BookId = book.Id,
                ReadingStatusId = 1,
                CreatedAt = DateTime.UtcNow
            };

            // Act
            var result = await repository.Shelve(userBook);

            // Assert
            result.Should().NotBeNull();
            result!.Book.Id.Should().Be(book.Id);
            result.UserBook.Should().NotBeNull();
            result.UserBook!.UserId.Should().Be(1);

            var userBookInDb = await context.UserBooks
                .FirstOrDefaultAsync(ub => ub.UserId == 1 && ub.BookId == book.Id);

            userBookInDb.Should().NotBeNull("the book was added to the shelf");

        }
        [Fact]
        public async Task RemoveFromShelf_Should_RemoveBookFromUserShelf()
        {
            // Arrange
            var context = await TestDbContextFactory.CreateEmptyContextAsync("remove_shelf_test");
            var repository = new BookRepository(context);
            var book = new Book
            {
                Title = "The Pragmatic Programmer",
                Author = "Andy Hunt",
                Description = "A practical guide to programming.",
                PublishYear = 1999,
                PageCount = 352,
                Deleted = false
            };
            context.Books.Add(book);

            var readingStatus = new ReadingStatus
            {
                Id = 1,
                Name = "Reading"
            };
            context.ReadingStatuses.Add(readingStatus);

            var userBook = new UserBook
            {
                UserId = 1,
                Book = book,
                ReadingStatusId = 1,
                CreatedAt = DateTime.UtcNow
            };
            context.UserBooks.Add(userBook);

            await context.SaveChangesAsync();

            // Act
            var result = await repository.RemoveFromShelf(userBook);
            // Assert
            result.Should().BeTrue("the book should be removed from the shelf");

            var userBookInDb = await context.UserBooks
                .FirstOrDefaultAsync(ub => ub.UserId == 1 && ub.BookId == book.Id);

            userBookInDb.Should().BeNull("the user-book relation should no longer exist");
        }
        [Fact]
        public async Task UpdateUserBook_Should_UpdateReadingStatusAndUpdatedAt()
        {
            // Arrange
            var context = await TestDbContextFactory.CreateEmptyContextAsync("update_userbook_test");
            var repository = new BookRepository(context);


            var readingStatus1 = new ReadingStatus { Id = 1, Name = "Reading" };
            var readingStatus2 = new ReadingStatus { Id = 2, Name = "Completed" };
            context.ReadingStatuses.AddRange(readingStatus1, readingStatus2);


            var book = new Book
            {
                Title = "Refactoring",
                Author = "Martin Fowler",
                Description = "Improving the design of existing code.",
                PublishYear = 1999,
                PageCount = 431,
                Deleted = false
            };
            context.Books.Add(book);


            var userBook = new UserBook
            {
                UserId = 1,
                Book = book,
                ReadingStatusId = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            context.UserBooks.Add(userBook);

            await context.SaveChangesAsync();


            var previousUpdatedAt = userBook.UpdatedAt;


            userBook.ReadingStatusId = 2;

            // Act

            var result = await repository.UpdateUserBook(userBook);

            // Assert
            result.Should().NotBeNull();
            result.ReadingStatusId.Should().Be(2, "the reading status should be updated");
            result.UpdatedAt.Should().BeAfter(previousUpdatedAt, "the update timestamp should be refreshed");

            var userBookInDb = await context.UserBooks
                .FirstOrDefaultAsync(ub => ub.UserId == 1 && ub.BookId == book.Id);

            userBookInDb.Should().NotBeNull();
            userBookInDb!.ReadingStatusId.Should().Be(2);
            userBookInDb.UpdatedAt.Should().BeAfter(previousUpdatedAt);
        }
        [Fact]
        public async Task GetOneUserBook_Should_ReturnUserBookWithReadingStatus()
        {
            // Arrange
            var context = await TestDbContextFactory.CreateEmptyContextAsync("get_one_userbook_test");
            var repository = new BookRepository(context);

            var readingStatus = new ReadingStatus { Id = 1, Name = "Reading" };
            context.ReadingStatuses.Add(readingStatus);

            var book = new Book
            {
                Title = "Domain-Driven Design",
                Author = "Eric Evans",
                Description = "Tackling Complexity in the Heart of Software",
                PublishYear = 2003,
                PageCount = 560,
                Deleted = false
            };
            context.Books.Add(book);

            var userBook = new UserBook
            {
                UserId = 1,
                Book = book,
                ReadingStatusId = 1,
                CreatedAt = DateTime.UtcNow
            };
            context.UserBooks.Add(userBook);

            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetOneUserBook(1, book.Id);

            // Assert
            result.Should().NotBeNull();
            result.UserId.Should().Be(1);
            result.BookId.Should().Be(book.Id);
            result.ReadingStatus.Should().NotBeNull("ReadingStatus should be eagerly loaded");
            result.ReadingStatus.Name.Should().Be("Reading");
        }


    }
}
