using AutoMapper;
using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;
using bookApi.Application.Exceptions;
using bookApi.Application.Interfaces;
using bookApi.Domian.Interfaces;
using bookApi.Domian.Models;
using System.Linq.Expressions;

namespace bookApi.Application.Services
{
    public class UserService : BaseService<User, UserResponseDto, UserResponseDto, CreateUserDto, UpdateUserDto>, IUserService
    {
        private new readonly IUserRepository _repository;

        private readonly IPasswordEncryptionService _passwordEncryptionService;

        public UserService(IUserRepository _userRepository, IPasswordEncryptionService passwordEncryptionService, IMapper mapper) : base(_userRepository, mapper)
        {
            _repository = _userRepository;

            this._passwordEncryptionService = passwordEncryptionService;
        }
        public async Task<User?> GetOne(Expression<Func<User, bool>> predicate)
        {
            return await _repository.GetOne(predicate);
        }

        public override async Task<UserResponseDto> Create(CreateUserDto body)
        {
            var emailExists = await _repository.GetOne(u => u.Email == body.Email);
            if (emailExists != null)
            {
                throw new BadRequestException($"Email is already taken: {body.Email}")
                {
                    ErrorCode = "006"
                };
            }
            var userNameExist = await _repository.GetOne(u => u.Username == body.Username);

            if (userNameExist != null)
            {
                throw new BadRequestException($"Username is already taken: {body.Email}")
                {
                    ErrorCode = "006"
                };
            }
            body.Password = _passwordEncryptionService.HashPassword(body.Password);

            return await base.Create(body);
        }
        public override async Task<UserResponseDto> Update(int userId, UpdateUserDto body)
        {
            body.Password = _passwordEncryptionService.HashPassword(body.Password);
            return await base.Update(userId, body);
        }

        public async Task<UserResponseDto> SignIn(SignInDto signInDto)
        {
            var emailExists = await _repository.GetOne(u => u.Email == signInDto.Email);
            if (emailExists != null)
            {
                throw new BadRequestException($"Email is already taken: {signInDto.Email}")
                {
                    ErrorCode = "006"
                };
            };

            var userNameExists = await _repository.GetOne(u => u.Username == signInDto.Username);

            if (userNameExists != null)
            {
                throw new BadRequestException($"Username is already taken: {signInDto.Username}")
                {
                    ErrorCode = "006"
                };
            }

            if (signInDto.Password1 != signInDto.Password2)
            {
                throw new BadRequestException($"Passwords do not match")
                {
                    ErrorCode = "006"
                };
            };

            CreateUserDto newUser = new()
            {
                Username = signInDto.Username,
                Email = signInDto.Email,
                Password = _passwordEncryptionService.HashPassword(signInDto.Password1),
                RoleId = 2
            };
            return await base.Create(newUser);
        }

        public async Task<bool> UpdatePassword(int userId, UpdatePasswordDto updatePasswordDto)
        {
            var user = await _repository.GetOne(u => u.Id == userId);
            if (user == null)
            {
                throw new NotFoundException($"User of id {userId} does not exist")
                {
                    ErrorCode = "005"
                };
            };
            if (!_passwordEncryptionService.VerifyPassword(user.Password, updatePasswordDto.CurrentPassword))
            {

                throw new BadRequestException($"Current password does not match")
                {
                    ErrorCode = "005"
                };
            };
            user.Password = _passwordEncryptionService.HashPassword(updatePasswordDto.CurrentPassword);
            user.UpdatedAt = DateTime.UtcNow;
            var updatedUser = await _repository.Update(user);

            return updatedUser != null;

        }
    }
}
