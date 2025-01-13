using bookApi.Domian.Models;
using System.Linq.Expressions;

namespace bookApi.Domian.Interfaces
{
    public interface IReviewRepository
    {
        public Task<Review> Create(Review review);
        public Task<Review?> GetOne(int reviewId);
        public Task<Review?> GetOne(Expression<Func<Review, bool>> predicate);
        public Task<IEnumerable<Review>> GetBookReviews(int bookId);
        public Task<bool> Delete(Review review);
    }
}
