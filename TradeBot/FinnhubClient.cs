using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace TradeBot
{
    class FinnhubClient
    {
        private string Ticker = "";
        private string request;
        private RestRequest action;
        private RestClient client = new RestClient("https://finnhub.io/api/v1/");
        
        public FinnhubClient (string Ticker, string request1, string request2)
        {
            request = request1 + Ticker + request2;
            this.Ticker = Ticker;
        }

        public string Execute()
        {
            action = new RestRequest(request, Method.GET);
            string content = client.Execute(action).Content.ToString();

            Console.WriteLine("Quoting " + Ticker);
            return content;
        }

    }
}
