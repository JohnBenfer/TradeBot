namespace TradeBot
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ShareName = new System.Windows.Forms.Label();
            this.GetPriceButton = new System.Windows.Forms.Button();
            this.BuyButton = new System.Windows.Forms.Button();
            this.SellButton = new System.Windows.Forms.Button();
            this.SelectedStock = new System.Windows.Forms.ComboBox();
            this.MessageOutput = new System.Windows.Forms.TextBox();
            this.StockGrid = new System.Windows.Forms.DataGridView();
            this.StockColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SharesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvgBuyPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvgSellPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.StockGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ShareName
            // 
            this.ShareName.AutoSize = true;
            this.ShareName.Location = new System.Drawing.Point(25, 23);
            this.ShareName.Name = "ShareName";
            this.ShareName.Size = new System.Drawing.Size(90, 17);
            this.ShareName.TabIndex = 0;
            this.ShareName.Text = "Stock Ticker:";
            this.ShareName.Click += new System.EventHandler(this.ShareName_Click);
            // 
            // GetPriceButton
            // 
            this.GetPriceButton.Location = new System.Drawing.Point(486, 19);
            this.GetPriceButton.Name = "GetPriceButton";
            this.GetPriceButton.Size = new System.Drawing.Size(87, 24);
            this.GetPriceButton.TabIndex = 1;
            this.GetPriceButton.Text = "Get Price";
            this.GetPriceButton.UseVisualStyleBackColor = true;
            this.GetPriceButton.Click += new System.EventHandler(this.GetPriceButton_Click);
            // 
            // BuyButton
            // 
            this.BuyButton.Location = new System.Drawing.Point(298, 19);
            this.BuyButton.Name = "BuyButton";
            this.BuyButton.Size = new System.Drawing.Size(90, 24);
            this.BuyButton.TabIndex = 2;
            this.BuyButton.Text = "Buy";
            this.BuyButton.UseVisualStyleBackColor = true;
            this.BuyButton.Click += new System.EventHandler(this.BuyButton_Click);
            // 
            // SellButton
            // 
            this.SellButton.Location = new System.Drawing.Point(394, 19);
            this.SellButton.Name = "SellButton";
            this.SellButton.Size = new System.Drawing.Size(86, 24);
            this.SellButton.TabIndex = 3;
            this.SellButton.Text = "Sell";
            this.SellButton.UseVisualStyleBackColor = true;
            this.SellButton.Click += new System.EventHandler(this.SellButton_Click);
            // 
            // SelectedStock
            // 
            this.SelectedStock.FormattingEnabled = true;
            this.SelectedStock.Items.AddRange(new object[] {
            "AAPL (Apple)",
            "F (Ford)",
            "BBY (Best Buy)"});
            this.SelectedStock.Location = new System.Drawing.Point(121, 19);
            this.SelectedStock.Name = "SelectedStock";
            this.SelectedStock.Size = new System.Drawing.Size(171, 24);
            this.SelectedStock.TabIndex = 5;
            this.SelectedStock.SelectedIndexChanged += new System.EventHandler(this.SelectedStock_SelectedIndexChanged);
            // 
            // MessageOutput
            // 
            this.MessageOutput.Location = new System.Drawing.Point(12, 428);
            this.MessageOutput.Multiline = true;
            this.MessageOutput.Name = "MessageOutput";
            this.MessageOutput.Size = new System.Drawing.Size(824, 114);
            this.MessageOutput.TabIndex = 6;
            // 
            // StockGrid
            // 
            this.StockGrid.AllowUserToAddRows = false;
            this.StockGrid.AllowUserToDeleteRows = false;
            this.StockGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StockGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StockColumn,
            this.SharesColumn,
            this.AvgBuyPriceColumn,
            this.AvgSellPriceColumn});
            this.StockGrid.Location = new System.Drawing.Point(12, 64);
            this.StockGrid.Name = "StockGrid";
            this.StockGrid.ReadOnly = true;
            this.StockGrid.RowHeadersWidth = 51;
            this.StockGrid.RowTemplate.Height = 24;
            this.StockGrid.Size = new System.Drawing.Size(824, 358);
            this.StockGrid.TabIndex = 7;
            // 
            // StockColumn
            // 
            this.StockColumn.HeaderText = "Stock";
            this.StockColumn.MinimumWidth = 6;
            this.StockColumn.Name = "StockColumn";
            this.StockColumn.ReadOnly = true;
            this.StockColumn.Width = 125;
            // 
            // SharesColumn
            // 
            this.SharesColumn.HeaderText = "Shares";
            this.SharesColumn.MinimumWidth = 6;
            this.SharesColumn.Name = "SharesColumn";
            this.SharesColumn.ReadOnly = true;
            this.SharesColumn.Width = 125;
            // 
            // AvgBuyPriceColumn
            // 
            this.AvgBuyPriceColumn.HeaderText = "Avg Buy Price";
            this.AvgBuyPriceColumn.MinimumWidth = 6;
            this.AvgBuyPriceColumn.Name = "AvgBuyPriceColumn";
            this.AvgBuyPriceColumn.ReadOnly = true;
            this.AvgBuyPriceColumn.Width = 125;
            // 
            // AvgSellPriceColumn
            // 
            this.AvgSellPriceColumn.HeaderText = "Avg Sell Price";
            this.AvgSellPriceColumn.MinimumWidth = 6;
            this.AvgSellPriceColumn.Name = "AvgSellPriceColumn";
            this.AvgSellPriceColumn.ReadOnly = true;
            this.AvgSellPriceColumn.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 554);
            this.Controls.Add(this.StockGrid);
            this.Controls.Add(this.MessageOutput);
            this.Controls.Add(this.SelectedStock);
            this.Controls.Add(this.SellButton);
            this.Controls.Add(this.BuyButton);
            this.Controls.Add(this.GetPriceButton);
            this.Controls.Add(this.ShareName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StockGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ShareName;
        private System.Windows.Forms.Button GetPriceButton;
        private System.Windows.Forms.Button BuyButton;
        private System.Windows.Forms.Button SellButton;
        private System.Windows.Forms.ComboBox SelectedStock;
        private System.Windows.Forms.TextBox MessageOutput;
        private System.Windows.Forms.DataGridView StockGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SharesColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgBuyPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgSellPriceColumn;
    }
}

