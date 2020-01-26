using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace TradeBot
{
    class Stock
    {
        private readonly string request1 = "quote?symbol=";
        private readonly string request2 = "&token=bol573vrh5rd0m2j1ktg";

        private RestClient client = new RestClient("https://finnhub.io/api/v1/");

        private string quoteRequest = "";

        public Stock(string Ticker)
        {
            quoteRequest = request1 + Ticker + request2;

        }



    }
}
