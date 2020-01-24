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
        static string baseurl = "wss://ws.finnhub.io?token=";
        static string key = "bol573vrh5rd0m2j1ktg";
        static string url = baseurl + key;


        private void ShareName_Click(object sender, EventArgs e)
        {

        }

        private void GetPriceButton_Click(object sender, EventArgs e)
        {
            client = new RestClient(baseurl);
            request = new RestRequest("");
            var content = client.Execute(request).Content;
        }
    }
}
