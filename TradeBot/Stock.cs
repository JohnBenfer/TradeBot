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
        private readonly string request1 = "quote?symbol=";                         // request first half
        private readonly string request2 = "&token=bol573vrh5rd0m2j1ktg";           // request second half

        public string Ticker;

        private int shareCount;

        private RestClient client = new RestClient("https://finnhub.io/api/v1/");   // base url

        private string quoteRequest = "";

        private RestRequest request;

        public int ShareCount { 
            get => shareCount; 
            set => shareCount = value; 
        }

        public Stock(string Ticker)
        {
            quoteRequest = request1 + Ticker + request2;
            this.Ticker = Ticker;
            request = new RestRequest(quoteRequest, Method.GET);
        }

        public double Buy()
        {
            double purchasePrice = GetCurrentPrice();
            ShareCount++;
            Console.WriteLine(Ticker + " share purchased for $" + purchasePrice);
            PrintShares();
            return purchasePrice;
        }

        public void PrintShares()
        {
            Console.WriteLine(ShareCount + " " + Ticker + " shares available.");
        }

        public void PrintCurrentPrice()
        {
            Console.WriteLine(GetCurrentPrice());
        }

        public double Sell()
        {
            double sellPrice = GetCurrentPrice();
            ShareCount--;
            Console.WriteLine(Ticker + " share sold for $" + sellPrice);
            PrintShares();
            return sellPrice;
        }

        private double GetCurrentPrice()
        {
            return ExtractPrice(client.Execute(request).Content.ToString());
        }

        private double ExtractPrice(string contents)
        {
            string temp = contents.Substring(5, contents.Length-5);
            string price = "";
            for(int i = 0; i < temp.Length; i++)
            {
                if (!(temp[i].Equals(',')))
                {
                    price += temp[i];
                }
                else
                {
                    return Convert.ToDouble(price);
                }
                
            }
            return -1;
        }

    }
}
