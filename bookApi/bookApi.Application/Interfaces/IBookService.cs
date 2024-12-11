using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;
using bookApi.Domian.Common;

namespace bookApi.Application.Interfaces
{
    public interface IBookService
    {
        Task<BookResponseDto> Create(CreateBookDto bookDto);

        Task<BookResponseDto> Update(int bookId, UpdateBookDto bookDto);
        Task<BookListResponseDto?> GetOne(int? userId, int bookId);
        Task<GenericListResponse<BookListResponseDto>> GetList(int? userId, int page, int pageSize, string? query);


    }
}
