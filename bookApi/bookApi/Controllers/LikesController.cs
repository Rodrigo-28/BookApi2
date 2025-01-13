using bookApi.Application.Interfaces;

using bookApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bookApi.Controllers
{

    [ApiController]
    [Route("api/reviews/{reviewId}")]
    public class LikesController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikesController(ILikeService likeService)
        {
            this._likeService = likeService;
        }
        [Authorize(Policy = "AuthenticatedUser")]
        [HttpPost("like")]
        public async Task<IActionResult> Create(int reviewId)
        {
            var userId = UserHelper.GetRequiredUserId(User);

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
            var userId = UserHelper.GetRequiredUserId(User);
            var res = await _likeService.GetOne(reviewId, userId);

            return Ok(res);
        }
        [Authorize(Policy = "AuthenticatedUser")]
        [HttpDelete("unlike")]
        public async Task<IActionResult> Delete(int reviewId)
        {
            var userId = UserHelper.GetRequiredUserId(User);
            await _likeService.Delete(reviewId, userId);
            return NoContent();
        }

    }
}
