using bookApi.Application.Dtos.Request;
using bookApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto userDto)
        {
            var token = await _authService.Login(userDto);
            return Ok(token);
        }
    }
}
