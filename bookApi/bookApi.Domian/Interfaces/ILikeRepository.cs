using bookApi.Domian.Common;
using bookApi.Domian.Models;

namespace bookApi.Domian.Interfaces
{
    public interface ILikeRepository
    {
        public Task<Like> Create(Like like);
        public Task<bool> Delete(Like like);
        public Task<Like?> GetOne(int reviewId, int userId);
        public Task<GenericListResponse<Like>> GetList(int reviewId, int page, int pageSize);
    }
}
