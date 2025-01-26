using bookApi.Application.Dtos.Responses;
using bookApi.Domian.Common;

namespace bookApi.Application.Interfaces
{
    public interface IBaseService<TEntity, TResponseDto, TResponseDetail, TCreateDto, TUpdateDto>

    {
        Task<IEnumerable<TResponseDto>> GetAll();
        Task<GenericListResponse<TResponseDto>> GetList(int page, int pageSize, string? query);
        Task<TResponseDto> Create(TCreateDto body);
        Task<TResponseDto> Update(int id, TUpdateDto body);
        Task<TResponseDetail?> GetOne(int id);
        Task<GenericResponseDto> Delete(int id);
    }
}
