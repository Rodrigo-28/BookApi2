using AutoMapper;
using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;
using bookApi.Application.Exceptions;
using bookApi.Application.Interfaces;
using bookApi.Domian.Common;
using bookApi.Domian.Interfaces;
using bookApi.Domian.Models;

namespace bookApi.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IReviewRepository reviewRepository, IReviewService reviewService, IMapper mapper)
        {
            this._commentRepository = commentRepository;
            this._reviewRepository = reviewRepository;
            this._reviewService = reviewService;
            this._mapper = mapper;
        }
        public async Task<CommentResponseDto> Create(int reviewId, int userId, CreateCommentDto commentDto)
        {
            var review = await _reviewService.GetOne(reviewId);

            if (review == null)
            {
                throw new NotFoundException($"Review with id {reviewId} does not exist")
                {
                    ErrorCode = "003"
                };
            }
            Comment newComment = new Comment
            {
                ReviewId = reviewId,
                UserId = userId,
                Content = commentDto.Content,
            };

            var createdComment = await _commentRepository.Create(newComment);

            return _mapper.Map<CommentResponseDto>(createdComment);

        }

        public async Task<bool> Delete(int reviewId, int commentId, int userId)
        {
            var comment = await _commentRepository.GetOne(reviewId, commentId);

            if (comment == null)
            {
                throw new NotFoundException("Comment does not exist")
                {
                    ErrorCode = "004"
                };
            }

            if (comment.UserId != userId)
            {
                throw new UnauthorizedException("Cannot delete another user's comment")
                {
                    ErrorCode = "008"
                };
            }
            await _commentRepository.Delete(comment);

            return true;
        }

        public async Task<GenericListResponse<CommentResponseDto>> GetList(int reviewId, int page, int pageSize)
        {
            var comment = await _commentRepository.GetList(reviewId, page, pageSize);
            return _mapper.Map<GenericListResponse<CommentResponseDto>>(comment);
        }

        public async Task<CommentResponseDto?> GetOne(int reviewId, int commentId)
        {
            var comment = await _commentRepository.GetOne(reviewId, commentId);

            return _mapper.Map<CommentResponseDto>(comment);
        }
    }
}
