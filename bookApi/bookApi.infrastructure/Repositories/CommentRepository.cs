using bookApi.Domian.Common;
using bookApi.Domian.Interfaces;
using bookApi.Domian.Models;
using bookApi.infrastructure.Contexts;
using bookApi.infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace bookApi.infrastructure.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {


        public CommentRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Comment> CreateComment(Comment comment)
        {
            await base.Create(comment);


            var createdComment = await base.GetOne(comment.Id, query => query.Include(c => c.User));

            return createdComment;
        }

        public async Task<GenericListResponse<Comment>> GetList(int reviewId, int page, int pageSize)
        {
            var query = _context.Comments
                .Include(c => c.User)
                .Where(c => c.ReviewId == reviewId);

            //pag
            int total = await query.CountAsync();

            int currentPage = page < 1 ? PaginationConstants.DefaultPage : page;
            int currentLength = pageSize < 1 ? PaginationConstants.DefaultPageSize : pageSize;

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

        public async Task<Comment?> GetOne(int reviewId, int commentId)
        {
            return await base.GetOne(commentId, query =>
            query.Include(c => c.User)
            .Where(c => c.ReviewId == reviewId));
        }
    }
}
