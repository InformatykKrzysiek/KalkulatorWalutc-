using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RestSharp.Serialization.Json;

namespace KonwerterWalutowy
{
    class ExchangeRatesToArray
    {
        ExchangeRatesApiServices _exchangeRatesApiServices = new ExchangeRatesApiServices();
        public String[] toArray(string day)
        {
            var rates = _exchangeRatesApiServices.GetRates(day);
            if (!rates.IsSuccessful)
            {
                MessageBox.Show("Error!\nSprawdź połączenie z internetem!");
                Application.Current.Shutdown();
            }
            
                var deserializer = new JsonDeserializer();
                var output = deserializer.Deserialize<Dictionary<string, string>>(rates);

                var list = output.Values.ToList();
                var charsToRemove = new char[] {'{', '}', ',', ';', ':', '\"', ' '};

                string[] ratesArray = list[0].Split('\"');

                for (int i = 0; i < ratesArray.Length; i++)
                {
                    ratesArray[i] = ratesArray[i].Trim(charsToRemove);
                }

                ratesArray[0] = list[2];


                return ratesArray;
            
        }
    }
}
