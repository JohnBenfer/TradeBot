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
            this.SuspendLayout();
            // 
            // ShareName
            // 
            this.ShareName.AutoSize = true;
            this.ShareName.Location = new System.Drawing.Point(13, 13);
            this.ShareName.Name = "ShareName";
            this.ShareName.Size = new System.Drawing.Size(90, 17);
            this.ShareName.TabIndex = 0;
            this.ShareName.Text = "Stock Ticker:";
            this.ShareName.Click += new System.EventHandler(this.ShareName_Click);
            // 
            // GetPriceButton
            // 
            this.GetPriceButton.Location = new System.Drawing.Point(16, 42);
            this.GetPriceButton.Name = "GetPriceButton";
            this.GetPriceButton.Size = new System.Drawing.Size(90, 43);
            this.GetPriceButton.TabIndex = 1;
            this.GetPriceButton.Text = "Get Price";
            this.GetPriceButton.UseVisualStyleBackColor = true;
            this.GetPriceButton.Click += new System.EventHandler(this.GetPriceButton_Click);
            // 
            // BuyButton
            // 
            this.BuyButton.Location = new System.Drawing.Point(16, 107);
            this.BuyButton.Name = "BuyButton";
            this.BuyButton.Size = new System.Drawing.Size(90, 40);
            this.BuyButton.TabIndex = 2;
            this.BuyButton.Text = "Buy";
            this.BuyButton.UseVisualStyleBackColor = true;
            this.BuyButton.Click += new System.EventHandler(this.BuyButton_Click);
            // 
            // SellButton
            // 
            this.SellButton.Location = new System.Drawing.Point(146, 107);
            this.SellButton.Name = "SellButton";
            this.SellButton.Size = new System.Drawing.Size(87, 40);
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
            this.SelectedStock.Location = new System.Drawing.Point(134, 42);
            this.SelectedStock.Name = "SelectedStock";
            this.SelectedStock.Size = new System.Drawing.Size(121, 24);
            this.SelectedStock.TabIndex = 5;
            this.SelectedStock.SelectedIndexChanged += new System.EventHandler(this.SelectedStock_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 330);
            this.Controls.Add(this.SelectedStock);
            this.Controls.Add(this.SellButton);
            this.Controls.Add(this.BuyButton);
            this.Controls.Add(this.GetPriceButton);
            this.Controls.Add(this.ShareName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ShareName;
        private System.Windows.Forms.Button GetPriceButton;
        private System.Windows.Forms.Button BuyButton;
        private System.Windows.Forms.Button SellButton;
        private System.Windows.Forms.ComboBox SelectedStock;
    }
}

