using bookApi.Application.Dtos.Request;
using bookApi.Application.Interfaces;
using bookApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            this._reviewService = reviewService;
        }
        [Authorize(Policy = "AuthenticatedUser")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReviewDto reviewDto)
        {
            var userId = UserHelper.GetRequiredUserId(User);
            var reviewResponse = await _reviewService.Create(reviewDto, userId);
            if (reviewResponse != null)
            {
                return CreatedAtAction(
                    actionName: nameof(GetOne), // The action that retrieves the created resource
                    routeValues: new { reviewId = reviewResponse.Id }, // Route values to populate the URL for the location header
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
            var userId = UserHelper.GetRequiredUserId(User);
            var res = await _reviewService.Delete(userId, reviewId);
            return Ok(res);
        }

    }
}
