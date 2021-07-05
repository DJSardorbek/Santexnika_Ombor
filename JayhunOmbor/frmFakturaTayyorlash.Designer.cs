namespace JayhunOmbor
{
    partial class frmFakturaTayyorlash
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
            this.dbgridFaktura = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.btnSave = new FontAwesome.Sharp.IconButton();
            this.btnCancel = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreate = new FontAwesome.Sharp.IconButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtDollar = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelete = new FontAwesome.Sharp.IconButton();
            this.btnEdit = new FontAwesome.Sharp.IconButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dbgridProduct = new System.Windows.Forms.DataGridView();
            this.lblQayta = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtSom = new System.Windows.Forms.ComboBox();
            this.btnSend = new FontAwesome.Sharp.IconButton();
            this.comboFilial = new System.Windows.Forms.ComboBox();
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnQabulUlash = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.txtSearchFil = new MetroSet_UI.Controls.MetroSetTextBox();
            this.dbgridFakturaItemSave = new System.Windows.Forms.DataGridView();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.dbgridFakturaSave = new System.Windows.Forms.DataGridView();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridFaktura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridProduct)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridFakturaItemSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridFakturaSave)).BeginInit();
            this.SuspendLayout();
            // 
            // dbgridFaktura
            // 
            this.dbgridFaktura.AllowUserToAddRows = false;
            this.dbgridFaktura.AllowUserToDeleteRows = false;
            this.dbgridFaktura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridFaktura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridFaktura.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridFaktura.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridFaktura.ColumnHeadersHeight = 60;
            this.dbgridFaktura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridFaktura.Location = new System.Drawing.Point(0, 108);
            this.dbgridFaktura.Margin = new System.Windows.Forms.Padding(5);
            this.dbgridFaktura.MultiSelect = false;
            this.dbgridFaktura.Name = "dbgridFaktura";
            this.dbgridFaktura.ReadOnly = true;
            this.dbgridFaktura.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridFaktura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridFaktura.Size = new System.Drawing.Size(1096, 480);
            this.dbgridFaktura.TabIndex = 6;
            this.dbgridFaktura.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridFaktura_RowPostPaint);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.label1.Location = new System.Drawing.Point(601, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Филиал :";
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(158)))), ((int)(((byte)(253)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox1.IconColor = System.Drawing.Color.White;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 36;
            this.iconPictureBox1.Location = new System.Drawing.Point(3, 68);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(36, 36);
            this.iconPictureBox1.TabIndex = 9;
            this.iconPictureBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(158)))), ((int)(((byte)(253)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnSave.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSave.IconSize = 30;
            this.btnSave.Location = new System.Drawing.Point(764, 590);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(163, 36);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Саклаш (F2)";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.CalendarTimes;
            this.btnCancel.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancel.IconSize = 30;
            this.btnCancel.Location = new System.Drawing.Point(933, 590);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(166, 36);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Бэкор килиш";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.label2.Location = new System.Drawing.Point(312, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 26);
            this.label2.TabIndex = 21;
            this.label2.Text = "Сум :";
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(158)))), ((int)(((byte)(253)))));
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCreate.IconColor = System.Drawing.Color.Black;
            this.btnCreate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCreate.IconSize = 30;
            this.btnCreate.Location = new System.Drawing.Point(1009, 30);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(90, 36);
            this.btnCreate.TabIndex = 20;
            this.btnCreate.Text = "Яратиш";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1107, 661);
            this.tabControl1.TabIndex = 24;
            this.tabControl1.SizeChanged += new System.EventHandler(this.tabControl1_SizeChanged);
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtDollar);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.btnEdit);
            this.tabPage1.Controls.Add(this.txtSearch);
            this.tabPage1.Controls.Add(this.dbgridProduct);
            this.tabPage1.Controls.Add(this.lblQayta);
            this.tabPage1.Controls.Add(this.lblStatus);
            this.tabPage1.Controls.Add(this.txtSom);
            this.tabPage1.Controls.Add(this.btnSend);
            this.tabPage1.Controls.Add(this.comboFilial);
            this.tabPage1.Controls.Add(this.btnAdd);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnCreate);
            this.tabPage1.Controls.Add(this.dbgridFaktura);
            this.tabPage1.Controls.Add(this.iconPictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1099, 626);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Тайёрланаётган фактура";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // txtDollar
            // 
            this.txtDollar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDollar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.txtDollar.Enabled = false;
            this.txtDollar.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.txtDollar.FormattingEnabled = true;
            this.txtDollar.Location = new System.Drawing.Point(104, 31);
            this.txtDollar.Name = "txtDollar";
            this.txtDollar.Size = new System.Drawing.Size(200, 36);
            this.txtDollar.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.label3.Location = new System.Drawing.Point(5, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 26);
            this.label3.TabIndex = 33;
            this.label3.Text = "Доллар :";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.CalendarTimes;
            this.btnDelete.IconColor = System.Drawing.Color.Gainsboro;
            this.btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDelete.IconSize = 30;
            this.btnDelete.Location = new System.Drawing.Point(291, 590);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(133, 36);
            this.btnDelete.TabIndex = 32;
            this.btnDelete.Text = "Ўчириш";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.Teal;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnEdit.IconChar = FontAwesome.Sharp.IconChar.PenNib;
            this.btnEdit.IconColor = System.Drawing.Color.Gainsboro;
            this.btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEdit.IconSize = 30;
            this.btnEdit.Location = new System.Drawing.Point(430, 590);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(150, 36);
            this.btnEdit.TabIndex = 31;
            this.btnEdit.Text = "Ўзгартириш";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearch.Location = new System.Drawing.Point(42, 68);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(1054, 37);
            this.txtSearch.TabIndex = 30;
            this.txtSearch.TextChanged += new System.EventHandler(this.metroSetTextBox1_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // dbgridProduct
            // 
            this.dbgridProduct.AllowUserToAddRows = false;
            this.dbgridProduct.AllowUserToDeleteRows = false;
            this.dbgridProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dbgridProduct.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridProduct.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridProduct.ColumnHeadersHeight = 60;
            this.dbgridProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridProduct.Location = new System.Drawing.Point(10, 108);
            this.dbgridProduct.Margin = new System.Windows.Forms.Padding(5);
            this.dbgridProduct.MultiSelect = false;
            this.dbgridProduct.Name = "dbgridProduct";
            this.dbgridProduct.ReadOnly = true;
            this.dbgridProduct.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridProduct.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dbgridProduct.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dbgridProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridProduct.Size = new System.Drawing.Size(998, 210);
            this.dbgridProduct.TabIndex = 5;
            this.dbgridProduct.Visible = false;
            this.dbgridProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgridProduct_CellClick);
            this.dbgridProduct.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridProduct_RowPostPaint);
            this.dbgridProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dbgridProduct_KeyDown);
            // 
            // lblQayta
            // 
            this.lblQayta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQayta.AutoSize = true;
            this.lblQayta.Location = new System.Drawing.Point(981, 3);
            this.lblQayta.Name = "lblQayta";
            this.lblQayta.Size = new System.Drawing.Size(120, 22);
            this.lblQayta.TabIndex = 26;
            this.lblQayta.Text = "Кайта юклаш";
            this.lblQayta.Visible = false;
            this.lblQayta.Click += new System.EventHandler(this.lblQayta_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(3, 3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(410, 22);
            this.lblStatus.TabIndex = 25;
            this.lblStatus.Text = "Малумотлар юкланмокда, илтимос кутинг...";
            this.lblStatus.Visible = false;
            // 
            // txtSom
            // 
            this.txtSom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.txtSom.Enabled = false;
            this.txtSom.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.txtSom.FormattingEnabled = true;
            this.txtSom.Location = new System.Drawing.Point(378, 30);
            this.txtSom.Name = "txtSom";
            this.txtSom.Size = new System.Drawing.Size(224, 36);
            this.txtSom.TabIndex = 24;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSend.IconChar = FontAwesome.Sharp.IconChar.PaperPlane;
            this.btnSend.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSend.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSend.IconSize = 30;
            this.btnSend.Location = new System.Drawing.Point(586, 590);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(172, 36);
            this.btnSend.TabIndex = 23;
            this.btnSend.Text = "Жўнатиш (F1)";
            this.btnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // comboFilial
            // 
            this.comboFilial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboFilial.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.comboFilial.FormattingEnabled = true;
            this.comboFilial.Location = new System.Drawing.Point(693, 30);
            this.comboFilial.Margin = new System.Windows.Forms.Padding(5);
            this.comboFilial.Name = "comboFilial";
            this.comboFilial.Size = new System.Drawing.Size(315, 34);
            this.comboFilial.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAdd.IconColor = System.Drawing.Color.Gainsboro;
            this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdd.IconSize = 30;
            this.btnAdd.Location = new System.Drawing.Point(183, 590);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(102, 36);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Кўшиш";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnQabulUlash);
            this.tabPage2.Controls.Add(this.iconButton3);
            this.tabPage2.Controls.Add(this.txtSearchFil);
            this.tabPage2.Controls.Add(this.dbgridFakturaItemSave);
            this.tabPage2.Controls.Add(this.iconPictureBox2);
            this.tabPage2.Controls.Add(this.dbgridFakturaSave);
            this.tabPage2.Controls.Add(this.iconButton1);
            this.tabPage2.Controls.Add(this.iconButton2);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1099, 626);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Сакланган фактура";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnQabulUlash
            // 
            this.btnQabulUlash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQabulUlash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(41)))), ((int)(((byte)(58)))));
            this.btnQabulUlash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQabulUlash.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnQabulUlash.IconChar = FontAwesome.Sharp.IconChar.PenAlt;
            this.btnQabulUlash.IconColor = System.Drawing.Color.Gainsboro;
            this.btnQabulUlash.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQabulUlash.IconSize = 30;
            this.btnQabulUlash.Location = new System.Drawing.Point(443, 590);
            this.btnQabulUlash.Name = "btnQabulUlash";
            this.btnQabulUlash.Size = new System.Drawing.Size(180, 36);
            this.btnQabulUlash.TabIndex = 20;
            this.btnQabulUlash.Text = "Қабулга улаш";
            this.btnQabulUlash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQabulUlash.UseVisualStyleBackColor = false;
            this.btnQabulUlash.Click += new System.EventHandler(this.btnQabulUlash_Click);
            // 
            // iconButton3
            // 
            this.iconButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton3.BackColor = System.Drawing.Color.Red;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.CalendarTimes;
            this.iconButton3.IconColor = System.Drawing.Color.WhiteSmoke;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.IconSize = 30;
            this.iconButton3.Location = new System.Drawing.Point(933, 590);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(166, 36);
            this.iconButton3.TabIndex = 19;
            this.iconButton3.Text = "Бэкор килиш";
            this.iconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton3.UseVisualStyleBackColor = false;
            this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click_1);
            // 
            // txtSearchFil
            // 
            this.txtSearchFil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchFil.AutoCompleteCustomSource = null;
            this.txtSearchFil.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtSearchFil.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtSearchFil.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtSearchFil.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtSearchFil.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtSearchFil.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.txtSearchFil.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearchFil.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtSearchFil.Image = null;
            this.txtSearchFil.IsDerivedStyle = true;
            this.txtSearchFil.Lines = null;
            this.txtSearchFil.Location = new System.Drawing.Point(40, 0);
            this.txtSearchFil.MaxLength = 32767;
            this.txtSearchFil.Multiline = false;
            this.txtSearchFil.Name = "txtSearchFil";
            this.txtSearchFil.ReadOnly = false;
            this.txtSearchFil.Size = new System.Drawing.Size(1057, 36);
            this.txtSearchFil.Style = MetroSet_UI.Enums.Style.Light;
            this.txtSearchFil.StyleManager = null;
            this.txtSearchFil.TabIndex = 17;
            this.txtSearchFil.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSearchFil.ThemeAuthor = "Narwin";
            this.txtSearchFil.ThemeName = "MetroLite";
            this.txtSearchFil.UseSystemPasswordChar = false;
            this.txtSearchFil.WatermarkText = "Филиал номи...";
            this.txtSearchFil.TextChanged += new System.EventHandler(this.metroSetTextBox2_TextChanged);
            this.txtSearchFil.KeyPressed += new System.Windows.Forms.KeyPressEventHandler(this.metroSetTextBox2_KeyPressed);
            this.txtSearchFil.Click += new System.EventHandler(this.metroSetTextBox2_Click);
            this.txtSearchFil.Validated += new System.EventHandler(this.txtSearchFil_Validated);
            // 
            // dbgridFakturaItemSave
            // 
            this.dbgridFakturaItemSave.AllowUserToAddRows = false;
            this.dbgridFakturaItemSave.AllowUserToDeleteRows = false;
            this.dbgridFakturaItemSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridFakturaItemSave.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridFakturaItemSave.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridFakturaItemSave.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridFakturaItemSave.ColumnHeadersHeight = 60;
            this.dbgridFakturaItemSave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridFakturaItemSave.Location = new System.Drawing.Point(0, 315);
            this.dbgridFakturaItemSave.MultiSelect = false;
            this.dbgridFakturaItemSave.Name = "dbgridFakturaItemSave";
            this.dbgridFakturaItemSave.ReadOnly = true;
            this.dbgridFakturaItemSave.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridFakturaItemSave.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridFakturaItemSave.Size = new System.Drawing.Size(1099, 273);
            this.dbgridFakturaItemSave.TabIndex = 18;
            this.dbgridFakturaItemSave.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridFakturaItemSave_RowPostPaint);
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(158)))), ((int)(((byte)(253)))));
            this.iconPictureBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox2.IconColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 36;
            this.iconPictureBox2.Location = new System.Drawing.Point(3, 0);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(36, 36);
            this.iconPictureBox2.TabIndex = 16;
            this.iconPictureBox2.TabStop = false;
            this.iconPictureBox2.Click += new System.EventHandler(this.iconPictureBox2_Click);
            // 
            // dbgridFakturaSave
            // 
            this.dbgridFakturaSave.AllowUserToAddRows = false;
            this.dbgridFakturaSave.AllowUserToDeleteRows = false;
            this.dbgridFakturaSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridFakturaSave.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridFakturaSave.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridFakturaSave.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridFakturaSave.ColumnHeadersHeight = 60;
            this.dbgridFakturaSave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridFakturaSave.Location = new System.Drawing.Point(0, 42);
            this.dbgridFakturaSave.MultiSelect = false;
            this.dbgridFakturaSave.Name = "dbgridFakturaSave";
            this.dbgridFakturaSave.ReadOnly = true;
            this.dbgridFakturaSave.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridFakturaSave.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridFakturaSave.Size = new System.Drawing.Size(1099, 267);
            this.dbgridFakturaSave.TabIndex = 15;
            this.dbgridFakturaSave.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgridFakturaSave_CellClick);
            this.dbgridFakturaSave.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridFakturaSave_RowPostPaint);
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(158)))), ((int)(((byte)(253)))));
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.PaperPlane;
            this.iconButton1.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(791, 590);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(136, 36);
            this.iconButton1.TabIndex = 13;
            this.iconButton1.Text = "Жўнатиш";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.PencilAlt;
            this.iconButton2.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 30;
            this.iconButton2.Location = new System.Drawing.Point(629, 590);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(156, 36);
            this.iconButton2.TabIndex = 14;
            this.iconButton2.Text = "Тахрирлаш";
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // frmFakturaTayyorlash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 661);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmFakturaTayyorlash";
            this.Text = "Фактура тайёрлаш";
            this.Load += new System.EventHandler(this.frmFakturaTayyorlash_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmFakturaTayyorlash_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dbgridFaktura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridProduct)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbgridFakturaItemSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridFakturaSave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dbgridFaktura;
        public FontAwesome.Sharp.IconButton btnCreate;
        public System.Windows.Forms.TextBox txtSearch;
        public System.Windows.Forms.DataGridView dbgridProduct;
        public System.Windows.Forms.Label lblQayta;
        public System.Windows.Forms.ComboBox txtSom;
        public System.Windows.Forms.ComboBox comboFilial;
        public FontAwesome.Sharp.IconButton btnAdd;
        public System.Windows.Forms.Label label1;
        public FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        public FontAwesome.Sharp.IconButton btnSave;
        public FontAwesome.Sharp.IconButton btnCancel;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
        public MetroSet_UI.Controls.MetroSetTextBox txtSearchFil;
        public System.Windows.Forms.DataGridView dbgridFakturaItemSave;
        public FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        public System.Windows.Forms.DataGridView dbgridFakturaSave;
        public FontAwesome.Sharp.IconButton iconButton1;
        public FontAwesome.Sharp.IconButton iconButton2;
        public FontAwesome.Sharp.IconButton iconButton3;
        public System.Windows.Forms.Label lblStatus;
        public FontAwesome.Sharp.IconButton btnSend;
        public FontAwesome.Sharp.IconButton btnDelete;
        public FontAwesome.Sharp.IconButton btnEdit;
        public System.Windows.Forms.ComboBox txtDollar;
        public System.Windows.Forms.Label label3;
        public FontAwesome.Sharp.IconButton btnQabulUlash;
    }
}