using bookApi.Domian.Common;

namespace bookApi.Domian.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll(IncludeDelegate<TEntity>? include = null);

        Task<TEntity?> GetOne(int id, IncludeDelegate<TEntity>? include = null);

        Task<TEntity> Create(TEntity body);

        Task<TEntity> Update(TEntity body);

        Task<bool> Delete(TEntity entity);

    }
}
