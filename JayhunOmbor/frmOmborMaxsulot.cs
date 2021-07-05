using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using RestClient.Net.Abstractions;
using BarcodeLib;
using System.Drawing.Printing;

namespace JayhunOmbor
{
    public partial class frmOmborMaxsulot : Form
    {
        public frmOmborMaxsulot()
        {
            InitializeComponent();
        }

        BarcodeLib.Barcode barCode = new BarcodeLib.Barcode();

        public static DataTable tbProduct;
        public static CurrencyManager managerProduct;
        public static async Task<string> GetObject(string restCallURL)
        {
            HttpClient apiCallClient = new HttpClient();
            string authToken = "token 62115f83e1c1e8b588fa419330976ea6012d1cd4";
            HttpRequestMessage apirequest = new HttpRequestMessage(HttpMethod.Get, restCallURL);
            apirequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apirequest.Headers.Add("Authorization", authToken);
            HttpResponseMessage apiCallResponse = await apiCallClient.SendAsync(apirequest);

            string requestresponse = await apiCallResponse.Content.ReadAsStringAsync();
            return requestresponse;
        }

        public async void frmOmborMaxsulot_Load(object sender, EventArgs e)
        {
            comboSearch.SelectedIndex = 0;
            //dbgridProduct.DataSource = Form1.tbProduct;
            tbProduct = new DataTable();
            tbProduct.Columns.Add("Махсулот_ид", typeof(int));
            tbProduct.Columns.Add("Гурух");
            tbProduct.Columns.Add("Махсулот_Номи");
            tbProduct.Columns.Add("Ишлаб_чикарувчи");
            tbProduct.Columns.Add("Сўм");
            tbProduct.Columns.Add("Доллар");
            tbProduct.Columns.Add("Курс");
            tbProduct.Columns.Add("Микдори");
            tbProduct.Columns.Add("Улчов");
            tbProduct.Columns.Add("Штрих_код");
            dbgridProduct.DataSource = tbProduct;
            dbgridProduct.Columns[0].Visible = false;
            dbgridProduct.Columns[1].Visible = false;
            dbgridProduct.Columns[3].Visible = false;
            dbgridProduct.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            /*try
            {
                Form1 form1 = new Form1();
                form1.btnProduct.Enabled = false;
                lblStatus.Visible = true;
                tbProduct = new DataTable();
                tbProduct.Columns.Add("Махсулот_ид", typeof(int));
                tbProduct.Columns.Add("Гурух");
                tbProduct.Columns.Add("Махсулот_Номи");
                tbProduct.Columns.Add("Ишлаб_чикарувчи");
                tbProduct.Columns.Add("Сўм");
                tbProduct.Columns.Add("Доллар");
                tbProduct.Columns.Add("Курс");
                tbProduct.Columns.Add("Микдори");
                tbProduct.Columns.Add("Штрих_код");
                
                string productContent = await GetObject("http://atrakt.backoffice.uz/ipa/product/");
                lblStatus.Visible = false;
                form1.btnProduct.Enabled = true;
                JArray productArray = JArray.Parse(productContent);
                if (productArray != null)
                {
                    foreach (var productItem in productArray)
                    {
                        DataRow rowProduct = tbProduct.NewRow();
                        rowProduct["Махсулот_ид"] = productItem["id"];
                        rowProduct["Гурух"] = productItem["group"];
                        rowProduct["Махсулот_Номи"] = productItem["name"];
                        rowProduct["Ишлаб_чикарувчи"] = productItem["preparer"];
                        rowProduct["Сўм"] = productItem["som"];
                        rowProduct["Доллар"] = productItem["dollar"];
                        rowProduct["Курс"] = productItem["kurs"];
                        rowProduct["Микдори"] = productItem["quantity"];
                        rowProduct["Штрих_код"] = productItem["barcode"];
                        
                        tbProduct.Rows.Add(rowProduct);
                    }
                }
                managerProduct = (CurrencyManager)BindingContext[tbProduct];
                dbgridProduct.DataSource = tbProduct;
                dbgridProduct.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                dbgridProduct.Columns[0].Visible = false;
                dbgridProduct.Columns[1].Visible = false;
                lblName.Text = tbProduct.Rows[managerProduct.Position]["Махсулот_Номи"].ToString();
                txtBarcode.Text = tbProduct.Rows[managerProduct.Position]["Штрих_код"].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Visible = false;
                Form1 form = new Form1();
                form.btnProduct.Enabled = true;
                lblQayta.Visible = true;
            }*/
        }

        private void dbgridProduct_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridProduct.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Y + 4);
            }
        }

        public static DataTable tbPr;
        public static CurrencyManager managerPr;
        public static bool dv = false;

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (Form1.tbProduct.Rows.Count > 0 && txtSearch.Text.Length > 2)
            {
                DataRow[] rows;
                if (comboSearch.SelectedIndex == 0)
                {
                    rows = Form1.tbProduct.Select("Махсулот_Номи like '%" + txtSearch.Text + "%'");
                }
                else
                {
                    rows = Form1.tbProduct.Select("Штрих_код like '%" + txtSearch.Text + "%'");
                }
                tbPr = new DataTable();
                tbPr.Columns.Add("Махсулот_ид", typeof(int));
                tbPr.Columns.Add("Махсулот_Номи");
                tbPr.Columns.Add("Ишлаб_чикарувчи");
                tbPr.Columns.Add("Сўм");
                tbPr.Columns.Add("Доллар");
                tbPr.Columns.Add("Курс");
                tbPr.Columns.Add("Микдори");
                tbPr.Columns.Add("Улчов");
                tbPr.Columns.Add("Штрих_код");
                tbPr.Columns.Add("Гурух");
                foreach (var item in rows)
                {
                    DataRow row = tbPr.NewRow();
                    row["Махсулот_ид"] = item["Махсулот_ид"];
                    row["Махсулот_Номи"] = item["Махсулот_Номи"];
                    row["Ишлаб_чикарувчи"] = item["Ишлаб_чикарувчи"];
                    row["Сўм"] = item["Сўм"];
                    row["Доллар"] = item["Доллар"];
                    row["Курс"] = item["Курс"];
                    row["Микдори"] = item["Микдори"];
                    row["Улчов"] = item["Улчов"];
                    row["Штрих_код"] = item["Штрих_код"];
                    row["Гурух"] = item["Гурух"];
                    tbPr.Rows.Add(row);
                }
                dbgridProduct.DataSource = tbPr;
                dbgridProduct.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                managerPr = (CurrencyManager)BindingContext[tbPr];
                tbPr.Dispose();
                dv = true;
            }
            else
            {
                dbgridProduct.DataSource = tbProduct;
                dv = false;
            }
        }
        public class Product
        {
            public string name { get; set; }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void iconButton1_Click(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Trim() == "")
            {
                return;
            }
            if (txtWidth.Text.Trim() == "")
            {
                return;
            }
            if (txtHeight.Text.Trim() == "")
            {
                return;
            }

            errorProvider1.Clear();
            int nW = Convert.ToInt32(txtWidth.Text.Trim());
            int nH = Convert.ToInt32(txtHeight.Text.Trim());

            barCode.Alignment = BarcodeLib.AlignmentPositions.CENTER;

            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            type = BarcodeLib.TYPE.CODE128;
            try
            {
                if (type != BarcodeLib.TYPE.UNSPECIFIED)
                {
                    barCode.IncludeLabel = true;
                    barCode.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType),
                        "RotateNoneFlipNone", true);
                    pictureBarcode.Image = barCode.Encode(type, txtBarcode.Text, Color.Black, Color.White, nW, nH);

                }
                pictureBarcode.Width = pictureBarcode.Image.Width;
                pictureBarcode.Height = pictureBarcode.Image.Height;
                lblBarName.Text = lblName.Text;
                if (lblBarName.Text.Length - pictureBarcode.Width/2 >=0)
                {
                    lblBarName.Text = lblName.Text.Substring(0, pictureBarcode.Width/2);
                    lblBarName.Text += "\n" + lblName.Text.Substring(pictureBarcode.Width/2);
                }
                
                panel1.Width = pictureBarcode.Width;
                panel1.Height = pictureBarcode.Image.Height + 42;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printBarCode()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Doc_PrintPage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBarcode.Width, pictureBarcode.Height);
            pictureBarcode.DrawToBitmap(bm, new Rectangle(0, 0, pictureBarcode.Width, pictureBarcode.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Print(this.panel1);
            //{
            //    printBarCode();
            //}

           
        }
        PrintDialog prntprvw = new PrintDialog();
        PrintDocument pntdoc = new PrintDocument();
        public void Print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            panel1 = pnl;
            getprintarea(pnl);
            prntprvw.Document = pntdoc;
            pntdoc.PrintPage += new PrintPageEventHandler(pntdoc_printpage);
            if (prntprvw.ShowDialog() == DialogResult.OK)
            {
                pntdoc.Print();
            }

        }
        public void pntdoc_printpage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }
        Bitmap memoryimg;
        public void getprintarea(Panel pnl)
        {
            memoryimg = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memoryimg, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }
        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
        }

        private void dbgridProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dbgridProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if(dbgridProduct.Rows.Count > 0)
                {
                    e.SuppressKeyPress = true;
                    int count = dbgridProduct.CurrentCell.RowIndex;
                    if (dbgridProduct.Rows.Count > 0)
                    {
                        if (dv == false)
                        {
                            string first = "", last = "";
                            string s = Form1.tbProduct.Rows[Form1.managerProduct.Position]["Махсулот_Номи"].ToString();
                            if (s.Length > 23)
                            {
                                first = s.Substring(0, 23);
                                last = s.Substring(24);
                                s = first + "\n" + last;
                            }
                            lblName.Text = s;
                            txtBarcode.Text = Form1.tbProduct.Rows[Form1.managerProduct.Position]["Штрих_код"].ToString();
                        }
                        else
                        {
                            string first = "", last = "";
                            string s = tbPr.Rows[managerPr.Position]["Махсулот_Номи"].ToString();
                            if (s.Length > 23)
                            {
                                first = s.Substring(0, 23);
                                last = s.Substring(24);
                                s = first + "\n" + last;
                            }
                            lblName.Text = s;
                            txtBarcode.Text = tbPr.Rows[managerPr.Position]["Штрих_код"].ToString();
                        }
                        iconButton1_Click(sender, e);
                    }
                }
            }
        }

        private void dbgridProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dv == false)
            {
                string first = "", last = "";
                string s = Form1.tbProduct.Rows[Form1.managerProduct.Position]["Махсулот_Номи"].ToString();
                if (s.Length > 23)
                {
                    first = s.Substring(0, 23);
                    last = s.Substring(24);
                    s = first + "\n" + last;
                }
                lblName.Text = s;
                txtBarcode.Text = Form1.tbProduct.Rows[Form1.managerProduct.Position]["Штрих_код"].ToString();
            }
            else
            {
                string first = "", last = "";
                string s = tbPr.Rows[managerPr.Position]["Махсулот_Номи"].ToString();
                if (s.Length > 23)
                {
                    first = s.Substring(0, 23);
                    last = s.Substring(24);
                    s = first + "\n" + last;
                }
                lblName.Text = s;
                txtBarcode.Text = tbPr.Rows[managerPr.Position]["Штрих_код"].ToString();
            }
        }

        public void lblQayta_Click(object sender, EventArgs e)
        {
            frmOmborMaxsulot_Load(sender, e);
            lblQayta.Visible = false;
        }

        private void frmOmborMaxsulot_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void frmOmborMaxsulot_SizeChanged(object sender, EventArgs e)
        {
            if (Width > 1125)
            {
                dbgridProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                dbgridProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
        public static string print = "";
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(lblName.Text, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(10, 10));
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dbgridProduct.Focus();
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
           
        }
    }
}