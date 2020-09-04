using System;

namespace Model
{
    public class AutomationTesting : AutomationTestingBase
    {
        public MockData MockData { get; set; }
        public ExpectedOutputAbstract ExpectedOutput { get; set; }
    }
}
