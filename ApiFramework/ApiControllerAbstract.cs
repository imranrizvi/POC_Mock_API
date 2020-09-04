using Microsoft.AspNetCore.Mvc;
using RepositoryFramework;

namespace ApiFramework
{
    public abstract class ApiControllerAbstract<ApiInput,Repo> : ControllerBase
       where ApiInput : class
       where Repo : class
    {

        public ApiControllerAbstract(Repo repository)
        {

        }

        [HttpGet]
        public abstract IActionResult Get(ApiInput input);
    }
}