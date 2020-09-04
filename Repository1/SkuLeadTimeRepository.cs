using RepositoryFramework;

namespace SqlRepository
{
    public class SkuLeadTimeRepository : IRepository<string, int>
    {
        public int Get(string key)
        {
            return 1;
        }
    }
}
