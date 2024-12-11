using AutoMapper;
using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;
using bookApi.Application.Exceptions;
using bookApi.Application.Interfaces;
using bookApi.Domian.Common;
using bookApi.Domian.Interfaces;
using bookApi.Domian.Models;

namespace bookApi.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            this._bookRepository = bookRepository;
            this._mapper = mapper;
        }


        public async Task<BookResponseDto> Create(CreateBookDto bookDto)
        {
            var newBook = _mapper.Map<Book>(bookDto);

            var createdBook = await _bookRepository.Create(newBook, bookDto.GenreIds);

            return _mapper.Map<BookResponseDto>(createdBook);
        }

        public async Task<GenericListResponse<BookListResponseDto>> GetList(int? userId, int page, int pageSize, string? query)
        {
            var books = await _bookRepository.GetList(userId, page, pageSize, query);

            return _mapper.Map<GenericListResponse<BookListResponseDto>>(books);
        }

        public async Task<BookListResponseDto?> GetOne(int? userId, int bookId)
        {
            var book = await _bookRepository.GetOne(userId, bookId);
            if (book == null)
            {
                throw new NotFoundException("Book not found")
                {
                    ErrorCode = "003"
                };
            }

            return _mapper.Map<BookListResponseDto>(book);
        }

        public async Task<BookResponseDto> Update(int bookId, UpdateBookDto bookDto)
        {
            var currentBook = await _bookRepository.GetOne(null, bookId);

            if (currentBook == null)
            {
                throw new BadRequestException($"No book found with id {bookId}")
                {
                    ErrorCode = "005"
                };

            }
            currentBook.Book.Description = bookDto.Description;
            currentBook.Book.CoverUrl = bookDto.CoverUrl;


            var updatedBook = await _bookRepository.Update(currentBook.Book);

            return _mapper.Map<BookResponseDto>(updatedBook);
        }
    }
}
