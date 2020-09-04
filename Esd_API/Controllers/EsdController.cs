using ApiFramework;
using Business;
using Microsoft.AspNetCore.Mvc;
using Model;
using RepositoryFramework;

namespace Esd_API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class EsdController : ApiControllerAbstract<EsdRequest, IRepository<string, int>>
    {
        IRepository<string, int> _skuRepository;
        EsdBusiness _business;
        public EsdController(IRepository<string, int> repository, EsdBusiness business) : base(repository)
        {
            _skuRepository = repository;
            _business = business;
        }

        //Assume ESD = OrderDate + SkuLeadTime


        /// <summary>
        /// Get Estimated Shipping Date
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /get
        ///     {
        ///        "OrderDate": "1/2/2020  12:00:00 AM",
        ///        "SkuNumber": "210-ADRL"
        ///     }
        ///
        /// </remarks>
        /// <param name="esdInput"></param>
        //[SwaggerRequestExample(typeof(EsdInput), typeof(EsdInput))]
        [HttpPost]
        [Route("Get")]
        [ProducesResponseType(typeof(EsdResponse), 201)]
        public override IActionResult Get(EsdRequest esdInput)
        {
            return Ok(_business.Calculate(esdInput, _skuRepository));
        }
    }
}
