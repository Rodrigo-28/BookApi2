using bookApi.Domian.Models;
using System.Linq.Expressions;

namespace bookApi.Domian.Interfaces
{
    public interface IReviewRepository : IBaseRepository<Review>

    {
        Task<Review?> GetOne(int reviewId);
        Task<Review?> GetOne(Expression<Func<Review, bool>> predicate);

        public Task<IEnumerable<Review>> GetBookReviews(int bookId);

    }
}
