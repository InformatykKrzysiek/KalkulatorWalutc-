using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace KonwerterWalutowy
{
     class ExchangeRatesApiServices
    {
        private  RestClient client =
            new RestClient("https://api.exchangeratesapi.io/");

        public  IRestResponse GetRates(string day)
        {
            var request = new RestRequest("{day}",Method.GET);

            request.AddUrlSegment("day",day);
            var response = client.Execute(request);
            return response;
        }
    }

}
