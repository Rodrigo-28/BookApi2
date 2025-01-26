namespace bookApi.Domian.Common
{
    public delegate IQueryable<TEntity> IncludeDelegate<TEntity>(IQueryable<TEntity> query);


}
