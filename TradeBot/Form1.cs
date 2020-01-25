using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

namespace TradeBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            


        }
        RestRequest request;
        RestClient client;
        static string baseurl = "https://finnhub.io/api/v1/";
        static string action = "quote?symbol={ticker}&token={key}";
        static string key = "bol573vrh5rd0m2j1ktg";
         

        /*
         * 
         * request = new RestRequest("{events}/with/key/{key}", Method.POST);
            request.AddUrlSegment("key", key);
            request.AddUrlSegment("events", trigger);
            var content = client.Execute(request).Content;
            return true;
         * 
         */

        private void ShareName_Click(object sender, EventArgs e)
        {

        }

        private void GetPriceButton_Click(object sender, EventArgs e)
        {
            client = new RestClient(baseurl);
            request = new RestRequest(action, Method.GET);
            request.AddUrlSegment("ticker", "AAPL");
            request.AddUrlSegment("key", key);

            RestRequest r = new RestRequest("quote?symbol=AAPL&token=bol573vrh5rd0m2j1ktg", Method.GET);

            var content = client.Execute(r).Content;
            Console.WriteLine(content.ToString());
        }
    }
}
