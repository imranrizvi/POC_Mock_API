namespace RepositoryFramework
{
    public interface IRepository<TKey, TEntity>
    {
        TEntity Get(TKey key);
    }
}
