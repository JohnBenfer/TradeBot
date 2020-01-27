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
        Stock AAPL = new Stock("AAPL");
        Stock F = new Stock("F");
        Stock BBY = new Stock("BBY");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SelectedStock.SelectedIndex = 0;
            StockGrid.Rows.Add("AAPL", AAPL.ShareCount, AAPL.AvgBuyPrice, AAPL.AvgSellPrice);
            StockGrid.Rows.Add("F", F.ShareCount, F.AvgBuyPrice, F.AvgSellPrice);
            StockGrid.Rows.Add("BBY", BBY.ShareCount, BBY.AvgBuyPrice, BBY.AvgSellPrice);
            RefreshStockGrid();
        }


        FinnhubClient Apple = new FinnhubClient("AAPL", "quote?symbol=", "&token=bol573vrh5rd0m2j1ktg");

        RestRequest request;
        RestClient client;
        static string baseurl = "https://finnhub.io/api/v1/";
        static string action = "quote?symbol={ticker}&token={key}";
        static string key = "bol573vrh5rd0m2j1ktg";

        Stock CurrentStock;
         

        private void ShareName_Click(object sender, EventArgs e)
        {

        }

        private void RefreshStockGrid()
        {
            StockGrid.Rows.Clear();
            StockGrid.Rows.Add("AAPL", AAPL.ShareCount, AAPL.AvgBuyPrice, AAPL.AvgSellPrice);
            StockGrid.Rows.Add("F", F.ShareCount, F.AvgBuyPrice, F.AvgSellPrice);
            StockGrid.Rows.Add("BBY", BBY.ShareCount, BBY.AvgBuyPrice, BBY.AvgSellPrice);
        }

        private void GetPriceButton_Click(object sender, EventArgs e)
        {
            CurrentStock.PrintCurrentPrice();
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            CurrentStock.Buy();
            RefreshStockGrid();
        }

        private void SellButton_Click(object sender, EventArgs e)
        {
            CurrentStock.Sell();
            RefreshStockGrid();
        }

        private void StockList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SelectedStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (SelectedStock.SelectedIndex)
            {
                case 0:
                    CurrentStock = AAPL;
                    break;
                case 1:
                    CurrentStock = F;
                    break;
                case 2:
                    CurrentStock = BBY;
                    break;
                default:
                    CurrentStock = AAPL;
                    break;

            }
            Console.WriteLine("Stock switched to " + CurrentStock.Ticker);
            
        }
    }
}
