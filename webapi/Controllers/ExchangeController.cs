using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using service;
using webapi.models;

namespace webapi.Controllers
{

     public interface IExchangeController
    {  
         JsonResult GetExchangeRate();
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController: Controller, IExchangeController
    {
        private readonly ExternalApiService _externalApiService;

        public ExchangeController(ExternalApiService externalApiService){
            _externalApiService = externalApiService;
        }

         public JsonResult GetExchangeRate()
        {
            var exchangeRate = new
            {
                CurrencyPair = "USD/BRL",
                Rate = 5.25, 
                Date = DateTime.Now
            };

            return Json(exchangeRate);
        }

        public ExternalApiService Get_externalApiService()
        {
            return _externalApiService;
        }

        [HttpGet("GetExternalExchangeRate")]
        public async Task<IActionResult> GetExternalExchangeRate()
        {
            var data = await _externalApiService.GetAsync();
            return Ok(data);
        }
    }
}