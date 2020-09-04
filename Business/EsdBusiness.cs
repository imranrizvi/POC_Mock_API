using Model;
using RepositoryFramework;
using System;

namespace Business
{
    public class EsdBusiness 
    {
        public EsdResponse Calculate(EsdRequest request, IRepository<string,int> skuRepository)
        {
            var leadTime = skuRepository.Get(request.SkuNumber);
            
            return new EsdResponse() { ESD = DateTime.Parse(request.OrderDate).AddDays(leadTime).ToString() };
        }
    }
}
