using Model;
using RepositoryFramework;
using System;

namespace Business
{
    public class EsdBusiness 
    {
        public EsdOutput Calculate(EsdInput input, IRepository<string,int> skuRepository)
        {
            var leadTime = skuRepository.Get(input.SkuNumber);
            return new EsdOutput() { ESD = input.OrderDate.AddDays(leadTime) };
        }
    }
}
