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

        public List<double> BuyPrices = new List<double>();
        public List<double> SellPrices = new List<double>();

        private int shareCount;

        private RestClient client = new RestClient("https://finnhub.io/api/v1/");   // base url

        private string quoteRequest = "";

        private RestRequest request;

        public int ShareCount { 
            get => shareCount; 
            set => shareCount = value; 
        }

        public double AvgBuyPrice;
        public double AvgSellPrice;

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
            BuyPrices.Add(purchasePrice);
            AvgBuyPrice = Average(BuyPrices);
            Console.WriteLine(Ticker + " share purchased for $" + purchasePrice);
            PrintShares();
            return purchasePrice;
        }

        public double Sell()
        {
            double sellPrice = GetCurrentPrice();
            ShareCount--;
            SellPrices.Add(sellPrice);
            AvgSellPrice = Average(SellPrices);
            Console.WriteLine(Ticker + " share sold for $" + sellPrice);
            PrintShares();
            return sellPrice;
        }

        private double Average(List<double> prices)
        {
            double total = 0;
            foreach(double d in prices)
            {
                total += d;
            }

            return total/prices.Count;
        }

        public void PrintShares()
        {
            Console.WriteLine(ShareCount + " " + Ticker + " shares available.");
        }

        public void PrintCurrentPrice()
        {
            Console.WriteLine(GetCurrentPrice());
        }

        private double GetCurrentPrice()
        {
            double temp = ExtractPrice(client.Execute(request).Content.ToString());
            return temp;
        }

        private double ExtractPrice(string contents)
        {
            Console.WriteLine(contents);
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
