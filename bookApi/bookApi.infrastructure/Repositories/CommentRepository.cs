using bookApi.Domian.Common;
using bookApi.Domian.Interfaces;
using bookApi.Domian.Models;
using bookApi.infrastructure.Contexts;
using bookApi.infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace bookApi.infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            this._context = context;
        }


        public async Task<Comment?> Create(Comment comment)
        {

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return await _context.Comments
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == comment.Id);

        }

        public async Task<bool> Delete(Comment comment)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<GenericListResponse<Comment>> GetList(int reviewId, int page, int pageSize)
        {
            var query = _context.Comments
                .Include(c => c.User)
                .Where(c => c.ReviewId == reviewId);

            int total = await query.CountAsync();
            //
            int currentPage = page < 1 ? PaginationConstants.DefaultPage : page;
            int currentLength = pageSize < 1 ? PaginationConstants.DefaultPageSize : pageSize;
            //
            int skip = (currentPage - 1) * currentLength;
            query = query.Skip(skip).Take(currentLength);
            var data = await query.ToListAsync();


            return new GenericListResponse<Comment>
            {
                Total = total,
                Page = page,
                Length = pageSize,
                Data = data
            };
        }

        public Task<Comment?> GetOne(int reviewId, int commentId)
        {
            var comment = _context.Comments.
                Include(c => c.User)
                .FirstOrDefaultAsync(c => c.ReviewId == reviewId && c.Id == commentId);
            return comment;
        }
    }
}
