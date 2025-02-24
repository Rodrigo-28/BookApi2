using bookApi.Domian.Common;
using bookApi.Domian.Interfaces;
using bookApi.Domian.Models;
using bookApi.infrastructure.Contexts;
using bookApi.infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;

namespace bookApi.infrastructure.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {


        public BookRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Book> Create(Book book, List<int>? genreIds)
        {
            var genres = await _context.Genres.Where(g => genreIds.Contains(g.Id)).ToListAsync();

            book.BookGenres = genres.Select(g => new BookGenre { GenreId = g.Id, Book = book }).ToList();

            await Create(book);
            return book;

        }

        public async Task<IEnumerable<BookResponse>> GetAllWithIncludes(int? userId)
        {
            var books = await GetAll(query =>
                query.Include(b => b.BookGenres)
                .ThenInclude(bg => bg.Genre)
                .Include(b => b.UserBooks)
                .ThenInclude(ub => ub.ReadingStatus)
            );

            return books.Select(b => new BookResponse
            {
                Book = b,
                UserBook = b.UserBooks.FirstOrDefault(ub => ub.UserId == userId)
            }).ToList();

        }

        public async Task<GenericListResponse<BookResponse>> GetList(int? userId, int page, int pageSize, string? queryStr = null)
        {
            //Params
            IQueryable<BookResponse> query = _context.Books
                 .Include(b => b.BookGenres)
                 .ThenInclude(bg => bg.Genre)
                 .Include(b => b.UserBooks)
                 .ThenInclude(ub => ub.ReadingStatus)
                 .Select(b => new BookResponse
                 {
                     Book = b,
                     UserBook = b.UserBooks.FirstOrDefault(ub => ub.UserId == userId)
                 }).Where(b => !b.Book.Deleted);
            if (!string.IsNullOrEmpty(queryStr))
            {
                string decodedQuery = Encoding.UTF8.GetString(Convert.FromBase64String(queryStr));
                QueryObject? queryObject = JsonSerializer.Deserialize<QueryObject>(decodedQuery);

                if (queryObject != null)
                {
                    //Filters
                    query = QueryHelpers.ApplyFilters(query, queryObject);
                    //Sorting
                    query = QueryHelpers.ApplySorting(query, queryObject.Sorts);
                }

            }
            //pagination
            //Pagination

            (var paginatedQuery, int total) = QueryHelpers.ApplyPagination(query, page, pageSize);

            var data = await paginatedQuery.ToListAsync();

            return new GenericListResponse<BookResponse>
            {
                Total = total,
                Page = page,
                Length = pageSize,
                Data = data
            };
        }

        public async Task<BookResponse?> GetOne(int? userId, int bookId)
        {
            var book = await GetOne(bookId,
                query => query
            .Include(b => b.BookGenres)
            .ThenInclude(bg => bg.Genre)
            .Include(b => b.UserBooks)
            .ThenInclude(ub => ub.ReadingStatus));

            if (book != null)
            {
                var userBook = book.UserBooks.FirstOrDefault(ub => ub.UserId == userId);
                return new BookResponse
                {
                    Book = book,
                    UserBook = userBook
                };
            }
            return null;
        }



    }
}

