using bookApi.Domian.Common;
using bookApi.Domian.Models;

namespace bookApi.Domian.Interfaces
{
    public interface ILikeRepository : IBaseRepository<Like>
    {
        public Task<Like?> GetOne(int reviewId, int userId);
        public Task<GenericListResponse<Like>> GetList(int reviewId, int page, int pageSize);

    }
}
