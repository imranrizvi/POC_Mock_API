using Microsoft.AspNetCore.Mvc;
using RepositoryFramework;

namespace ApiFramework
{
    public abstract class ApiTestControllerAbstract<ApiInput,Repo> : ControllerBase
       where ApiInput : class
       where Repo : class
    {

        public ApiTestControllerAbstract(Repo repository)
        {

        }

        [HttpGet]
        public abstract IActionResult GetTest(ApiInput input);
    }
}