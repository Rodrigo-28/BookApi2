using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;
using bookApi.Application.Interfaces;
using bookApi.Controllers;
using bookApi.Domian.Common;
using bookApi.Domian.Enums;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace bookApiTests.Controller
{
    public class BooksControllerTests
    {
        private readonly BooksController _controller;
        private readonly IBookService _bookService;
        private readonly IUserHelper _userHelper;
        public BooksControllerTests()
        {
            _bookService = A.Fake<IBookService>();
            _userHelper = A.Fake<IUserHelper>();
            _controller = new BooksController(_bookService, _userHelper);
        }
        [Fact]
        public async Task GetOne_ShouldReturnOk_WithBookResponseDto()
        {
            // Arrange
            const int bookId = 42;
            const int userId = 7;

            var expectedDto = new BookListResponseDto
            {
                Book = new BookResponseDto
                {
                    Id = bookId,
                    Title = "1984",
                    Author = "George Orwell",
                    PublishYear = 1949,
                    Description = "Dystopian novel",
                    CoverUrl = "cover.jpg",
                    PageCount = 328,
                    Genres = new List<GenreResponseDto>
            {
                new GenreResponseDto { Id = 1, Name = "Fiction" },
                new GenreResponseDto { Id = 2, Name = "Sci-Fi" }
            }
                }
            };

            A.CallTo(() => _userHelper.GetRequiredUserId(A<ClaimsPrincipal>._))
                .Returns(userId);

            A.CallTo(() => _bookService.GetOne(userId, bookId))
                .Returns(expectedDto);

            // Act
            var result = await _controller.GetOne(bookId);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull("el resultado debe ser 200 OK");

            var actualDto = okResult!.Value as BookListResponseDto;
            actualDto.Should().NotBeNull("el controlador debería retornar BookListResponseDto");

            actualDto.Should().BeEquivalentTo(expectedDto);

            A.CallTo(() => _userHelper.GetRequiredUserId(A<ClaimsPrincipal>._)).MustHaveHappenedOnceExactly();
            A.CallTo(() => _bookService.GetOne(userId, bookId)).MustHaveHappenedOnceExactly();
        }
        [Fact]
        public async Task GetList_ShouldReturnOk_WithPaginatedBooks()
        {
            // Arrange
            const int page = 2;
            const int pageSize = 5;
            const string query = "fantasy";


            var dto1 = new BookListResponseDto
            {
                Book = new BookResponseDto
                {
                    Id = 10,
                    Title = "Dune",
                    Author = "Frank Herbert",
                    PublishYear = 1965,
                    Description = "Classic sci-fi",
                    CoverUrl = "dune.jpg",
                    PageCount = 412,
                    Genres = new List<GenreResponseDto> {
                new GenreResponseDto { Id = 2, Name = "Science Fiction" }
            }
                }
            };
            var dto2 = new BookListResponseDto
            {
                Book = new BookResponseDto
                {
                    Id = 20,
                    Title = "The Hobbit",
                    Author = "J.R.R. Tolkien",
                    PublishYear = 1937,
                    Description = "Fantasy adventure",
                    CoverUrl = "hobbit.jpg",
                    PageCount = 310,
                    Genres = new List<GenreResponseDto> {
                new GenreResponseDto { Id = 1, Name = "Fantasy" }
            }
                }
            };


            var expected = new GenericListResponse<BookListResponseDto>
            {
                Total = 2,
                Page = page,
                Length = pageSize,
                Data = new[] { dto1, dto2 }
            };

            // Configuramos el fake del servicio:
            A.CallTo(() => _bookService.GetList(null, page, pageSize, query))
             .Returns(expected);

            // Act
            var actionResult = await _controller.GetList(page, pageSize, query);

            // Assert
            //  El resultado debe ser un OkObjectResult
            var okResult = actionResult as OkObjectResult;
            okResult.Should().NotBeNull("debe devolver un 200 OK");


            okResult!.StatusCode.Should().Be(200);


            okResult.Value.Should().BeEquivalentTo(expected, "debe retornar el paginado tal cual vino del servicio");


            A.CallTo(() => _bookService.GetList(null, page, pageSize, query))
             .MustHaveHappenedOnceExactly();
        }
        [Fact]
        public async Task Update_ShouldReturnOk_WhenBookIsUpdated()
        {
            // Arrange
            const int bookId = 10;

            var updateDto = new UpdateBookDto
            {
                Description = "Nueva descripción",
                CoverUrl = "new-cover.jpg"
            };

            var updatedBook = new BookResponseDto
            {
                Id = bookId,
                Title = "Clean Code",
                Author = "Robert C. Martin",
                PublishYear = 2008,
                Description = updateDto.Description,
                CoverUrl = updateDto.CoverUrl,
                PageCount = 464,
                Genres = new List<GenreResponseDto>
        {
            new GenreResponseDto { Id = 1, Name = "Programming" }
        }
            };

            A.CallTo(() => _bookService.Update(bookId, updateDto))
             .Returns(updatedBook);

            // Act
            var result = await _controller.Update(bookId, updateDto);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull("debe devolver 200 OK con el libro actualizado");

            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().BeEquivalentTo(updatedBook, "debe retornar el libro actualizado correctamente");

            A.CallTo(() => _bookService.Update(bookId, updateDto)).MustHaveHappenedOnceExactly();
        }
        [Fact]
        public async Task GetList_ShouldReturnOk_WithListOfBooks()
        {
            // Arrange
            const int page = 1;
            const int pageSize = 10;
            const string query = "fiction";

            var books = new List<BookListResponseDto>
                {
                    new BookListResponseDto
                    {
                        Book = new BookResponseDto
                        {
                            Id = 1,
                            Title = "1984",
                            Author = "George Orwell",
                            PublishYear = 1949,
                            Description = "Dystopian novel",
                            CoverUrl = "cover.jpg",
                            PageCount = 328,
                            Genres = new List<GenreResponseDto>
                            {
                                new GenreResponseDto { Id = 1, Name = "Fiction" }
                            }
                        }
                    }
                };

            var response = new GenericListResponse<BookListResponseDto>
            {
                Data = books,
                Total = 1
            };

            A.CallTo(() => _bookService.GetList(null, page, pageSize, query)).Returns(response);

            // Act
            var result = await _controller.GetList(page, pageSize, query);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull("debería devolver 200 OK con una lista de libros");

            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().BeEquivalentTo(response, "debe devolver la lista de libros paginada correctamente");

            A.CallTo(() => _bookService.GetList(null, page, pageSize, query)).MustHaveHappenedOnceExactly();
        }
        [Fact]
        public async Task ShelveBook_ShouldReturnCreatedAtAction_WhenSuccess()
        {
            // Arrange
            var shelveBookDto = new ShelveBookDto
            {
                BookId = 42
            };

            var userId = 7;

            var shelveBookResponse = new BookListResponseDto
            {
                Book = new BookResponseDto
                {
                    Id = shelveBookDto.BookId,
                    Title = "1984",
                    Author = "George Orwell",
                    PublishYear = 1949,
                    Description = "Dystopian novel",
                    CoverUrl = "cover.jpg",
                    PageCount = 328,
                    Genres = new List<GenreResponseDto>
            {
                new GenreResponseDto { Id = 1, Name = "Fiction" },
                new GenreResponseDto { Id = 2, Name = "Sci-Fi" }
            }
                }
            };

            A.CallTo(() => _userHelper.GetRequiredUserId(A<ClaimsPrincipal>._))
                .Returns(userId);

            A.CallTo(() => _bookService.ShelveBook(userId, shelveBookDto.BookId))
                .Returns(shelveBookResponse);

            // Act
            var result = await _controller.ShelveBook(shelveBookDto);

            // Assert
            var createdAtActionResult = result as CreatedAtActionResult;
            createdAtActionResult.Should().NotBeNull();
            createdAtActionResult!.ActionName.Should().Be("GetOne");
            createdAtActionResult.RouteValues!["bookId"].Should().Be(shelveBookDto.BookId);
            createdAtActionResult.Value.Should().BeEquivalentTo(shelveBookResponse);

            A.CallTo(() => _userHelper.GetRequiredUserId(A<ClaimsPrincipal>._)).MustHaveHappenedOnceExactly();
            A.CallTo(() => _bookService.ShelveBook(userId, shelveBookDto.BookId)).MustHaveHappenedOnceExactly();
        }
        [Fact]
        public async Task UpdateStatus_ShouldReturnOk_WhenStatusIsUpdatedSuccessfully()
        {
            // Arrange
            const int bookId = 42;
            const int userId = 7;

            var updateDto = new UpdateReadingStatusDto
            {
                Status = ReadingStatusEnum.Read
            };

            var userBookDto = new UserBookResponseDto
            {
                Status = new ReadingStatusResponseDto { Id = 2, Name = "Reading" },
                Rating = 0,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            A.CallTo(() => _userHelper.GetRequiredUserId(A<ClaimsPrincipal>._))
                .Returns(userId);

            A.CallTo(() => _bookService.updateReadingStatus(userId, bookId, updateDto))
                .Returns(userBookDto);

            // Act
            var result = await _controller.UpdateStatus(bookId, updateDto);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.Value.Should().BeEquivalentTo(userBookDto);

            A.CallTo(() => _userHelper.GetRequiredUserId(A<ClaimsPrincipal>._)).MustHaveHappenedOnceExactly();
            A.CallTo(() => _bookService.updateReadingStatus(userId, bookId, updateDto)).MustHaveHappenedOnceExactly();
        }
        [Fact]
        public async Task RateBook_ShouldReturnOk_WhenRatingIsSuccessful()
        {
            // Arrange
            const int bookId = 42;
            const int userId = 7;

            var rateDto = new RateBookDto
            {
                Rating = 4.5f
            };

            var userBookDto = new UserBookResponseDto
            {
                Status = new ReadingStatusResponseDto { Id = 2, Name = "Reading" },
                Rating = 4.5f,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            A.CallTo(() => _userHelper.GetRequiredUserId(A<ClaimsPrincipal>._))
                .Returns(userId);

            A.CallTo(() => _bookService.RateBook(userId, bookId, rateDto))
                .Returns(userBookDto);

            // Act
            var result = await _controller.RateBook(bookId, rateDto);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.Value.Should().BeEquivalentTo(userBookDto);

            A.CallTo(() => _userHelper.GetRequiredUserId(A<ClaimsPrincipal>._)).MustHaveHappenedOnceExactly();
            A.CallTo(() => _bookService.RateBook(userId, bookId, rateDto)).MustHaveHappenedOnceExactly();
        }
        [Fact]
        public async Task RemoveFromShelf_ShouldReturnOk_WhenSuccessful()
        {
            // Arrange
            const int userId = 7;
            const int bookId = 42;

            var deletedUserBook = new UserBookResponseDto
            {
                Status = new ReadingStatusResponseDto { Id = 3, Name = "Removed" },
                Rating = 0,
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
                UpdatedAt = DateTime.UtcNow
            };

            A.CallTo(() => _userHelper.GetRequiredUserId(A<ClaimsPrincipal>._))
                .Returns(userId);

            A.CallTo(() => _bookService.RemoveFromShelf(userId, bookId))
             .Returns(true);

            // Act
            var result = await _controller.RemoveFromShelf(bookId);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.Value.Should().BeEquivalentTo(true);

            A.CallTo(() => _userHelper.GetRequiredUserId(A<ClaimsPrincipal>._)).MustHaveHappenedOnceExactly();
            A.CallTo(() => _bookService.RemoveFromShelf(userId, bookId)).MustHaveHappenedOnceExactly();
        }


    }
}
