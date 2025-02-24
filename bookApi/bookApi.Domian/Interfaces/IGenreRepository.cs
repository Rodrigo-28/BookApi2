using bookApi.Domian.Models;
using System.Linq.Expressions;

namespace bookApi.Domian.Interfaces
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        Task<Genre?> GetOne(Expression<Func<Genre, bool>> predicate);
    }
}
