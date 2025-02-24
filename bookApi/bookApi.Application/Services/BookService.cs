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

    public class BookService : BaseService<Book, BookResponseDto, BookDetailedResponseDto, CreateBookDto, UpdateBookDto>, IBookService
    {
        private new readonly IBookRepository _repository;

        public BookService(IBookRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<BookDetailedResponseDto>> GetAll(int? userId)
        {
            var results = await _repository.GetAllWithIncludes(userId);

            return _mapper.Map<IEnumerable<BookDetailedResponseDto>>(results);
        }

        public async Task<GenericListResponse<BookDetailedResponseDto>> GetList(int? userId, int page, int pageSize, string? query)
        {
            var books = await _repository.GetList(userId, page, pageSize, query);
            return _mapper.Map<GenericListResponse<BookDetailedResponseDto>>(books);
        }

        public async Task<BookDetailedResponseDto?> GetOne(int? userId, int bookId)
        {
            var book = await _repository.GetOne(userId, bookId);
            if (book == null)
            {
                throw new NotFoundException("Book not found")
                {
                    ErrorCode = "003"
                };
            }
            return _mapper.Map<BookDetailedResponseDto>(book);

        }
    }
}
