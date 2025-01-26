using bookApi.Application.Dtos.Request;
using bookApi.Application.Exceptions;
using bookApi.Application.Interfaces;
using bookApi.Helpers;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;

        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOne(int userId)
        {
            var user = await _userService.GetOne(userId);
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto createUserDto, IValidator<CreateUserDto> validator)
        {
            var validationResult = await validator.ValidateAsync(createUserDto);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException(validationResult.ToString())
                {
                    ErrorCode = "004"
                };
            }

            var user = await _userService.Create(createUserDto);
            return Ok(user);
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto signInDto, IValidator<SignInDto> validator)
        {
            var validationResults = await validator.ValidateAsync(signInDto);

            if (!validationResults.IsValid)
            {
                throw new BadRequestException(validationResults.ToString())
                {
                    ErrorCode = "004"
                };
            }
            var user = await _userService.SignIn(signInDto);

            ////Returns 201
            if (user != null)
            {
                //return CreatedAtAction(
                //    actionName: nameof(GetOne), // The action that retrieves the created resource
                //    routeValues: new { userId = user.Id }, // Route values to populate the URL for the location header
                //    value: user
                //);
                return Ok(user);
            }
            ////Returns 409
            return Conflict();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{userId}")]

        public async Task<IActionResult> Update(int userId, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = await _userService.Update(userId, updateUserDto);
            return Ok(user);
        }
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var userDeleted = await _userService.Delete(userId);
            return Ok(userDeleted);
        }
        [HttpPut("updatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordDto updatePasswordDto, IValidator<UpdatePasswordDto> validator)
        {
            int userId = UserHelper.GetRequiredUserId(User);
            var validationResults = await validator.ValidateAsync(updatePasswordDto);

            if (!validationResults.IsValid)
            {
                throw new BadRequestException(validationResults.ToString())
                {
                    ErrorCode = "004"
                };
            }
            var isPasswordUpdated = await _userService.UpdatePassword(userId, updatePasswordDto);

            if (isPasswordUpdated)
            {
                return Ok("Password updated successfully");
            };
            return Conflict("Failed to update password");
        }
    }
}
