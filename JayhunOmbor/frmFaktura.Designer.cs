namespace JayhunOmbor
{
    partial class frmFaktura
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
            this.dbgridFakturaSend = new System.Windows.Forms.DataGridView();
            this.txtSearch = new MetroSet_UI.Controls.MetroSetTextBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.dbgridFakturaItemSend = new System.Windows.Forms.DataGridView();
            this.lblQayta = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridFakturaSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridFakturaItemSend)).BeginInit();
            this.SuspendLayout();
            // 
            // dbgridFakturaSend
            // 
            this.dbgridFakturaSend.AllowUserToAddRows = false;
            this.dbgridFakturaSend.AllowUserToDeleteRows = false;
            this.dbgridFakturaSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridFakturaSend.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridFakturaSend.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridFakturaSend.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridFakturaSend.ColumnHeadersHeight = 60;
            this.dbgridFakturaSend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridFakturaSend.Location = new System.Drawing.Point(2, 67);
            this.dbgridFakturaSend.MultiSelect = false;
            this.dbgridFakturaSend.Name = "dbgridFakturaSend";
            this.dbgridFakturaSend.ReadOnly = true;
            this.dbgridFakturaSend.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridFakturaSend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridFakturaSend.Size = new System.Drawing.Size(1101, 269);
            this.dbgridFakturaSend.TabIndex = 0;
            this.dbgridFakturaSend.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgridFakturaSend_CellClick);
            this.dbgridFakturaSend.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridFaktura_RowPostPaint);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.AutoCompleteCustomSource = null;
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtSearch.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtSearch.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtSearch.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearch.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtSearch.Image = null;
            this.txtSearch.IsDerivedStyle = true;
            this.txtSearch.Lines = null;
            this.txtSearch.Location = new System.Drawing.Point(39, 25);
            this.txtSearch.MaxLength = 32767;
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ReadOnly = false;
            this.txtSearch.Size = new System.Drawing.Size(1064, 36);
            this.txtSearch.Style = MetroSet_UI.Enums.Style.Light;
            this.txtSearch.StyleManager = null;
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSearch.ThemeAuthor = "Narwin";
            this.txtSearch.ThemeName = "MetroLite";
            this.txtSearch.UseSystemPasswordChar = false;
            this.txtSearch.WatermarkText = "Филиал номи...";
            this.txtSearch.TextChanged += new System.EventHandler(this.metroSetTextBox1_TextChanged);
            this.txtSearch.KeyPressed += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPressed);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 36;
            this.iconPictureBox1.Location = new System.Drawing.Point(0, 25);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(36, 36);
            this.iconPictureBox1.TabIndex = 3;
            this.iconPictureBox1.TabStop = false;
            this.iconPictureBox1.Click += new System.EventHandler(this.iconPictureBox1_Click);
            // 
            // dbgridFakturaItemSend
            // 
            this.dbgridFakturaItemSend.AllowUserToAddRows = false;
            this.dbgridFakturaItemSend.AllowUserToDeleteRows = false;
            this.dbgridFakturaItemSend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridFakturaItemSend.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridFakturaItemSend.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridFakturaItemSend.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridFakturaItemSend.ColumnHeadersHeight = 60;
            this.dbgridFakturaItemSend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridFakturaItemSend.Location = new System.Drawing.Point(2, 342);
            this.dbgridFakturaItemSend.MultiSelect = false;
            this.dbgridFakturaItemSend.Name = "dbgridFakturaItemSend";
            this.dbgridFakturaItemSend.ReadOnly = true;
            this.dbgridFakturaItemSend.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridFakturaItemSend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridFakturaItemSend.Size = new System.Drawing.Size(1101, 282);
            this.dbgridFakturaItemSend.TabIndex = 7;
            this.dbgridFakturaItemSend.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridFakturaItem_RowPostPaint);
            // 
            // lblQayta
            // 
            this.lblQayta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQayta.AutoSize = true;
            this.lblQayta.Location = new System.Drawing.Point(983, 0);
            this.lblQayta.Name = "lblQayta";
            this.lblQayta.Size = new System.Drawing.Size(120, 22);
            this.lblQayta.TabIndex = 11;
            this.lblQayta.Text = "Кайта юклаш";
            this.lblQayta.Visible = false;
            this.lblQayta.Click += new System.EventHandler(this.lblQayta_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(-2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(410, 22);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Малумотлар юкланмокда, илтимос кутинг...";
            this.lblStatus.Visible = false;
            // 
            // iconButton3
            // 
            this.iconButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.CalendarTimes;
            this.iconButton3.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.IconSize = 30;
            this.iconButton3.Location = new System.Drawing.Point(937, 628);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(166, 36);
            this.iconButton3.TabIndex = 20;
            this.iconButton3.Text = "Бэкор килиш";
            this.iconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton3.UseVisualStyleBackColor = false;
            this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // frmFaktura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 661);
            this.Controls.Add(this.iconButton3);
            this.Controls.Add(this.lblQayta);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dbgridFakturaItemSend);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dbgridFakturaSend);
            this.Controls.Add(this.iconPictureBox1);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmFaktura";
            this.Text = "Фактура";
            this.Load += new System.EventHandler(this.frmFaktura_Load);
            this.SizeChanged += new System.EventHandler(this.frmFaktura_SizeChanged);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmFaktura_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dbgridFakturaSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridFakturaItemSend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dbgridFakturaSend;
        private MetroSet_UI.Controls.MetroSetTextBox txtSearch;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.DataGridView dbgridFakturaItemSend;
        public System.Windows.Forms.Label lblQayta;
        private System.Windows.Forms.Label lblStatus;
        private FontAwesome.Sharp.IconButton iconButton3;
    }
}