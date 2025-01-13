using bookApi.Domian.Interfaces;
using bookApi.Domian.Models;
using bookApi.infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace bookApi.infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Review> Create(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;

        }

        public async Task<bool> Delete(Review review)
        {
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Review>> GetBookReviews(int bookId)
        {
            var bookReviews = await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Likes)
                .Where(r => r.BookId == bookId).ToListAsync();
            return bookReviews;
        }

        public async Task<Review?> GetOne(int reviewId)
        {
            var review = await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Likes)
                .FirstOrDefaultAsync(r => r.Id == reviewId);
            return review;
        }

        public async Task<Review?> GetOne(Expression<Func<Review, bool>> predicate)
        {
            return await _context.Reviews.FirstOrDefaultAsync(predicate);

        }
    }
}
