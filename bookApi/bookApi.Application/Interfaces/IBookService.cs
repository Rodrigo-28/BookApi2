using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;
using bookApi.Domian.Common;

namespace bookApi.Application.Interfaces
{
    public interface IBookService
    {
        public Task<BookListResponseDto?> GetOne(int? userId, int bookId);

        public Task<GenericListResponse<BookListResponseDto>> GetList(int? userId, int page, int pageSize, string? query);

        Task<BookResponseDto> Create(CreateBookDto bookDto);

        Task<BookResponseDto> Update(int bookId, UpdateBookDto userDto);



        public Task<GenericListResponse<BookListResponseDto>> GetUserShelf(int userId, int page, int pageSize);

        //public Task<ShelfBookResponseDto> ShelveBook(int? userId, int bookId);
        public Task<BookListResponseDto> ShelveBook(int? userId, int bookId);
        Task<UserBookResponseDto> updateReadingStatus(int userId, int bookId, UpdateReadingStatusDto updateReadingStatusDto);


        Task<UserBookResponseDto> RateBook(int userId, int bookId, RateBookDto rateBookDto);

        public Task<bool> RemoveFromShelf(int userId, int bookId);

        public Task<bool> Delete(int bookId);


    }
}
