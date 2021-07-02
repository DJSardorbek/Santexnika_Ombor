namespace JayhunOmbor
{
    partial class frmCreateRecieve
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
            this.btnNewGroup = new FontAwesome.Sharp.IconButton();
            this.txtDeliver = new System.Windows.Forms.TextBox();
            this.btnStart = new FontAwesome.Sharp.IconButton();
            this.btnCancel = new FontAwesome.Sharp.IconButton();
            this.txtRecieveName = new System.Windows.Forms.TextBox();
            this.comboDeliver = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboFilial = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnNewGroup
            // 
            this.btnNewGroup.BackColor = System.Drawing.Color.Red;
            this.btnNewGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewGroup.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNewGroup.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnNewGroup.IconColor = System.Drawing.Color.Black;
            this.btnNewGroup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNewGroup.IconSize = 30;
            this.btnNewGroup.Location = new System.Drawing.Point(635, 213);
            this.btnNewGroup.Name = "btnNewGroup";
            this.btnNewGroup.Size = new System.Drawing.Size(70, 37);
            this.btnNewGroup.TabIndex = 24;
            this.btnNewGroup.Text = "Янги";
            this.btnNewGroup.UseVisualStyleBackColor = false;
            this.btnNewGroup.Click += new System.EventHandler(this.btnNewGroup_Click);
            // 
            // txtDeliver
            // 
            this.txtDeliver.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDeliver.Location = new System.Drawing.Point(239, 213);
            this.txtDeliver.Name = "txtDeliver";
            this.txtDeliver.Size = new System.Drawing.Size(390, 37);
            this.txtDeliver.TabIndex = 23;
            this.txtDeliver.Visible = false;
            this.txtDeliver.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeliver_KeyDown);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.btnStart.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnStart.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnStart.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btnStart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStart.Location = new System.Drawing.Point(324, 339);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(172, 33);
            this.btnStart.TabIndex = 21;
            this.btnStart.Text = "Кабулни бошлаш";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(158)))), ((int)(((byte)(253)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCancel.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancel.Location = new System.Drawing.Point(502, 339);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(203, 33);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = " (Esc) Бэкор килиш";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtRecieveName
            // 
            this.txtRecieveName.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtRecieveName.Location = new System.Drawing.Point(173, 146);
            this.txtRecieveName.Name = "txtRecieveName";
            this.txtRecieveName.Size = new System.Drawing.Size(528, 37);
            this.txtRecieveName.TabIndex = 19;
            this.txtRecieveName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRecieveName_KeyDown);
            // 
            // comboDeliver
            // 
            this.comboDeliver.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboDeliver.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboDeliver.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboDeliver.FormattingEnabled = true;
            this.comboDeliver.Location = new System.Drawing.Point(239, 213);
            this.comboDeliver.Name = "comboDeliver";
            this.comboDeliver.Size = new System.Drawing.Size(390, 37);
            this.comboDeliver.TabIndex = 20;
            this.comboDeliver.SelectedIndexChanged += new System.EventHandler(this.comboDeliver_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(34, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 29);
            this.label2.TabIndex = 18;
            this.label2.Text = "Етказиб берувчи:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(34, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 29);
            this.label1.TabIndex = 17;
            this.label1.Text = "Кабул номи :";
            // 
            // lblPhone
            // 
            this.lblPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Calibri", 18F);
            this.lblPhone.Location = new System.Drawing.Point(35, 284);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(182, 29);
            this.lblPhone.TabIndex = 25;
            this.lblPhone.Text = "Етказиб.бер.тел:";
            this.lblPhone.Visible = false;
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Font = new System.Drawing.Font("Calibri", 18F);
            this.txtPhone.Location = new System.Drawing.Point(239, 281);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(462, 37);
            this.txtPhone.TabIndex = 26;
            this.txtPhone.Visible = false;
            this.txtPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhone_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(36, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 29);
            this.label3.TabIndex = 27;
            this.label3.Text = "Филиал:";
            // 
            // comboFilial
            // 
            this.comboFilial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboFilial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboFilial.Font = new System.Drawing.Font("Calibri", 18F);
            this.comboFilial.FormattingEnabled = true;
            this.comboFilial.Location = new System.Drawing.Point(173, 82);
            this.comboFilial.Name = "comboFilial";
            this.comboFilial.Size = new System.Drawing.Size(528, 37);
            this.comboFilial.TabIndex = 28;
            // 
            // frmCreateRecieve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 396);
            this.Controls.Add(this.comboFilial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.btnNewGroup);
            this.Controls.Add(this.txtDeliver);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtRecieveName);
            this.Controls.Add(this.comboDeliver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmCreateRecieve";
            this.Padding = new System.Windows.Forms.Padding(33, 102, 33, 34);
            this.Text = "Кабулни бошлаш";
            this.Load += new System.EventHandler(this.frmCreateRecieve_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmCreateRecieve_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnNewGroup;
        private System.Windows.Forms.TextBox txtDeliver;
        private FontAwesome.Sharp.IconButton btnStart;
        private FontAwesome.Sharp.IconButton btnCancel;
        private System.Windows.Forms.TextBox txtRecieveName;
        private System.Windows.Forms.ComboBox comboDeliver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboFilial;
    }
}