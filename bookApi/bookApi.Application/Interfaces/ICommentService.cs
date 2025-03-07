using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;
using bookApi.Domian.Common;
using bookApi.Domian.Models;

namespace bookApi.Application.Interfaces
{
    public interface ICommentService : IBaseService<Comment, CommentDto, CommentResponseDto, CreateCommentDto, UpdateCommentDto>
    {
        public Task<CommentResponseDto> Create(int reviewId, int userId, CreateCommentDto commentDto);

        public Task<CommentResponseDto?> GetOne(int reviewId, int commentId);
        public Task<GenericListResponse<CommentResponseDto>> GetList(int reviewId, int page, int pageSize);
        public Task<GenericResponseDto> Delete(int reviewId, int commentId, int userId);

    }
}
