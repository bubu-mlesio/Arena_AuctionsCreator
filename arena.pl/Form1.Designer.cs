namespace arena.pl
{
    partial class Menu
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.shop_cb = new System.Windows.Forms.ComboBox();
            this.description_tb = new System.Windows.Forms.TextBox();
            this.title_tb = new System.Windows.Forms.TextBox();
            this.price_tb = new System.Windows.Forms.TextBox();
            this.stock_tb = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.skuExternal_tb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.category_cb = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.addAuctionStart = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progress_lb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // shop_cb
            // 
            this.shop_cb.FormattingEnabled = true;
            this.shop_cb.Location = new System.Drawing.Point(108, 21);
            this.shop_cb.Name = "shop_cb";
            this.shop_cb.Size = new System.Drawing.Size(295, 37);
            this.shop_cb.TabIndex = 0;
            // 
            // description_tb
            // 
            this.description_tb.Location = new System.Drawing.Point(15, 120);
            this.description_tb.MaxLength = 0;
            this.description_tb.Multiline = true;
            this.description_tb.Name = "description_tb";
            this.description_tb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.description_tb.Size = new System.Drawing.Size(1165, 270);
            this.description_tb.TabIndex = 1;
            // 
            // title_tb
            // 
            this.title_tb.Location = new System.Drawing.Point(15, 652);
            this.title_tb.MaxLength = 0;
            this.title_tb.Multiline = true;
            this.title_tb.Name = "title_tb";
            this.title_tb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.title_tb.Size = new System.Drawing.Size(1165, 305);
            this.title_tb.TabIndex = 10;
            // 
            // price_tb
            // 
            this.price_tb.Location = new System.Drawing.Point(214, 462);
            this.price_tb.Name = "price_tb";
            this.price_tb.Size = new System.Drawing.Size(165, 35);
            this.price_tb.TabIndex = 5;
            // 
            // stock_tb
            // 
            this.stock_tb.Location = new System.Drawing.Point(414, 462);
            this.stock_tb.Name = "stock_tb";
            this.stock_tb.Size = new System.Drawing.Size(165, 35);
            this.stock_tb.TabIndex = 7;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(10, 24);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(81, 29);
            this.label.TabIndex = 8;
            this.label.Text = "Sklep:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "Opis:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 430);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 29);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cena [ZŁ]:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 430);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 29);
            this.label6.TabIndex = 14;
            this.label6.Text = "Ilość sztuk [SZT]:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 430);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 29);
            this.label7.TabIndex = 15;
            this.label7.Text = "SKU:";
            // 
            // skuExternal_tb
            // 
            this.skuExternal_tb.Location = new System.Drawing.Point(17, 462);
            this.skuExternal_tb.Name = "skuExternal_tb";
            this.skuExternal_tb.Size = new System.Drawing.Size(165, 35);
            this.skuExternal_tb.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 608);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 29);
            this.label8.TabIndex = 17;
            this.label8.Text = "Tytuły:";
            // 
            // category_cb
            // 
            this.category_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.category_cb.FormattingEnabled = true;
            this.category_cb.Location = new System.Drawing.Point(15, 550);
            this.category_cb.Name = "category_cb";
            this.category_cb.Size = new System.Drawing.Size(623, 37);
            this.category_cb.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 520);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 29);
            this.label9.TabIndex = 20;
            this.label9.Text = "Kategoria:";
            // 
            // addAuctionStart
            // 
            this.addAuctionStart.Location = new System.Drawing.Point(310, 990);
            this.addAuctionStart.Name = "addAuctionStart";
            this.addAuctionStart.Size = new System.Drawing.Size(615, 65);
            this.addAuctionStart.TabIndex = 11;
            this.addAuctionStart.Text = "Dodaj aukcje";
            this.addAuctionStart.UseVisualStyleBackColor = true;
            this.addAuctionStart.Click += new System.EventHandler(this.addAuctionStart_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(538, 11);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(653, 42);
            this.progressBar1.TabIndex = 21;
            this.progressBar1.Visible = false;
            // 
            // progress_lb
            // 
            this.progress_lb.AutoSize = true;
            this.progress_lb.Location = new System.Drawing.Point(788, 67);
            this.progress_lb.Name = "progress_lb";
            this.progress_lb.Size = new System.Drawing.Size(0, 29);
            this.progress_lb.TabIndex = 22;
            this.progress_lb.Visible = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(216F, 216F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1203, 1082);
            this.Controls.Add(this.progress_lb);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.addAuctionStart);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.category_cb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.skuExternal_tb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.stock_tb);
            this.Controls.Add(this.price_tb);
            this.Controls.Add(this.title_tb);
            this.Controls.Add(this.description_tb);
            this.Controls.Add(this.shop_cb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1235, 1165);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1235, 1165);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arena.pl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox shop_cb;
        private System.Windows.Forms.TextBox description_tb;
        private System.Windows.Forms.TextBox title_tb;
        private System.Windows.Forms.TextBox price_tb;
        private System.Windows.Forms.TextBox stock_tb;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox skuExternal_tb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox category_cb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button addAuctionStart;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label progress_lb;
    }
}

