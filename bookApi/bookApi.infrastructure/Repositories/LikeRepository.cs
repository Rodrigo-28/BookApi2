using bookApi.Domian.Common;
using bookApi.Domian.Interfaces;
using bookApi.Domian.Models;
using bookApi.infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace bookApi.infrastructure.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ApplicationDbContext _context;

        public LikeRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Like> Create(Like like)
        {
            _context.Likes.Add(like);
            await _context.SaveChangesAsync();
            return like;
        }

        public async Task<bool> Delete(Like like)
        {
            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<GenericListResponse<Like>> GetList(int reviewId, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<Like?> GetOne(int reviewId, int userId)
        {
            var like = await _context.Likes
                  .FirstOrDefaultAsync(l => l.UserId == userId && l.ReviewId == reviewId);
            return like;
        }
    }
}
