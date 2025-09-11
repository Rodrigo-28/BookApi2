using bookApi.Application.Dtos.Request;
using bookApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IUserHelper _userHelper;

        public ReviewsController(IReviewService reviewService, IUserHelper userHelper)
        {
            this._reviewService = reviewService;
            this._userHelper = userHelper;
        }
        [Authorize(Policy = "AuthenticatedUser")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReviewDto reviewDto)
        {
            var userId = _userHelper.GetRequiredUserId(User);
            var reviewResponse = await _reviewService.Create(reviewDto, userId);
            if (reviewResponse != null)
            {
                return CreatedAtAction(
                    actionName: nameof(GetOne),
                    routeValues: new { reviewId = reviewResponse.Id },
                    value: reviewResponse
                );
            }
            //Returns 409
            return Conflict();
        }

        [HttpGet("show/{reviewId}")]
        public async Task<IActionResult> GetOne(int reviewId)
        {
            var res = await _reviewService.GetOne(reviewId);

            return Ok(res);
        }
        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetBookReviews(int bookId)
        {
            var res = await _reviewService.GetBookReviews(bookId);
            return Ok(res);
        }
        [HttpDelete("{reviewId}/delete")]
        public async Task<IActionResult> DeleteRevie(int reviewId)
        {
            var userId = _userHelper.GetRequiredUserId(User);
            var res = await _reviewService.Delete(userId, reviewId);
            return Ok(res);
        }

    }
}
