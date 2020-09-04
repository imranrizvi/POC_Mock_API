using System.Collections.Generic;

namespace Model
{
    public class MockData : MockDataAbstract
    {
        public IEnumerable<SkuInfo> SkuInfos { get; set; }
    }
}
