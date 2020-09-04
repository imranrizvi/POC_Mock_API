using ApiFramework;
using Business;
using Microsoft.AspNetCore.Mvc;
using Model;
using Moq;
using Newtonsoft.Json.Linq;
using RepositoryFramework;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Esd_API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    //[Microsoft.AspNetCore.Cors.EnableCors("CORSPolicy")]
    public class EsdControllerTest : ApiTestControllerAbstract<EsdRequestWithMock, IRepository<string, int>>
    {
        Mock<IRepository<string, int>> _skuRepository;
        EsdBusiness _business;
        public EsdControllerTest(IRepository<string, int> repository, EsdBusiness business) : base(repository)
        {
            _skuRepository = new Mock<IRepository<string, int>>();
            _business = business;
        }

        //Assume ESD = OrderDate + SkuLeadTime


        /// <summary>
        /// Get Estimated Shipping Date
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///POST /get
        ///{
        ///   "OrderDate": "1/2/2020  12:00:00 AM",
        ///   "SkuNumber": "210-ADRL",
        ///   "AutomationTesting": {
        ///     "EnableMockTesting": true,
        ///     "MockData": {
        ///       "SkuInfos": [
        ///         {
        ///         "SkuNumber":"210-ADRL",
        ///         "LeadTime": 2
        ///         }
        ///       ]
        ///     },
        ///     "ExpectedOutput": {
        ///       "FieldAndExpectedValue": [
        ///         {
        ///           "Field": "$.ESD",
        ///           "ExpectedValue": "1/3/2020  12:00:00 AM"
        ///         }
        ///       ],
        ///       "Result": true
        ///     }
        ///   }
        /// }
        ///
        /// </remarks>
        /// <param name="request"></param>
        //[SwaggerRequestExample(typeof(EsdInput), typeof(EsdInput))]
        [HttpPost]
        [Route("Get")]
        [ProducesResponseType(typeof(EsdResponse), 201)]
        public override IActionResult GetTest(EsdRequestWithMock request)
        {
            var result = _business.Calculate(request, GetMockObject(_skuRepository, request));

            EsdResponseWithMock response = new EsdResponseWithMock() { ESD = result.ESD };
            response.Result = GetIfExpectationMet(request, response);
            return Ok(response);
        }

        private bool GetIfExpectationMet(EsdRequestWithMock request, EsdResponseWithMock response)
        {
            bool result = true;
            foreach (var a in request.AutomationTesting.ExpectedOutput.FieldAndExpectedValue)
            {
                var responseObject = JObject.FromObject(response);
                var output = responseObject.SelectToken(a.Field).ToString();
                if (output != a.ExpectedValue)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }


        private IRepository<string, int> GetMockObject(Mock<IRepository<string, int>> repo, EsdRequestWithMock input)
        {
            repo.Setup(x => x.Get(input.SkuNumber)).Returns(input.AutomationTesting.MockData.SkuInfos.FirstOrDefault(x => x.SkuNumber == input.SkuNumber).LeadTime);
            return repo.Object;
        }
    }
}
