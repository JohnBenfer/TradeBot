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
            this.GetPriceButton.Location = new System.Drawing.Point(16, 47);
            this.GetPriceButton.Name = "GetPriceButton";
            this.GetPriceButton.Size = new System.Drawing.Size(98, 46);
            this.GetPriceButton.TabIndex = 1;
            this.GetPriceButton.Text = "Get Price";
            this.GetPriceButton.UseVisualStyleBackColor = true;
            this.GetPriceButton.Click += new System.EventHandler(this.GetPriceButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.GetPriceButton);
            this.Controls.Add(this.ShareName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ShareName;
        private System.Windows.Forms.Button GetPriceButton;
    }
}

