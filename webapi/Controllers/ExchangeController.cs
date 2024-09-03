using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using service;
using webapi.models;
using Swashbuckle.AspNetCore;

namespace webapi.Controllers
{

     public interface IExchangeController
    {  
         Task<JsonResult> GetExchangeRate();
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController: Controller, IExchangeController
    {
        private readonly ExternalApiService _externalApiService;

        public ExchangeController(ExternalApiService externalApiService){
            _externalApiService = externalApiService;
        }

        [HttpGet("GetExchangeRate")]
      public async Task<JsonResult> GetExchangeRate()
{
    try
    {
        var rate = await _externalApiService.GetAsync();
        var result = new JsonResult(new { conversion_rate = rate });
        return result; // Retornando diretamente o JsonResult
    }
    catch (Exception ex)
    {
        return new JsonResult(new { Error = ex.Message }) { StatusCode = 400 }; // Definindo o StatusCode para 400 (BadRequest)
    }
}
    }
}