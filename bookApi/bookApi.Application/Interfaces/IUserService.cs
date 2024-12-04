using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;
using bookApi.Domian.Models;
using System.Linq.Expressions;

namespace bookApi.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetAll();
        Task<UserResponseDto> GetOne(int userId);
        Task<UserResponseDto> Create(CreateUserDto createUserDto);

        Task<UserResponseDto> Update(int userId, UpdateUserDto updateUserDto);
        Task<GenericResponseDto> Delete(int userId);
        Task<User> GetOne(Expression<Func<User, bool>> predicate);
    }
}
