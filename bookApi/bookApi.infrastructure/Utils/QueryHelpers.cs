using bookApi.Domian.Common;
using bookApi.Domian.Models;
using System.Linq.Expressions;

namespace bookApi.infrastructure.Utils
{
    public static class QueryHelpers
    {

        public static IQueryable<BookResponse> ApplyFilters(IQueryable<BookResponse> query, QueryObject queryObject)
        {
            if (queryObject != null && !string.IsNullOrEmpty(queryObject.Search))
            {
                var containsValue = queryObject.Search.ToLower();

                query = query.Where(b => b.Book.Title.ToLower().Contains(containsValue) ||
                    b.Book.Author.ToLower().Contains(containsValue) ||
                    (b.Book.Description != null && b.Book.Description.ToLower().Contains(containsValue))

                );
            }

            foreach (var filter in queryObject.Filters)
            {
                var parameter = Expression.Parameter(typeof(BookResponse), "b");
                var property = Expression.Property(Expression.Property(parameter, "book"), filter.propertyName);

                Expression? expression;

                var propertyType = property.Type;

                var value = (propertyType == typeof(string)) ? filter.value : Convert.ChangeType(filter.value, propertyType);

                switch (filter.type)
                {
                    case FilterTypes.Equals:
                        expression = Expression.Equal(property, Expression.Constant(value));
                        break;
                    case FilterTypes.NotEquals:
                        expression = Expression.NotEqual(property, Expression.Constant(value));
                        break;
                    case FilterTypes.GreaterThan:
                        expression = Expression.GreaterThan(property, Expression.Constant(value));
                        break;
                    case FilterTypes.LowerThan:
                        expression = Expression.LessThan(property, Expression.Constant(value));
                        break;
                    case FilterTypes.GreaterThanEquals:
                        expression = Expression.GreaterThanOrEqual(property, Expression.Constant(value));
                        break;
                    case FilterTypes.LowerThanEquals:
                        expression = Expression.LessThanOrEqual(property, Expression.Constant(value));
                        break;
                    case FilterTypes.Like:
                        var likeValue = $"%{value}%";
                        var methodInfo = typeof(string).GetMethod("Contains", new[] { typeof(string) })!;
                        expression = Expression.Call(property, methodInfo, Expression.Constant(likeValue));
                        break;

                    case FilterTypes.Between:

                        var fromValue = (propertyType == typeof(string)) ? filter.from : Convert.ChangeType(filter.from, propertyType);
                        var toValue = (propertyType == typeof(string)) ? filter.to : Convert.ChangeType(filter.to, propertyType);


                        var greaterThanOrEqual = Expression.GreaterThanOrEqual(property, Expression.Constant(fromValue));
                        var lessThanOrEqual = Expression.LessThanOrEqual(property, Expression.Constant(toValue));

                        expression = Expression.AndAlso(greaterThanOrEqual, lessThanOrEqual);
                        break;

                    case FilterTypes.Contains:

                        var methodInfoContains = typeof(string).GetMethod("Contains", new[] { typeof(string) })!;

                        expression = Expression.Call(property, methodInfoContains, Expression.Constant(value?.ToString() ?? ""));
                        break;
                    default:
                        throw new InvalidOperationException($"Unsopported filter type: {filter.type}");
                }

                var expressionFn = Expression.Lambda<Func<BookResponse, bool>>(expression, parameter);
                query = query.Where(expressionFn);

            }
            return query;
        }

        public static IQueryable<BookResponse> ApplySorting(IQueryable<BookResponse> query, List<SortOption> sorts)
        {
            foreach (var item in sorts)
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
            return query;
        }



        public static (IQueryable<BookResponse> Query, int total) ApplyPagination(IQueryable<BookResponse> query, int page, int pageSize)
        {
            int total = query.Count();

            //
            int currentPage = page < 1 ? PaginationConstants.DefaultPage : page;
            int currentLength = pageSize < 1 ? PaginationConstants.DefaultPageSize : pageSize;
            //
            int skip = (currentPage - 1) * currentLength;

            return (query.Skip(skip).Take(currentLength), total);
        }
    }
}
