using bookApi.Domian.Interfaces;
using bookApi.Domian.Models;
using bookApi.infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace bookApi.infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {


        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<User?> GetOne(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.FirstOrDefaultAsync(predicate);

        }
    }
}
