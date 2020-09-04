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
    //[Microsoft.AspNetCore.Cors.EnableCors("CORSPolicy")]
    public class EsdController : ApiControllerAbstract<EsdInput, IRepository<string, int>>
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
        ///        "OrderDate": "01/01/2020",
        ///        "SkuNumber": "210-ADRL"
        ///     }
        ///
        /// </remarks>
        /// <param name="esdInput"></param>
        //[SwaggerRequestExample(typeof(EsdInput), typeof(EsdInput))]
        [HttpPost]
        [Route("Get")]
        [ProducesResponseType(typeof(EsdOutput), 201)]
        public override IActionResult Get(EsdInput esdInput)
        {
            return Ok(_business.Calculate(esdInput, _skuRepository));
        }
    }
}
