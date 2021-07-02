namespace JayhunOmbor
{
    partial class s
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPreparer = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.btnBarcode = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.comboGroup = new System.Windows.Forms.ComboBox();
            this.btnNewGroup = new FontAwesome.Sharp.IconButton();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.txtSom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDollar = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKurs = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMinCount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboMeasurement = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSotishSom = new System.Windows.Forms.TextBox();
            this.txtSotishDollar = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(25, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "Номи :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(28, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 29);
            this.label2.TabIndex = 17;
            this.label2.Text = "Ишлаб чикарувчи :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(28, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 29);
            this.label3.TabIndex = 21;
            this.label3.Text = "Штрих_код :";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtName.Location = new System.Drawing.Point(112, 78);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(641, 37);
            this.txtName.TabIndex = 3;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // txtPreparer
            // 
            this.txtPreparer.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPreparer.Location = new System.Drawing.Point(239, 131);
            this.txtPreparer.Name = "txtPreparer";
            this.txtPreparer.Size = new System.Drawing.Size(514, 37);
            this.txtPreparer.TabIndex = 4;
            this.txtPreparer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPreparer_KeyDown);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBarcode.Location = new System.Drawing.Point(173, 348);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(505, 37);
            this.txtBarcode.TabIndex = 8;
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(158)))), ((int)(((byte)(253)))));
            this.iconButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(407, 630);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(120, 36);
            this.iconButton1.TabIndex = 14;
            this.iconButton1.Text = "Кўшиш";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton2.BackColor = System.Drawing.Color.Red;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.ForeColor = System.Drawing.Color.White;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.CalendarTimes;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 30;
            this.iconButton2.Location = new System.Drawing.Point(533, 630);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(221, 36);
            this.iconButton2.TabIndex = 15;
            this.iconButton2.Text = "(Esc) Бэкор килиш";
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // btnBarcode
            // 
            this.btnBarcode.BackColor = System.Drawing.Color.White;
            this.btnBarcode.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBarcode.IconChar = FontAwesome.Sharp.IconChar.Barcode;
            this.btnBarcode.IconColor = System.Drawing.Color.Black;
            this.btnBarcode.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBarcode.IconSize = 70;
            this.btnBarcode.Location = new System.Drawing.Point(684, 335);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(70, 60);
            this.btnBarcode.TabIndex = 9;
            this.btnBarcode.UseVisualStyleBackColor = false;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(28, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 29);
            this.label5.TabIndex = 20;
            this.label5.Text = "Гурух :";
            // 
            // comboGroup
            // 
            this.comboGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboGroup.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboGroup.FormattingEnabled = true;
            this.comboGroup.Location = new System.Drawing.Point(113, 290);
            this.comboGroup.Name = "comboGroup";
            this.comboGroup.Size = new System.Drawing.Size(640, 37);
            this.comboGroup.TabIndex = 14;
            this.comboGroup.SelectedIndexChanged += new System.EventHandler(this.comboGroup_SelectedIndexChanged);
            // 
            // btnNewGroup
            // 
            this.btnNewGroup.BackColor = System.Drawing.Color.Red;
            this.btnNewGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewGroup.ForeColor = System.Drawing.Color.White;
            this.btnNewGroup.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnNewGroup.IconColor = System.Drawing.Color.Black;
            this.btnNewGroup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNewGroup.IconSize = 30;
            this.btnNewGroup.Location = new System.Drawing.Point(684, 290);
            this.btnNewGroup.Name = "btnNewGroup";
            this.btnNewGroup.Size = new System.Drawing.Size(70, 37);
            this.btnNewGroup.TabIndex = 15;
            this.btnNewGroup.Text = "Йанги";
            this.btnNewGroup.UseVisualStyleBackColor = false;
            this.btnNewGroup.Visible = false;
            this.btnNewGroup.Click += new System.EventHandler(this.btnNewGroup_Click);
            // 
            // txtGroup
            // 
            this.txtGroup.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtGroup.Location = new System.Drawing.Point(113, 290);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(641, 37);
            this.txtGroup.TabIndex = 7;
            this.txtGroup.Visible = false;
            this.txtGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGroup_KeyDown);
            // 
            // txtSom
            // 
            this.txtSom.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSom.Location = new System.Drawing.Point(173, 404);
            this.txtSom.Name = "txtSom";
            this.txtSom.Size = new System.Drawing.Size(221, 37);
            this.txtSom.TabIndex = 10;
            this.txtSom.Text = "0";
            this.txtSom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSom_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(28, 407);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 29);
            this.label4.TabIndex = 22;
            this.label4.Text = "Тан сўм:";
            // 
            // txtDollar
            // 
            this.txtDollar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDollar.Location = new System.Drawing.Point(173, 461);
            this.txtDollar.Name = "txtDollar";
            this.txtDollar.Size = new System.Drawing.Size(221, 37);
            this.txtDollar.TabIndex = 11;
            this.txtDollar.Text = "0";
            this.txtDollar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDollar_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(28, 464);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 29);
            this.label6.TabIndex = 23;
            this.label6.Text = "Тан доллар:";
            // 
            // txtKurs
            // 
            this.txtKurs.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtKurs.Location = new System.Drawing.Point(173, 515);
            this.txtKurs.Name = "txtKurs";
            this.txtKurs.Size = new System.Drawing.Size(580, 37);
            this.txtKurs.TabIndex = 12;
            this.txtKurs.Text = "0";
            this.txtKurs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKurs_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(28, 518);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 29);
            this.label7.TabIndex = 24;
            this.label7.Text = "Курс :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(25, 570);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 29);
            this.label8.TabIndex = 25;
            this.label8.Text = "Микдори :";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtQuantity.Location = new System.Drawing.Point(173, 567);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(580, 37);
            this.txtQuantity.TabIndex = 13;
            this.txtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(29, 186);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 29);
            this.label9.TabIndex = 18;
            this.label9.Text = "Улчов :";
            // 
            // txtMinCount
            // 
            this.txtMinCount.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtMinCount.Location = new System.Drawing.Point(190, 236);
            this.txtMinCount.Name = "txtMinCount";
            this.txtMinCount.Size = new System.Drawing.Size(564, 37);
            this.txtMinCount.TabIndex = 6;
            this.txtMinCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMinCount_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(29, 239);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 29);
            this.label10.TabIndex = 19;
            this.label10.Text = "Мин  микдор :";
            // 
            // comboMeasurement
            // 
            this.comboMeasurement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMeasurement.Font = new System.Drawing.Font("Calibri", 18F);
            this.comboMeasurement.FormattingEnabled = true;
            this.comboMeasurement.Items.AddRange(new object[] {
            "dona",
            "kg",
            "litr",
            "metr"});
            this.comboMeasurement.Location = new System.Drawing.Point(118, 183);
            this.comboMeasurement.Name = "comboMeasurement";
            this.comboMeasurement.Size = new System.Drawing.Size(635, 37);
            this.comboMeasurement.TabIndex = 26;
            this.comboMeasurement.SelectedIndexChanged += new System.EventHandler(this.comboMeasurement_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(402, 407);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 29);
            this.label11.TabIndex = 27;
            this.label11.Text = "Сотиш сўм:";
            // 
            // txtSotishSom
            // 
            this.txtSotishSom.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSotishSom.Location = new System.Drawing.Point(532, 404);
            this.txtSotishSom.Name = "txtSotishSom";
            this.txtSotishSom.Size = new System.Drawing.Size(221, 37);
            this.txtSotishSom.TabIndex = 28;
            this.txtSotishSom.Text = "0";
            this.txtSotishSom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSotishSom_KeyDown);
            // 
            // txtSotishDollar
            // 
            this.txtSotishDollar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSotishDollar.Location = new System.Drawing.Point(532, 461);
            this.txtSotishDollar.Name = "txtSotishDollar";
            this.txtSotishDollar.Size = new System.Drawing.Size(221, 37);
            this.txtSotishDollar.TabIndex = 30;
            this.txtSotishDollar.Text = "0";
            this.txtSotishDollar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSotishDollar_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(402, 464);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 29);
            this.label12.TabIndex = 29;
            this.label12.Text = "Сотиш дол:";
            // 
            // s
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 689);
            this.Controls.Add(this.txtSotishDollar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtSotishSom);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboMeasurement);
            this.Controls.Add(this.txtMinCount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtKurs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDollar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.btnNewGroup);
            this.Controls.Add(this.comboGroup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.txtPreparer);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "s";
            this.Text = "Янги махсулот кўшиш ойнаси";
            this.Load += new System.EventHandler(this.frmAddNewProduct_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAddNewProduct_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPreparer;
        private System.Windows.Forms.TextBox txtBarcode;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton btnBarcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboGroup;
        private FontAwesome.Sharp.IconButton btnNewGroup;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.TextBox txtSom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDollar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtKurs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMinCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboMeasurement;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSotishSom;
        private System.Windows.Forms.TextBox txtSotishDollar;
        private System.Windows.Forms.Label label12;
    }
}