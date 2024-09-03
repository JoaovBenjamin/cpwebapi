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
        // Obtendo a resposta da API externa como uma string
        var jsonResponse = await _externalApiService.GetAsync();

        // Parsing da string JSON para um objeto JObject
        var jsonObject = JObject.Parse(jsonResponse);

        // Extraindo o valor da propriedade "conversion_rate" diretamente como string
        var conversionRateString = jsonObject["conversion_rate"].ToString();
        
        // Verificando se "conversionRateString" é um número (float ou double)
        if (double.TryParse(conversionRateString, out double conversionRate))
        {
            // Criando o resultado com apenas a taxa de conversão
            var result = new JsonResult(new { ConversionRate = conversionRate });
            return result;
        }
        else
        {
            throw new Exception("O valor de 'conversion_rate' não é um número válido.");
        }
    }
    catch (Exception ex)
    {
        return new JsonResult(new { Error = ex.Message }) { StatusCode = 400 }; // Definindo o StatusCode para 400 (BadRequest)
    }
    
    }
}
    }
