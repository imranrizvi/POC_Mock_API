using RepositoryFramework;

namespace DpeRepositoryFramework
{
    public abstract class SkuLeadTimeRepository : IRepository<string, int>
    {
        public abstract int Get(string key);
    }
}
