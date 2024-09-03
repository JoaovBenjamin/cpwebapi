using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;


namespace service
{
    public class ExternalApiService
    {
        private readonly HttpClient _httpClient;

        public ExternalApiService(HttpClient httpClient){
            _httpClient = httpClient;
        }



        public async Task<string> GetAsync(){
            var response = await _httpClient.GetAsync($"https://v6.exchangerate-api.com/v6/8d2b51d86e64e6bca3a0ae45/pair/USD/BRL");
           


              using (HttpClient client = new HttpClient())
        {
            try
            {
                
                HttpResponseMessage message = await client.GetAsync($"https://v6.exchangerate-api.com/v6/8d2b51d86e64e6bca3a0ae45/pair/USD/BRL");

                if (response.IsSuccessStatusCode)
                {
                    // Lê o conteúdo da resposta como string
                    string responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Requisição bem-sucedida!");
                    Console.WriteLine(responseData);
                }
                else
                {
                    Console.WriteLine($"Erro na requisição: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }

             return await response.Content.ReadAsStringAsync();

        }
    }



        }

    
    }

