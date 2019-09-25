using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechAndSolve.LazyLoad.Common.Clases.Helpers;
using TechAndSolve.LazyLoad.Domain.Services.Bag;
using TechAndSolve.LazyLoad.Domain.Services.DataFile;
using TechAndSolve.LazyLoad.Domain.Services.Process;

namespace TechAndSolve.LazyLoad.WebAPIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LazyLoadingController : ControllerBase
    {
        [HttpGet("{path}/{document}")]
        public ActionResult<IEnumerable<string>> Get(string path, string document)
        {
            try
            {
                string uripath = @"D:\techandsolve\TechAndSolve.LazyLoad\Recursos\" + path;

                DataFile iData = new DataFile(uripath);
                var resultData = iData.GetResult();
                Bag iBag = new Bag(resultData);
                var resultBag = iBag.BagTravels();
                ProcessLazy iProcess = new ProcessLazy(resultBag);
                var result = iProcess.GetResult();
                FileHelper.setFile(@"D:\techandsolve\TechAndSolve.LazyLoad\Recursos\lazy_loading_output.txt", result, document);

                return Ok("Archivo creado exitosamente");
            }
            catch (Exception)
            {
                return BadRequest("Error al crear el archivo");
                throw;
            }
            
        }
    }
}