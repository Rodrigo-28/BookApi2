using bookApi.Domian.Interfaces;
using bookApi.Domian.Models;
using bookApi.infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace bookApi.infrastructure.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {


        public GenreRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Genre?> GetOne(Expression<Func<Genre, bool>> predicate)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(predicate);
            return genre;
        }
    }
}
