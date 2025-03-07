using bookApi.Domian.Common;
using bookApi.Domian.Interfaces;
using bookApi.Domian.Models;
using bookApi.infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace bookApi.infrastructure.Repositories
{
    public class LikeRepository : BaseRepository<Like>, ILikeRepository
    {


        public LikeRepository(ApplicationDbContext context) : base(context)
        {

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
