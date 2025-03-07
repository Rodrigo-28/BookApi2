using bookApi.Domian.Common;
using bookApi.Domian.Models;

namespace bookApi.Domian.Interfaces
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        //public Task<Comment> Create(Comment comment);
        //public Task<Comment?> GetOne(int reviewId, int commentId);

        //public Task<GenericListResponse<Comment>> GetList(int reviewId, int page, int pageSize);

        //public Task<bool> Delete(Comment comment);

        Task<Comment> CreateComment(Comment book);
        Task<Comment?> GetOne(int reviewId, int commentId);
        Task<GenericListResponse<Comment>> GetList(int reviewId, int page, int pageSize);

        public Task<bool> Delete(Comment comment);
    }
}
