using bookApi.Domian.Common;
using bookApi.Domian.Interfaces;
using bookApi.Domian.Models;
using bookApi.infrastructure.Contexts;
using bookApi.infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;

namespace bookApi.infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Book> Create(Book book, List<int> genreIds)
        {
            var genres = await _context.Genres.Where(g => genreIds.Contains(g.Id)).ToListAsync();
            //assign the genres to the book entity
            book.BookGenres = genres.Select(g => new BookGenre { GenreId = g.Id, Book = book }).ToList();

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<BookResponse?> GetOne(int? userId, int bookId)
        {
            var book = await _context.Books.
                Include(b => b.BookGenres)
                .ThenInclude(bg => bg.Genre)
                .Include(b => b.UserBooks)
                .ThenInclude(ub => ub.ReadingStatus)
                .Select(b => new BookResponse
                {
                    Book = b,
                    UserBook = b.UserBooks.FirstOrDefault(ub => ub.UserId == userId)
                })
                .FirstOrDefaultAsync(b => b.Book.Id == bookId && !b.Book.Deleted);
            return book;
        }

        public async Task<Book> Update(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }
        public async Task<GenericListResponse<BookResponse>> GetList(int? userId, int page, int pageSize, string? queryStr = null)


        {
            // params
            IQueryable<BookResponse> query = _context.Books
                .Include(b => b.BookGenres)
                .ThenInclude(bg => bg.Genre)
                .Include(b => b.UserBooks)
                .ThenInclude(ub => ub.ReadingStatus)
                .Select(b => new BookResponse
                {
                    Book = b,
                    UserBook = b.UserBooks.FirstOrDefault(b => b.UserId == userId)
                })
                .Where(b => !b.Book.Deleted);

            if (!string.IsNullOrEmpty(queryStr))
            {
                string decodedQuery = Encoding.UTF8.GetString(Convert.FromBase64String(queryStr));
                QueryObject? queryObject = JsonSerializer.Deserialize<QueryObject>(decodedQuery);

                if (!string.IsNullOrEmpty(queryObject!.Search))
                {
                    var containsValue = queryObject.Search.ToLower();
                    query = query.Where(b => b.Book.Title.ToLower().Contains(containsValue) ||
                                    b.Book.Author.ToLower().Contains(containsValue) ||
                         (b.Book.Description != null && b.Book.Description.ToLower().Contains(containsValue)));
                }

                foreach (var filter in queryObject.Filters)
                {
                    var parameter = Expression.Parameter(typeof(BookResponse), "b");
                    var property = Expression.Property(Expression.Property(parameter, "Book"), filter.propertyName);
                    Expression? expression;
                    var propertyType = property.Type;
                    // Determinar el tipo subyacente para Nullable<T>
                    var underlyingType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;
                    // Convertir el string al tipo base (int, DateTime, etc.)
                    object convertedValue = Convert.ChangeType(filter.value, underlyingType);
                    // Crear CONSTANTE del mismo tipo que la propiedad (nullable incluído) ← aquí
                    var constant = Expression.Constant(convertedValue, propertyType);




                    switch (filter.type)
                    {
                        case FilterTypes.Equals:
                            expression = Expression.Equal(property, constant);
                            break;
                        case FilterTypes.NotEquals:
                            expression = Expression.NotEqual(property, constant);
                            break;
                        case FilterTypes.GreaterThan:
                            expression = Expression.GreaterThan(property, constant);
                            break;
                        case FilterTypes.LowerThan:
                            expression = Expression.LessThan(property, constant);
                            break;
                        case FilterTypes.GreaterThanEquals:
                            expression = Expression.GreaterThanOrEqual(property, constant);
                            break;
                        case FilterTypes.LowerThanEquals:
                            expression = Expression.LessThanOrEqual(property, constant);
                            break;
                        case FilterTypes.Like:
                            var likeValue = $"%{convertedValue}%";
                            var mi = typeof(string).GetMethod("Contains", new[] { typeof(string) })!;
                            expression = Expression.Call(property, mi, Expression.Constant(likeValue));
                            break;

                        case FilterTypes.Between:

                            var fromVal = Convert.ChangeType(filter.from, underlyingType);
                            var toVal = Convert.ChangeType(filter.to, underlyingType);

                            // Crear constantes con propertyType
                            var fromConst = Expression.Constant(fromVal, propertyType);
                            var toConst = Expression.Constant(toVal, propertyType);
                            var greaterThanOrEqual = Expression.GreaterThanOrEqual(property, fromConst);
                            var lessThanOrEqual = Expression.LessThanOrEqual(property, toConst);

                            expression = Expression.AndAlso(greaterThanOrEqual, lessThanOrEqual);
                            break;

                        case FilterTypes.Contains:

                            var methodInfoContains = typeof(string).GetMethod("Contains", new[] { typeof(string) })!;

                            expression = Expression.Call(property, methodInfoContains, Expression.Constant(convertedValue?.ToString() ?? ""));
                            break;
                        default:
                            throw new InvalidOperationException($"Unsopported filter type: {filter.type}");
                    }

                    var expressionFn = Expression.Lambda<Func<BookResponse, bool>>(expression, parameter);

                    query = query.Where(expressionFn);
                }

                // Sorting
                foreach (var item in queryObject.Sorts)
                {
                    var parameter = Expression.Parameter(typeof(BookResponse), "b");
                    var property = Expression.Property(Expression.Property(parameter, "Book"), item.propertyName);
                    var expression = Expression.Lambda<Func<BookResponse, object>>(Expression.Convert(property, typeof(object)), parameter);


                    if (item.descending)
                    {
                        query = query.OrderByDescending(expression);
                    }
                    else
                    {
                        query = query.OrderBy(expression);
                    }
                }
            }

            //pagintion
            int total = await query.CountAsync();

            //
            int currentPage = page < 1 ? PaginationConstants.DefaultPage : page;
            int currentLength = pageSize < 1 ? PaginationConstants.DefaultPageSize : pageSize;
            // 
            int skip = (currentPage - 1) * currentLength;
            query = query.Skip(skip).Take(currentLength);
            var data = await query.ToListAsync();

            return new GenericListResponse<BookResponse>
            {
                Total = total,
                Page = page,
                Length = pageSize,
                Data = data
            };
        }

        public async Task<GenericListResponse<BookResponse>> GetUserShelf(int userId, int page, int pageSize)
        {
            var query = _context.UserBooks
     .Where(ub => ub.UserId == userId)
     .Include(ub => ub.ReadingStatus)
     .Include(ub => ub.Book)
         .ThenInclude(b => b.BookGenres)
             .ThenInclude(bg => bg.Genre)
     .Where(ub => !ub.Book.Deleted)
     .Select(ub => new BookResponse
     {
         Book = ub.Book,
         UserBook = ub
     });
            // pagination
            int total = await query.CountAsync();

            //
            int currentPage = page < 1 ? PaginationConstants.DefaultPage : page;
            int currentLength = pageSize < 1 ? PaginationConstants.DefaultPageSize : pageSize;

            //

            int skip = (currentPage - 1) * currentLength;

            query = query.Skip(skip).Take(currentLength);
            var data = await query.ToListAsync();

            return new GenericListResponse<BookResponse>
            {
                Total = total,
                Page = page,
                Length = pageSize,
                Data = data
            };

        }

        public async Task<BookResponse?> Shelve(UserBook userBook)
        {
            _context.UserBooks.Add(userBook);
            await _context.SaveChangesAsync();

            return await GetOne(userBook.UserId, userBook.BookId);
        }

        public async Task<UserBook> UpdateUserBook(UserBook userbook)
        {

            try
            {
                userbook.UpdatedAt = DateTime.UtcNow;
                _context.UserBooks.Update(userbook).Property(ub => ub.UpdatedAt).IsModified = true;
                await _context.SaveChangesAsync();

                return await GetOneUserBook(userbook.UserId, userbook.BookId);
            }
            catch (DbUpdateException ex)
            {

                var innerException = ex.InnerException?.Message;
                Console.WriteLine($"Inner Exception in Create method: {innerException}");
                throw;
            }
        }

        public async Task<UserBook> GetOneUserBook(int userId, int bookId)
        {
            return await _context.UserBooks
                .Include(ub => ub.ReadingStatus)
                .FirstAsync(ub => ub.UserId == userId && ub.BookId == bookId);
        }

        public async Task<bool> RemoveFromShelf(UserBook userBook)
        {
            _context.UserBooks.Remove(userBook);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}

