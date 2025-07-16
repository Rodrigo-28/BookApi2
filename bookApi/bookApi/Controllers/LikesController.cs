using bookApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bookApi.Controllers
{

    [ApiController]
    [Route("api/reviews/{reviewId}")]
    public class LikesController : ControllerBase
    {
        private readonly ILikeService _likeService;
        private readonly IUserHelper _userHelper;

        public LikesController(ILikeService likeService, IUserHelper userHelper)
        {
            this._likeService = likeService;
            this._userHelper = userHelper;
        }
        [Authorize(Policy = "AuthenticatedUser")]
        [HttpPost("like")]
        public async Task<IActionResult> Create(int reviewId)
        {
            var userId = _userHelper.GetRequiredUserId(User);

            var likeResponse = await _likeService.Create(reviewId, userId);
            if (likeResponse != null)
            {
                return CreatedAtAction(
                    actionName: nameof(GetOne),
                    routeValues: new { reviewId },
                    value: likeResponse
                );
            }
            //Returns 409
            return Conflict();

        }
        [Authorize(Policy = "AuthenticatedUser")]
        [HttpGet("like/get")]
        public async Task<IActionResult> GetOne(int reviewId)
        {
            var userId = _userHelper.GetRequiredUserId(User);
            var res = await _likeService.GetOne(reviewId, userId);

            return Ok(res);
        }
        [Authorize(Policy = "AuthenticatedUser")]
        [HttpDelete("unlike")]
        public async Task<IActionResult> Delete(int reviewId)
        {
            var userId = _userHelper.GetRequiredUserId(User);
            await _likeService.Delete(reviewId, userId);
            return NoContent();
        }

    }
}
