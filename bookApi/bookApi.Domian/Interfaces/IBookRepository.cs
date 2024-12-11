using bookApi.Domian.Common;
using bookApi.Domian.Models;

namespace bookApi.Domian.Interfaces
{
    public interface IBookRepository
    {
        public Task<Book> Create(Book book, List<int> genreIds);
        public Task<Book> Update(Book book);
        public Task<BookResponse?> GetOne(int? userId, int bookId);
        Task<GenericListResponse<BookResponse>> GetList(int? userId, int page, int pageSize, string? queryStr = null);


    }
}
