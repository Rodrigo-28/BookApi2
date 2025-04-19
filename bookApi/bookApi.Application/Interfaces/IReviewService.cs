using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;
using bookApi.Domian.Models;

namespace bookApi.Application.Interfaces
{
    public interface IReviewService : IBaseService<Review, CreateReviewResponseDto, ReviewResponseDto, CreateReviewDto, UpdateReviewDto>
    {
        public Task<IEnumerable<ReviewResponseDto>> GetBookReviews(int bookId);

        public Task<GenericResponseDto> Delete(int userId, int reviewId);
        public Task<CreateReviewResponseDto> Update(int userId, int reviewId, UpdateReviewDto body);

    }
}
