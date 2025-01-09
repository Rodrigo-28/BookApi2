using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;
using bookApi.Domian.Models;
using System.Linq.Expressions;

namespace bookApi.Application.Interfaces
{
    public interface IGenreService
    {
        public Task<GenreResponseDto?> GetOne(int genreId);
        public Task<Genre> GetOne(Expression<Func<Genre, bool>> predicate);
        Task<IEnumerable<GenreResponseDto>> GetAll();
        Task<GenreResponseDto> Create(CreateGenreDto genreDto);

        //Task<UserResponseDto> Update(int userId, UpdateUserDto genreDto);

        //Task<bool> Delete(int userId);
    }
}
