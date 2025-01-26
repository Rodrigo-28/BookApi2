using bookApi.Domian.Models;
using System.Linq.Expressions;

namespace bookApi.Domian.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {

        Task<User?> GetOne(Expression<Func<User, bool>> predicate);

    }
}
