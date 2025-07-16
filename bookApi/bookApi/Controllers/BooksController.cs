using bookApi.Application.Dtos.Request;
using bookApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bookApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IUserHelper _userHelper;

        public BooksController(IBookService bookService, IUserHelper userHelper)
        {
            this._bookService = bookService;
            this._userHelper = userHelper;
        }
        [Authorize(Policy = "AdminOnly")]

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookDto bookDto)
        {
            var Book = await _bookService.Create(bookDto);
            return CreatedAtRoute("GetBook", new { bookId = Book.Id }, Book);
        }
        [HttpGet("show/{bookId}", Name = "GetBook")]
        public async Task<IActionResult> GetOne(int bookId)
        {
            var userId = _userHelper.GetRequiredUserId(User);
            var res = await _bookService.GetOne(userId, bookId);
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string? query)
        {
            var books = await _bookService.GetList(null, page, pageSize, query);
            return Ok(books);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{bookId}")]
        public async Task<IActionResult> Update(int bookId, [FromBody] UpdateBookDto bookDto)
        {
            var user = await _bookService.Update(bookId, bookDto);
            return Ok(user);
        }

        [Authorize(Policy = "AuthenticatedUser")]
        [HttpGet("review/list")]
        public async Task<IActionResult> GetUserShelf([FromQuery] int page, [FromQuery] int pageSize)
        {
            var userId = _userHelper.GetRequiredUserId(User);
            var books = await _bookService.GetUserShelf(userId, page, pageSize);

            return Ok(books);
        }

        [HttpPost("shelve")]
        public async Task<IActionResult> ShelveBook([FromBody] ShelveBookDto shelveBookDto)
        {
            var userId = _userHelper.GetRequiredUserId(User);

            var shelveBookResponse = await _bookService.ShelveBook(userId, shelveBookDto.BookId);

            if (shelveBookResponse != null)
            {
                return CreatedAtAction(
                    actionName: nameof(GetOne),
                    routeValues: new { bookId = shelveBookResponse.Book.Id },
                    value: shelveBookResponse
                );

            }

            return Conflict();

        }
        [Authorize(Policy = "AuthenticatedUser")]

        [HttpPut("{bookId}/update-status")]
        public async Task<IActionResult> UpdateStatus(int bookId, [FromBody] UpdateReadingStatusDto updateReadingStatusDto)
        {
            var userId = _userHelper.GetRequiredUserId(User);
            var userBook = await _bookService.updateReadingStatus(userId, bookId, updateReadingStatusDto);

            return Ok(userBook);
        }
        [Authorize(Policy = "AuthenticatedUser")]

        [HttpPut("{bookId}/rate")]
        public async Task<IActionResult> RateBook(int bookId, [FromBody] RateBookDto rateBookDto)
        {
            var userId = _userHelper.GetRequiredUserId(User);
            var userBook = await _bookService.RateBook(userId, bookId, rateBookDto);
            return Ok(userBook);
        }
        [Authorize(Policy = "AuthenticatedUser")]

        [HttpDelete("{bookId}/remove")]
        public async Task<IActionResult> RemoveFromShelf(int bookId)
        {
            var userId = _userHelper.GetRequiredUserId(User);
            var userBookDeleted = await _bookService.RemoveFromShelf(userId, bookId);
            return Ok(userBookDeleted);
        }

    }
}
