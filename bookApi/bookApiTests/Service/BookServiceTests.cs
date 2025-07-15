using AutoMapper;
using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;
using bookApi.Application.Exceptions;
using bookApi.Application.Services;
using bookApi.Domian.Common;
using bookApi.Domian.Enums;
using bookApi.Domian.Interfaces;
using bookApi.Domian.Models;
using FakeItEasy;
using FluentAssertions;

namespace bookApiTests.Service
{
    public class BookServiceTests
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly BookService _bookService;
        public BookServiceTests()
        {
            _bookRepository = A.Fake<IBookRepository>();
            _mapper = A.Fake<IMapper>();
            _bookService = new BookService(_bookRepository, _mapper);
        }
        [Fact]
        public async Task Create_Should_MapDtoToEntityAndReturnMappedDto()
        {
            // Arrange
            var createDto = new CreateBookDto
            {
                Title = "Domain-Driven Design",
                Author = "Eric Evans",
                Description = "Tackling Complexity in the Heart of Software",
                PublishYear = 2003,
                PageCount = 560,
                GenreIds = new List<int> { 1, 2 }
            };
            var bookEntity = new Book
            {
                Id = 1,
                Title = createDto.Title,
                Author = createDto.Author,
                Description = createDto.Description,
                PublishYear = createDto.PublishYear,
                PageCount = createDto.PageCount
            };

            var createdBook = bookEntity;
            var expectedDto = new BookResponseDto
            {
                Id = 1,
                Title = "Domain-Driven Design",
                Author = "Eric Evans",
                Description = "Tackling Complexity in the Heart of Software",
                PublishYear = 2003,
                PageCount = 560
            };

            A.CallTo(() => _mapper.Map<Book>(createDto)).Returns(bookEntity);
            A.CallTo(() => _bookRepository.Create(bookEntity, createDto.GenreIds)).Returns(Task.FromResult(createdBook));
            A.CallTo(() => _mapper.Map<BookResponseDto>(createdBook)).Returns(expectedDto);

            // Act
            var result = await _bookService.Create(createDto);


            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            result.Title.Should().Be("Domain-Driven Design");
            result.Author.Should().Be("Eric Evans");
            result.Description.Should().Be(createDto.Description);
            result.PageCount.Should().Be(createDto.PageCount);
        }
        [Fact]
        public async Task GetList_Should_CallRepositoryAndReturnMappedResult()
        {
            // Arrange
            int? userId = 1;
            int page = 1;
            int pageSize = 10;
            string? query = null;

            var domainBooks = new GenericListResponse<BookResponse>
            {
                Total = 1,
                Page = 1,
                Length = 10,
                Data = new List<BookResponse>
                {
                    new BookResponse
                    {
                        Book = new Book
                        {
                            Id = 1,
                            Title = "Clean Architecture",
                            Author = "Robert C. Martin",
                            PublishYear = 2017,
                            Description = "A book about software architecture.",
                            CoverUrl = "http://example.com/cover.jpg",
                            PageCount = 432
                        },
                        UserBook = null
                    }
                }
            };
            var mappedBooks = new GenericListResponse<BookListResponseDto>
            {
                Total = 1,
                Page = 1,
                Length = 10,
                Data = new List<BookListResponseDto>
                {
                    new BookListResponseDto
                    {
                        Book = new BookResponseDto
                        {
                            Id = 1,
                            Title = "Clean Architecture",
                            Author = "Robert C. Martin",
                            PublishYear = 2017,
                            Description = "A book about software architecture.",
                            CoverUrl = "http://example.com/cover.jpg",
                            PageCount = 432,
                            Genres = new List<GenreResponseDto>()
                        }
                    }
                }
            };
            A.CallTo(() => _bookRepository.GetList(userId, page, pageSize, query))
             .Returns(Task.FromResult(domainBooks));

            A.CallTo(() => _mapper.Map<GenericListResponse<BookListResponseDto>>(domainBooks))
                .Returns(mappedBooks);
            // Act
            var result = await _bookService.GetList(userId, page, pageSize, query);

            // Assert
            A.CallTo(() => _bookRepository.GetList(userId, page, pageSize, query))
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => _mapper.Map<GenericListResponse<BookListResponseDto>>(domainBooks))
             .MustHaveHappenedOnceExactly();


            result.Should().NotBeNull();
            result.Total.Should().Be(1);
            result.Page.Should().Be(1);
            result.Data.Should().HaveCount(1);
            result.Data.First().Book.Title.Should().Be("Clean Architecture");

        }
        [Fact]
        public async Task GetOne_ShouldReturnMappedDto_WhenBookExists()
        {
            // Arrange

            int userId = 1;
            int bookId = 42;


            var bookEntity = new BookResponse
            {
                Book = new Book
                {
                    Id = bookId,
                    Title = "Test Book",
                    Author = "Author",
                    PublishYear = 2020,
                    Description = "Description",
                    CoverUrl = "http://cover.url",
                    PageCount = 300
                },
                UserBook = null
            };


            var expectedDto = new BookListResponseDto
            {
                Book = new BookResponseDto
                {
                    Id = bookId,
                    Title = "Test Book",
                    Author = "Author",
                    PublishYear = 2020,
                    Description = "Description",
                    CoverUrl = "http://cover.url",
                    PageCount = 300,
                    Genres = new List<GenreResponseDto>()
                }
            };


            A.CallTo(() => _bookRepository.GetOne(userId, bookId)).Returns(bookEntity);
            A.CallTo(() => _mapper.Map<BookListResponseDto>(bookEntity)).Returns(expectedDto);

            // Act
            var result = await _bookService.GetOne(userId, bookId);

            // Assert
            result.Should().NotBeNull("a valid BookListResponseDto should be returned");
            result.Should().BeEquivalentTo(expectedDto, "the service should return the mapped DTO");


            A.CallTo(() => _bookRepository.GetOne(userId, bookId)).MustHaveHappenedOnceExactly();


            A.CallTo(() => _mapper.Map<BookListResponseDto>(bookEntity)).MustHaveHappenedOnceExactly();
        }
        [Fact]
        public async Task Update_Should_UpdateFieldsAndReturnMappedResult()
        {
            // Arrange
            int bookId = 1;
            var bookDto = new UpdateBookDto
            {
                Description = "Updated Description",
                CoverUrl = "https://updated-cover.com"
            };

            var existingBook = new BookResponse
            {
                Book = new Book
                {
                    Id = bookId,
                    Title = "Original Title",
                    Author = "Author",
                    Description = "Old Description",
                    CoverUrl = "https://old-cover.com"
                }
            };

            var updatedBook = new Book
            {
                Id = bookId,
                Title = "Original Title",
                Author = "Author",
                Description = bookDto.Description,
                CoverUrl = bookDto.CoverUrl
            };

            var mappedResponse = new BookResponseDto
            {
                Id = bookId,
                Title = "Original Title",
                Author = "Author",
                Description = bookDto.Description,
                CoverUrl = bookDto.CoverUrl,
                PageCount = 123,
                PublishYear = 2023,
                Genres = new List<GenreResponseDto>()
            };

            A.CallTo(() => _bookRepository.GetOne(null, bookId)).Returns(existingBook);
            A.CallTo(() => _bookRepository.Update(A<Book>.That.Matches(b =>
                b.Id == bookId &&
                b.Description == bookDto.Description &&
                b.CoverUrl == bookDto.CoverUrl
            ))).Returns(updatedBook);
            A.CallTo(() => _mapper.Map<BookResponseDto>(updatedBook)).Returns(mappedResponse);

            // Act
            var result = await _bookService.Update(bookId, bookDto);

            // Assert
            A.CallTo(() => _bookRepository.GetOne(null, bookId))
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => _bookRepository.Update(A<Book>._))
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => _mapper.Map<BookResponseDto>(updatedBook))
                .MustHaveHappenedOnceExactly();

            result.Should().NotBeNull();
            result.Id.Should().Be(bookId);
            result.Description.Should().Be(bookDto.Description);
            result.CoverUrl.Should().Be(bookDto.CoverUrl);
        }

        [Fact]
        public async Task ShelveBook_Should_ShelveBookAndReturnMappedDto()
        {
            // Arrange
            int userId = 1;
            int bookId = 1;

            var bookResponse = new BookResponse
            {
                Book = new Book
                {
                    Id = bookId,
                    Title = "1984",
                    Author = "George Orwell"
                },
                UserBook = null // No está shelveado todavía
            };

            var createdUserBook = new UserBook
            {
                UserId = userId,
                BookId = bookId,
                ReadingStatusId = (int)ReadingStatusEnum.WantToRead
            };

            var shelvedBookResponse = new BookResponse
            {
                Book = bookResponse.Book,
                UserBook = createdUserBook
            };

            var expectedDto = new BookListResponseDto
            {
                Book = new BookResponseDto
                {
                    Id = bookId,
                    Title = "1984",
                    Author = "George Orwell",
                    Description = "Dystopian novel",
                    CoverUrl = "https://example.com/cover.jpg",
                    PageCount = 300,
                    PublishYear = 1949,
                    Genres = new List<GenreResponseDto>()
                }
            };

            A.CallTo(() => _bookRepository.GetOne(userId, bookId)).Returns(bookResponse);
            A.CallTo(() => _bookRepository.Shelve(A<UserBook>.That.Matches(
                ub => ub.UserId == userId && ub.BookId == bookId && ub.ReadingStatusId == (int)ReadingStatusEnum.WantToRead
            ))).Returns(shelvedBookResponse);
            A.CallTo(() => _mapper.Map<BookListResponseDto>(shelvedBookResponse)).Returns(expectedDto);

            // Act
            var result = await _bookService.ShelveBook(userId, bookId);

            // Assert
            A.CallTo(() => _bookRepository.GetOne(userId, bookId))
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => _bookRepository.Shelve(A<UserBook>._))
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => _mapper.Map<BookListResponseDto>(shelvedBookResponse))
                .MustHaveHappenedOnceExactly();

            result.Should().NotBeNull();
            result.Book.Should().NotBeNull();
            result.Book.Id.Should().Be(bookId);
            result.Book.Title.Should().Be("1984");
        }
        [Fact]
        public async Task ShelveBook_Should_ThrowBadRequestException_WhenBookAlreadyShelved()
        {
            // Arrange
            int userId = 1;
            int bookId = 1;

            // Creamos un BookResponse que ya tiene un UserBook asociado
            var bookResponse = new BookResponse
            {
                Book = new Book
                {
                    Id = bookId,
                    Title = "1984",
                    Author = "George Orwell"
                },
                UserBook = new UserBook
                {
                    UserId = userId,
                    BookId = bookId,
                    ReadingStatusId = (int)ReadingStatusEnum.Reading
                }
            };


            A.CallTo(() => _bookRepository.GetOne(userId, bookId)).Returns(bookResponse);

            // Act
            Func<Task> act = async () => await _bookService.ShelveBook(userId, bookId);

            // Assert
            await act.Should().ThrowAsync<BadRequestException>()
                .WithMessage("Book is already shelved")
                .Where(ex => ex.ErrorCode == "007");


            A.CallTo(() => _bookRepository.Shelve(A<UserBook>._)).MustNotHaveHappened();
            A.CallTo(() => _mapper.Map<BookListResponseDto>(A<BookResponse>._)).MustNotHaveHappened();
        }
        [Fact]
        public async Task ShelveBook_Should_ThrowBadRequestException_WhenBookDoesNotExist()
        {
            // Arrange
            int userId = 1;
            int bookId = 99;

            // Simulamos que no se encuentra el libro
            A.CallTo(() => _bookRepository.GetOne(userId, bookId)).Returns(Task.FromResult<BookResponse?>(null));

            // Act
            Func<Task> act = async () => await _bookService.ShelveBook(userId, bookId);

            // Assert
            await act.Should().ThrowAsync<BadRequestException>()
                .WithMessage($"Book with id {bookId} does not exist")
                .Where(ex => ex.ErrorCode == "006");


            A.CallTo(() => _bookRepository.Shelve(A<UserBook>._)).MustNotHaveHappened();
            A.CallTo(() => _mapper.Map<BookListResponseDto>(A<BookResponse>._)).MustNotHaveHappened();
        }
        [Fact]
        public async Task UpdateReadingStatus_Should_UpdateStatusAndReturnMappedDto()
        {
            // Arrange
            int userId = 1;
            int bookId = 1;
            var dto = new UpdateReadingStatusDto { Status = ReadingStatusEnum.Reading };

            var existingUserBook = new UserBook
            {
                UserId = userId,
                BookId = bookId,
                ReadingStatusId = (int)ReadingStatusEnum.WantToRead,
                CreatedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                Rating = 0f,
                ReadingStatus = new ReadingStatus { Id = (int)ReadingStatusEnum.Reading, Name = "Reading" }
            };

            var bookResponse = new BookResponse
            {
                Book = new Book { Id = bookId, Title = "Test Book", Author = "Author" },
                UserBook = existingUserBook
            };

            var updatedUserBook = new UserBook
            {
                UserId = userId,
                BookId = bookId,
                ReadingStatusId = (int)ReadingStatusEnum.Reading,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = existingUserBook.CreatedAt,
                Rating = 0f,
                ReadingStatus = new ReadingStatus { Id = (int)ReadingStatusEnum.Reading, Name = "Reading" }
            };

            var expectedDto = new UserBookResponseDto
            {
                Status = new ReadingStatusResponseDto { Id = (int)ReadingStatusEnum.Reading, Name = "Reading" },
                Rating = 0f,
                CreatedAt = updatedUserBook.CreatedAt,
                UpdatedAt = updatedUserBook.UpdatedAt
            };

            A.CallTo(() => _bookRepository.GetOne(userId, bookId)).Returns(bookResponse);
            A.CallTo(() => _bookRepository.UpdateUserBook(A<UserBook>.That.Matches(ub => ub.ReadingStatusId == (int)ReadingStatusEnum.Reading)))
                .Returns(updatedUserBook);
            A.CallTo(() => _mapper.Map<UserBookResponseDto>(updatedUserBook)).Returns(expectedDto);

            // Act
            var result = await _bookService.updateReadingStatus(userId, bookId, dto);

            // Assert
            result.Should().NotBeNull("because the status should be updated and mapped");
            result.Status.Id.Should().Be((int)ReadingStatusEnum.Reading);
            result.Status.Name.Should().Be("Reading");
            result.Rating.Should().Be(0f);
            result.CreatedAt.Should().Be(existingUserBook.CreatedAt);
            result.UpdatedAt.Should().BeAfter(existingUserBook.UpdatedAt);

            A.CallTo(() => _bookRepository.GetOne(userId, bookId)).MustHaveHappenedOnceExactly();
            A.CallTo(() => _bookRepository.UpdateUserBook(A<UserBook>.That.Matches(ub => ub.ReadingStatusId == (int)ReadingStatusEnum.Reading)))
                  .Returns(updatedUserBook);
            A.CallTo(() => _mapper.Map<UserBookResponseDto>(updatedUserBook)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task RateBook_Should_UpdateRatingAndReturnMappedDto()
        {
            // Arrange
            var userId = 1;
            var bookId = 42;
            var rating = 4.5f;

            var rateBookDto = new RateBookDto { Rating = rating };

            var updatedUserBook = new UserBook
            {
                UserId = userId,
                BookId = bookId,
                Rating = rating,
                ReadingStatusId = (int)ReadingStatusEnum.Read,
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                UpdatedAt = DateTime.UtcNow
            };

            var expectedDto = new UserBookResponseDto
            {
                Rating = rating,
                Status = new ReadingStatusResponseDto
                {
                    Id = (int)ReadingStatusEnum.Read,
                    Name = "Read"
                },
                CreatedAt = updatedUserBook.CreatedAt,
                UpdatedAt = updatedUserBook.UpdatedAt
            };

            A.CallTo(() => _bookRepository.GetOne(userId, bookId))
                .Returns(new BookResponse
                {
                    Book = new Book { Id = bookId, Title = "Some Book" },
                    UserBook = null // Simula que aún no está shelveado
                });

            A.CallTo(() => _bookRepository.Shelve(A<UserBook>._))
                .Invokes((UserBook ub) =>
                {
                    ub.CreatedAt = updatedUserBook.CreatedAt;
                    ub.UpdatedAt = updatedUserBook.UpdatedAt;
                });

            A.CallTo(() => _bookRepository.UpdateUserBook(A<UserBook>.That.Matches(ub =>
                ub.Rating == rating && ub.ReadingStatusId == (int)ReadingStatusEnum.Read)))
                .Returns(updatedUserBook);

            A.CallTo(() => _mapper.Map<UserBookResponseDto>(updatedUserBook))
                .Returns(expectedDto);

            // Act
            var result = await _bookService.RateBook(userId, bookId, rateBookDto);

            // Assert
            result.Should().NotBeNull("a valid rating should return a DTO");
            result.Rating.Should().Be(rating, "the rating was set correctly");
            result.Status.Id.Should().Be((int)ReadingStatusEnum.Read, "the status was set to Read");
            result.UpdatedAt.Should().Be(updatedUserBook.UpdatedAt);

            A.CallTo(() => _bookRepository.GetOne(userId, bookId))
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => _bookRepository.Shelve(A<UserBook>._))
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => _bookRepository.UpdateUserBook(A<UserBook>.That.Matches(ub =>
                ub.Rating == rating && ub.ReadingStatusId == (int)ReadingStatusEnum.Read)))
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => _mapper.Map<UserBookResponseDto>(updatedUserBook))
                .MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task RateBook_Should_UpdateRatingAndStatusCorrectly()
        {
            // Arrange
            int userId = 1;
            int bookId = 42;
            var rateBookDto = new RateBookDto { Rating = 4.5f };

            var userBook = new UserBook
            {
                UserId = userId,
                BookId = bookId,
                Rating = 0,
                ReadingStatusId = (int)ReadingStatusEnum.WantToRead,
                UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow.AddMinutes(-5), DateTimeKind.Local) // For conversion test
            };

            var bookResponse = new BookResponse
            {
                Book = new Book { Id = bookId, Title = "1984" },
                UserBook = userBook
            };

            var updatedUserBook = new UserBook
            {
                UserId = userId,
                BookId = bookId,
                Rating = rateBookDto.Rating,
                ReadingStatusId = (int)ReadingStatusEnum.Read,
                UpdatedAt = DateTime.UtcNow
            };

            var expectedDto = new UserBookResponseDto
            {
                Rating = rateBookDto.Rating,
                Status = new ReadingStatusResponseDto { Id = (int)ReadingStatusEnum.Read, Name = "Read" },
                CreatedAt = updatedUserBook.CreatedAt,
                UpdatedAt = updatedUserBook.UpdatedAt
            };

            A.CallTo(() => _bookRepository.GetOne(userId, bookId)).Returns(bookResponse);
            A.CallTo(() => _bookRepository.UpdateUserBook(
                A<UserBook>.That.Matches(ub =>
                    ub.Rating == rateBookDto.Rating &&
                    ub.ReadingStatusId == (int)ReadingStatusEnum.Read
                ))).Returns(updatedUserBook);

            A.CallTo(() => _mapper.Map<UserBookResponseDto>(updatedUserBook)).Returns(expectedDto);

            // Act
            var result = await _bookService.RateBook(userId, bookId, rateBookDto);

            // Assert
            A.CallTo(() => _bookRepository.GetOne(userId, bookId)).MustHaveHappenedOnceExactly();
            A.CallTo(() => _bookRepository.UpdateUserBook(A<UserBook>._)).MustHaveHappenedOnceExactly();
            A.CallTo(() => _mapper.Map<UserBookResponseDto>(updatedUserBook)).MustHaveHappenedOnceExactly();

            result.Rating.Should().Be(rateBookDto.Rating, "the rating should be updated");
            result.Status.Id.Should().Be((int)ReadingStatusEnum.Read, "the reading status should be set to 'Read'");
        }

        [Fact]
        public async Task RemoveFromShelf_Should_RemoveUserBook_WhenExists()
        {
            // Arrange
            int userId = 1;
            int bookId = 10;

            var book = new Book { Id = bookId, Title = "Test Book" };
            var userBook = new UserBook { UserId = userId, BookId = bookId };

            var bookResponse = new BookResponse
            {
                Book = book,
                UserBook = userBook
            };

            A.CallTo(() => _bookRepository.GetOne(userId, bookId))
                .Returns(Task.FromResult(bookResponse));

            A.CallTo(() => _bookRepository.RemoveFromShelf(
                A<UserBook>.That.Matches(ub => ub.UserId == userId && ub.BookId == bookId)))
            .Returns(Task.FromResult(true));


            // Act
            var result = await _bookService.RemoveFromShelf(userId, bookId);

            // Assert
            result.Should().BeTrue("the book was removed from the user's shelf");

            A.CallTo(() => _bookRepository.GetOne(userId, bookId))
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => _bookRepository.RemoveFromShelf(userBook))
                .MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task GetUserShelf_Should_ReturnMappedResult()
        {
            // Arrange
            int userId = 1;
            int page = 1;
            int pageSize = 10;

            var domainBooks = new GenericListResponse<BookResponse>
            {
                Total = 2,
                Page = page,
                Length = 2,
                Data = new List<BookResponse>
        {
            new BookResponse { Book = new Book { Id = 1, Title = "Book A" } },
            new BookResponse { Book = new Book { Id = 2, Title = "Book B" } }
        }
            };

            var mappedResult = new GenericListResponse<BookListResponseDto>
            {
                Total = 2,
                Page = page,
                Length = 2,
                Data = new List<BookListResponseDto>
        {
            new BookListResponseDto { Book = new BookResponseDto { Id = 1, Title = "Book A" } },
            new BookListResponseDto { Book = new BookResponseDto { Id = 2, Title = "Book B" } }
        }
            };

            A.CallTo(() => _bookRepository.GetUserShelf(userId, page, pageSize))
                .Returns(Task.FromResult(domainBooks));

            A.CallTo(() => _mapper.Map<GenericListResponse<BookListResponseDto>>(domainBooks))
                .Returns(mappedResult);

            // Act
            var result = await _bookService.GetUserShelf(userId, page, pageSize);

            // Assert
            result.Should().BeEquivalentTo(mappedResult, "it should return the mapped shelf result");

            A.CallTo(() => _bookRepository.GetUserShelf(userId, page, pageSize))
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => _mapper.Map<GenericListResponse<BookListResponseDto>>(domainBooks))
                .MustHaveHappenedOnceExactly();
        }

    }
}
