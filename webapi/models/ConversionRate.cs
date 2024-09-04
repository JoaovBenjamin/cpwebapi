using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

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


        
}