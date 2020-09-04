using System.ComponentModel.DataAnnotations;
using System;

namespace Model
{
    public class EsdInput
    {
        [Required]
        public DateTimeOffset OrderDate;

        [Required]
        public String SkuNumber;
    }
}
