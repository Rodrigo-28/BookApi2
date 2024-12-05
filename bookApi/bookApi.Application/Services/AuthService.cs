using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;
using bookApi.Application.Exceptions;
using bookApi.Application.Interfaces;
using bookApi.Domian.Interfaces;

namespace bookApi.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IPasswordEncryptionService _passwordEncryptionService;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(IUserService userService, IPasswordEncryptionService passwordEncryptionService, IJwtTokenService jwtTokenService)
        {
            this._userService = userService;
            this._passwordEncryptionService = passwordEncryptionService;
            this._jwtTokenService = jwtTokenService;
        }


        public async Task<LoginResponseDto> Login(LoginRequestDto userDto)
        {
            var user = await _userService.GetOne(u => u.Email == userDto.Email);

            if (user == null)
            {
                throw new BadRequestException("Email invalido")
                {
                    ErrorCode = "001"
                };
            };

            var isValid = _passwordEncryptionService.VerifyPassword(user.Password, userDto.Password);
            if (!isValid)
            {
                throw new BadRequestException("Password invalido")
                {
                    ErrorCode = "002"
                };
            }
            //generate Token
            var token = _jwtTokenService.GenerateJwtToken(user);
            return new LoginResponseDto { Token = token };
        }
    }
}
