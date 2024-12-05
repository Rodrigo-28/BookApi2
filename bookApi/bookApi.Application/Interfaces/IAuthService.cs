using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;

namespace bookApi.Application.Interfaces
{
    public interface IAuthService
    {
        public Task<LoginResponseDto> Login(LoginRequestDto userDto);

    }
}
