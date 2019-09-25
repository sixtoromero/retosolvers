using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechAndSolve.LazyLoad.WebAPIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LazyLoadingController : ControllerBase
    {
        [HttpGet("{path}/{document}")]
        public ActionResult<IEnumerable<string>> Get(string path, string document)
        {
            return new string[] { "value1", "value2" };
        }
    }
}