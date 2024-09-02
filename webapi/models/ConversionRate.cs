using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Import;

namespace webapi.models
{

     public interface IConversionRate
    {
        double BRL {get;set;}
    }
    


    public class ConversionRate : IConversionRate
    {
        public double BRL { get; set;}

    }

     public static bool Import()
     {
            try
                {
                String URLString = "https://v6.exchangerate-api.com/v6/8d2b51d86e64e6bca3a0ae45/latest/USD";
                using (var webClient = new System.Net.WebClient())
                    {
                    var json = webClient.DownloadString(URLString);
                    API_Obj Test = JsonConvert.DeserializeObject<API_Obj>(json);
                    return true;
                    }
                }
            catch (Exception)
                {
                return false;
                }
            }
        }

    public class API_Obj
        {
        public string result { get; set; }
        public string documentation { get; set; }
        public string terms_of_use { get; set; }
        public string time_last_update_unix { get; set; }
        public string time_last_update_utc { get; set; }
        public string time_next_update_unix { get; set; }
        public string time_next_update_utc { get; set; }
        public string base_code { get; set; }
        
}