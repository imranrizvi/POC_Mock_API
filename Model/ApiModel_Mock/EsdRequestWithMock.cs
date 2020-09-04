using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class EsdRequestWithMock : EsdRequest
    {
        public AutomationTesting AutomationTesting { get; set; }
    }
}
