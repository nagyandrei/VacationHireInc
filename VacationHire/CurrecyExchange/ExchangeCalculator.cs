using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

namespace CurrecyExchange
{
    public class ExchangeCalculator
    {
        public double GetCurrencyRate(string currency)
        {
            try
            {
                string URLString = "https://v6.exchangerate-api.com/v6/e27782d2684cd0fdbc8883ea/latest/RON";
                using (var webClient = new System.Net.WebClient())
                {
                    string json = webClient.DownloadString(URLString);
                    ExchangeRatesModel rates = JsonConvert.DeserializeObject<ExchangeRatesModel>(json);
                    PropertyInfo info = typeof(ConversionRate).GetProperty(currency);
                    object value = info.GetValue(rates.conversion_rates,null);
                    return (double)value;
                }
            }
            catch
            {
                throw;
            }
        }

        public double GetConvertedPrice(string currency, double price)
        {
            return GetCurrencyRate(currency) * price;
        }
    }
}
