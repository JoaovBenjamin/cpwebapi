using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using service;
using webapi.models;
using Swashbuckle.AspNetCore;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Swashbuckle.AspNetCore.Annotations;

namespace webapi.Controllers
{

     public interface IExchangeController
    {  
         Task<JsonResult> GetExchangeRate(string toCurrency, string FromCurrency);
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
        [Tags("Conversor de moedas")]
        [ProducesResponseType(typeof(ConversionRate), 200)]
        [ProducesResponseType(404)]
      public async Task<JsonResult> GetExchangeRate(string toCurrency, string FromCurrency)
{
        try
    {
        var jsonResponse = await _externalApiService.GetAsync( toCurrency,  FromCurrency);

        var jsonObject = JObject.Parse(jsonResponse);

        var conversionRateString = jsonObject["conversion_rate"].ToString();
        
        if (double.TryParse(conversionRateString, out double conversionRate))
        {
            var result = new JsonResult(new { ConversionRate = conversionRate, toCurrency = toCurrency, FromCurrency = FromCurrency });
            return result;
        }
        else
        {
            throw new Exception("O valor de 'conversion_rate' não é um número válido.");
        }
    }
    catch (Exception ex)
    {
        return new JsonResult(new { Error = ex.Message }) { StatusCode = 400 }; 
    }
    
    }
}
    }
