using bookApi.Domian.Models;
using bookApi.infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace bookApiTests.Repository.Helpers
{
    public class TestDbContextFactory
    {
        public static async Task<ApplicationDbContext> CreateEmptyContextAsync(string testName = null)
        {
            var dbName = testName is null
                ? Guid.NewGuid().ToString()
                : $"{testName}_{Guid.NewGuid()}";

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var context = new ApplicationDbContext(options);
            await context.Database.EnsureCreatedAsync();
            return context;
        }
        public static async Task<ApplicationDbContext> CreateWithBookAndUserBookAsync(string testName = null)
        {
            var context = await CreateEmptyContextAsync(testName);
            var readingStatus = new ReadingStatus { Id = 1, Name = "Reading" };
            var user = new User { Id = 1, Username = "TestUser", Email = "test@user.com", Password = "123456", RoleId = 2 };

            var book = new Book
            {
                Id = 1,
                Title = "1984",
                Author = "George Orwell",
                PublishYear = 1949,
                Description = "A dystopian novel.",
                CoverUrl = "https://example.com/1984.jpg",
                PageCount = 328


            };
            var userBook = new UserBook
            {
                UserId = 1,
                BookId = 1,
                ReadingStatusId = 1,
                ReadingStatus = readingStatus,
                User = user,
                Book = book
            };


            context.Users.Add(user);
            context.ReadingStatuses.Add(readingStatus);
            context.Books.Add(book);
            context.UserBooks.Add(userBook);
            await context.SaveChangesAsync();
            return context;
        }
        public static async Task<ApplicationDbContext> CreateWithBasicBooksAsync(string testName = null)
        {
            var context = await CreateEmptyContextAsync(testName);

            var books = new List<Book>
    {
        new Book
        {
            Id = 1,
            Title = "1984",
            Author = "George Orwell",
            PublishYear = 1949,
            Description = "A dystopian novel.",
            CoverUrl = "https://example.com/1984.jpg",
            PageCount = 328,
            Deleted = false,
        },
        new Book
        {
            Id = 2,
            Title = "Brave New World",
            Author = "Aldous Huxley",
            PublishYear = 1932,
            Description = "A futuristic society novel.",
            CoverUrl = "https://example.com/bravenew.jpg",
            PageCount = 311,
            Deleted=false,
        }
    };

            context.Books.AddRange(books);
            await context.SaveChangesAsync();
            return context;
        }
        public static async Task<ApplicationDbContext> CreateWithShelfDataAsync(string testName = null)
        {
            var context = await CreateEmptyContextAsync(testName);

            // 1) Agregamos primero los libros y los guardamos
            var books = new List<Book>
                {
                    new Book { Id = 1, Title = "1984", Author = "George Orwell", PublishYear = 1949,
                        Description = "A dystopian novel.", CoverUrl = "https://example.com/1984.jpg",
                        PageCount = 328, Deleted = false },
                    new Book { Id = 2, Title = "Brave New World", Author = "Aldous Huxley", PublishYear = 1932,
                        Description = "A futuristic society novel.", CoverUrl = "https://example.com/bravenew.jpg",
                        PageCount = 311, Deleted = false },
                    new Book { Id = 3, Title = "The Hobbit", Author = "J.R.R. Tolkien", PublishYear = 1937,
                        Description = "A fantasy adventure novel.", CoverUrl = "https://example.com/hobbit.jpg",
                        PageCount = 310, Deleted = false }
                };
            await context.Books.AddRangeAsync(books);
            await context.SaveChangesAsync();   // ← guardamos primero los libros

            // 2) Ahora los ReadingStatus, que son dependientes de UserBook
            var statuses = new List<ReadingStatus>
                {
                    new ReadingStatus { Id = 1, Name = "Reading" },
                    new ReadingStatus { Id = 2, Name = "Completed" }
                };
            await context.ReadingStatuses.AddRangeAsync(statuses);
            await context.SaveChangesAsync();   // ← guardamos los estados

            // 3) Por último los UserBook (PK compuesta), que referencian a libros y estados ya existentes
            var userBooks = new List<UserBook>
                {
                    new UserBook { UserId = 1, BookId = 1, ReadingStatusId = 1, CreatedAt = DateTime.UtcNow },
                    new UserBook { UserId = 1, BookId = 3, ReadingStatusId = 2, CreatedAt = DateTime.UtcNow },
                    new UserBook { UserId = 2, BookId = 2, ReadingStatusId = 1, CreatedAt = DateTime.UtcNow }
                };
            await context.UserBooks.AddRangeAsync(userBooks);
            await context.SaveChangesAsync();   // ← y guardamos finalmente las relaciones de estantería

            return context;
        }



    }

}
