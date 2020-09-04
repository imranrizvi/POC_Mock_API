using System.ComponentModel.DataAnnotations;
using System;

namespace Model
{
    public class EsdRequest
    {
        public string OrderDate { get; set; }
        public string SkuNumber { get; set; }
    }
}
