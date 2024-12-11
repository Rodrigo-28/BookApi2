using bookApi.Application.Dtos.Request;
using bookApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bookApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            this._bookService = bookService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookDto bookDto)
        {
            var Book = await _bookService.Create(bookDto);
            return CreatedAtRoute("GetBook", new { bookId = Book.Id }, Book);
        }
        [HttpGet("show/{bookId}", Name = "GetBook")]
        public async Task<IActionResult> GetOne(int bookId)
        {
            var res = await _bookService.GetOne(null, bookId);
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string? query)
        {
            var books = await _bookService.GetList(null, page, pageSize, query);
            return Ok(books);
        }
        [HttpPut("{bookId}")]
        public async Task<IActionResult> Update(int bookId, [FromBody] UpdateBookDto bookDto)
        {
            var user = await _bookService.Update(bookId, bookDto);
            return Ok(user);
        }

    }
}
