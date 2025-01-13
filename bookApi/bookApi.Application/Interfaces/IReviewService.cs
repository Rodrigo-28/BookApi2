using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;

namespace bookApi.Application.Interfaces
{
    public interface IReviewService
    {
        public Task<CreateReviewResponseDto> Create(CreateReviewDto reviewDto, int userId);

        public Task<ReviewResponseDto?> GetOne(int reviewId);

        public Task<IEnumerable<ReviewResponseDto>> GetBookReviews(int bookId);

        public Task<bool> Delete(int userId, int reviewId);
    }
}
