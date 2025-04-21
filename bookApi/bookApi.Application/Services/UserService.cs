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

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordEncryptionService _passwordEncryptionService;

        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordEncryptionService passwordEncryptionService)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
            this._passwordEncryptionService = passwordEncryptionService;
        }
        public async Task<UserResponseDto> Create(CreateUserDto createUserDto)
        {
            var userExist = await _userRepository.GetOne(u => u.Email == createUserDto.Email);
            if (userExist != null)
            {
                throw new BadRequestException($"Already exist an user with this email {createUserDto.Email}")
                {
                    ErrorCode = "006"
                };
            }
            var newUser = _mapper.Map<User>(createUserDto);
            newUser.Password = _passwordEncryptionService.HashPassword(createUserDto.Password);

            var user = await _userRepository.Create(newUser);
            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<GenericResponseDto> Delete(int userId)
        {
            var user = await _userRepository.GetOne(userId);
            if (user == null)
            {
                throw new NotFoundException($"user of id {userId} does not exist ")
                {
                    ErrorCode = "005"
                };
            }
            await _userRepository.Delete(user);
            return new GenericResponseDto { Success = true };
        }

        public async Task<IEnumerable<UserResponseDto>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<UserResponseDto>>(users);
        }

        public async Task<UserResponseDto> GetOne(int userId)
        {
            var user = await _userRepository.GetOne(userId);
            if (user == null)
            {
                throw new NotFoundException($"user of id {userId} does not exist ")
                {
                    ErrorCode = "005"
                };
            }
            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<User> GetOne(Expression<Func<User, bool>> predicate)
        {
            var user = await _userRepository.GetOne(predicate);
            if (user == null)
            {
                throw new NotFoundException()
                {
                    ErrorCode = "004"
                };
            }
            return user;
        }

        public async Task<UserResponseDto> Update(int userId, UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.GetOne(userId);
            if (user == null)
            {
                throw new NotFoundException($"user of id {userId} does not exist ")
                {
                    ErrorCode = "005"
                };
            }
            updateUserDto.Password = _passwordEncryptionService.HashPassword(updateUserDto.Password);
            var updateUser = _mapper.Map(updateUserDto, user);
            await _userRepository.Update(updateUser);
            return _mapper.Map<UserResponseDto>(updateUser);


        }
    }
}
