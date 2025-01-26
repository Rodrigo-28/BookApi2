using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;
using bookApi.Domian.Models;
using System.Linq.Expressions;

namespace bookApi.Application.Interfaces
{
    public interface IUserService : IBaseService<User, UserResponseDto, UserResponseDto, CreateUserDto, UpdateUserDto>
    {
        public Task<User?> GetOne(Expression<Func<User, bool>> predicate);
        public Task<UserResponseDto> SignIn(SignInDto signInDto);
        public Task<bool> UpdatePassword(int userId, UpdatePasswordDto updatePasswordDto);
    }
}
