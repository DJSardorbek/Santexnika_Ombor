namespace JayhunOmbor
{
    partial class frmFakturaAddProduct
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSom = new System.Windows.Forms.TextBox();
            this.txtSoldPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.lblDollar = new System.Windows.Forms.Label();
            this.lblKurs = new System.Windows.Forms.Label();
            this.txtDollar = new System.Windows.Forms.TextBox();
            this.txtKurs = new System.Windows.Forms.TextBox();
            this.panelSom = new System.Windows.Forms.Panel();
            this.panelDollar = new System.Windows.Forms.Panel();
            this.panelQuantity = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOmborQuan = new System.Windows.Forms.TextBox();
            this.panelSom.SuspendLayout();
            this.panelDollar.SuspendLayout();
            this.panelQuantity.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "Махсулот :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(22, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "Сўм :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(22, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "Сотиш_нархи :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(22, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "Жўнатиш микдори :";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtName.Location = new System.Drawing.Point(149, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(536, 37);
            this.txtName.TabIndex = 15;
            this.txtName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtSom
            // 
            this.txtSom.Enabled = false;
            this.txtSom.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSom.Location = new System.Drawing.Point(92, 80);
            this.txtSom.Name = "txtSom";
            this.txtSom.Size = new System.Drawing.Size(593, 37);
            this.txtSom.TabIndex = 13;
            // 
            // txtSoldPrice
            // 
            this.txtSoldPrice.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSoldPrice.Location = new System.Drawing.Point(190, 17);
            this.txtSoldPrice.Name = "txtSoldPrice";
            this.txtSoldPrice.Size = new System.Drawing.Size(495, 37);
            this.txtSoldPrice.TabIndex = 1;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtQuantity.Location = new System.Drawing.Point(242, 130);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(445, 37);
            this.txtQuantity.TabIndex = 2;
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.CartPlus;
            this.iconButton1.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(541, 495);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(173, 36);
            this.iconButton1.TabIndex = 3;
            this.iconButton1.Text = "Кўшиш(Enter)";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton2.BackColor = System.Drawing.Color.Red;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.CalendarTimes;
            this.iconButton2.IconColor = System.Drawing.Color.WhiteSmoke;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 30;
            this.iconButton2.Location = new System.Drawing.Point(367, 495);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(168, 36);
            this.iconButton2.TabIndex = 4;
            this.iconButton2.Text = "Бэкор килиш";
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // lblDollar
            // 
            this.lblDollar.AutoSize = true;
            this.lblDollar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDollar.Location = new System.Drawing.Point(22, 27);
            this.lblDollar.Name = "lblDollar";
            this.lblDollar.Size = new System.Drawing.Size(101, 29);
            this.lblDollar.TabIndex = 12;
            this.lblDollar.Text = "Доллар :";
            // 
            // lblKurs
            // 
            this.lblKurs.AutoSize = true;
            this.lblKurs.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblKurs.Location = new System.Drawing.Point(22, 93);
            this.lblKurs.Name = "lblKurs";
            this.lblKurs.Size = new System.Drawing.Size(164, 29);
            this.lblKurs.TabIndex = 10;
            this.lblKurs.Text = "Аввалги_курс :";
            // 
            // txtDollar
            // 
            this.txtDollar.Enabled = false;
            this.txtDollar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDollar.Location = new System.Drawing.Point(129, 24);
            this.txtDollar.Name = "txtDollar";
            this.txtDollar.Size = new System.Drawing.Size(556, 37);
            this.txtDollar.TabIndex = 11;
            // 
            // txtKurs
            // 
            this.txtKurs.Enabled = false;
            this.txtKurs.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtKurs.Location = new System.Drawing.Point(190, 90);
            this.txtKurs.Name = "txtKurs";
            this.txtKurs.Size = new System.Drawing.Size(495, 37);
            this.txtKurs.TabIndex = 9;
            // 
            // panelSom
            // 
            this.panelSom.Controls.Add(this.txtName);
            this.panelSom.Controls.Add(this.txtSom);
            this.panelSom.Controls.Add(this.label2);
            this.panelSom.Controls.Add(this.label1);
            this.panelSom.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSom.Location = new System.Drawing.Point(20, 60);
            this.panelSom.Name = "panelSom";
            this.panelSom.Size = new System.Drawing.Size(687, 119);
            this.panelSom.TabIndex = 14;
            // 
            // panelDollar
            // 
            this.panelDollar.Controls.Add(this.txtDollar);
            this.panelDollar.Controls.Add(this.lblDollar);
            this.panelDollar.Controls.Add(this.lblKurs);
            this.panelDollar.Controls.Add(this.txtKurs);
            this.panelDollar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDollar.Location = new System.Drawing.Point(20, 179);
            this.panelDollar.Name = "panelDollar";
            this.panelDollar.Size = new System.Drawing.Size(687, 131);
            this.panelDollar.TabIndex = 15;
            // 
            // panelQuantity
            // 
            this.panelQuantity.Controls.Add(this.label5);
            this.panelQuantity.Controls.Add(this.txtOmborQuan);
            this.panelQuantity.Controls.Add(this.label3);
            this.panelQuantity.Controls.Add(this.txtSoldPrice);
            this.panelQuantity.Controls.Add(this.label4);
            this.panelQuantity.Controls.Add(this.txtQuantity);
            this.panelQuantity.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQuantity.Location = new System.Drawing.Point(20, 310);
            this.panelQuantity.Name = "panelQuantity";
            this.panelQuantity.Size = new System.Drawing.Size(687, 172);
            this.panelQuantity.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(22, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 29);
            this.label5.TabIndex = 7;
            this.label5.Text = "Омбордаги микдор :";
            // 
            // txtOmborQuan
            // 
            this.txtOmborQuan.Enabled = false;
            this.txtOmborQuan.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtOmborQuan.Location = new System.Drawing.Point(252, 73);
            this.txtOmborQuan.Name = "txtOmborQuan";
            this.txtOmborQuan.Size = new System.Drawing.Size(433, 37);
            this.txtOmborQuan.TabIndex = 6;
            // 
            // frmFakturaAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 551);
            this.Controls.Add(this.panelQuantity);
            this.Controls.Add(this.panelDollar);
            this.Controls.Add(this.panelSom);
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(this.iconButton1);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "frmFakturaAddProduct";
            this.Text = "Корзинка";
            this.Load += new System.EventHandler(this.frmFakturaAddProduct_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFakturaAddProduct_KeyDown);
            this.panelSom.ResumeLayout(false);
            this.panelSom.PerformLayout();
            this.panelDollar.ResumeLayout(false);
            this.panelDollar.PerformLayout();
            this.panelQuantity.ResumeLayout(false);
            this.panelQuantity.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSom;
        private System.Windows.Forms.TextBox txtSoldPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.Label lblDollar;
        private System.Windows.Forms.Label lblKurs;
        private System.Windows.Forms.TextBox txtDollar;
        private System.Windows.Forms.TextBox txtKurs;
        private System.Windows.Forms.Panel panelSom;
        private System.Windows.Forms.Panel panelDollar;
        private System.Windows.Forms.Panel panelQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOmborQuan;
    }
}