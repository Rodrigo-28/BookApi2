using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;
using bookApi.Domian.Common;
using bookApi.Domian.Models;

namespace bookApi.Application.Interfaces
{
    public interface IBookService : IBaseService<Book, BookResponseDto, BookDetailedResponseDto, CreateBookDto, UpdateBookDto>
    {
        public Task<BookDetailedResponseDto?> GetOne(int? userId, int bookId);

        public Task<GenericListResponse<BookDetailedResponseDto>> GetList(int? userId, int page, int pageSize, string? query);

        public Task<IEnumerable<BookDetailedResponseDto>> GetAll(int? userId);
    }
}
