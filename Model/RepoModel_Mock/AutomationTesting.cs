using System;

namespace Model
{
    public class AutomationTesting : AutomationTestingBase
    {
        public MockData MockData { get; set; }
        public ExpectationsAbstract Expectations { get; set; }
    }
}
