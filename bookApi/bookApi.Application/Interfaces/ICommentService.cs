using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;
using bookApi.Domian.Common;

namespace bookApi.Application.Interfaces
{
    public interface ICommentService
    {
        public Task<CommentResponseDto> Create(int reviewId, int userId, CreateCommentDto commentDto);
        public Task<CommentResponseDto?> GetOne(int reviewId, int commentId);
        public Task<GenericListResponse<CommentResponseDto>> GetList(int reviewId, int page, int pageSize);

        public Task<bool> Delete(int reviewId, int commentId, int userId);
    }
}
