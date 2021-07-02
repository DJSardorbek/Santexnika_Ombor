using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JayhunOmbor
{
    public partial class frmFakturaTayyorlash : Form
    {
        public frmFakturaTayyorlash()
        {
            InitializeComponent();
        }
        public static bool Faktura = false;
        public static bool faktura_edit = false;
        public static string faktura_id = "";
        public static string filial_id = "";
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public static DataTable tbFilial, tbFaktura, tbFakturaItem, tbFakturaSave, tbFakturaSumma;
        public static CurrencyManager managerFilial, managerFaktura, managerFakturaSave;
        public static DataTable tbProduct;
        public static CurrencyManager managerProduct;
        WaitForm waitForm = new WaitForm();
        public async void frmFakturaTayyorlash_Load(object sender, EventArgs e)
        {
            waitForm.Show(this);
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
            faktura_id = Form1.faktura_id;
            faktura_edit = true;
            /*try
            {
                Form1 form1 = new Form1();
                form1.btnFakturaTayy.Enabled = false;
                lblStatus.Visible = true;
                tbProduct = new DataTable();
                tbProduct.Columns.Add("Махсулот_ид", typeof(int));
                tbProduct.Columns.Add("Махсулот_Номи");
                tbProduct.Columns.Add("Ишлаб_чикарувчи");
                tbProduct.Columns.Add("Сўм");
                tbProduct.Columns.Add("Доллар");
                tbProduct.Columns.Add("Курс");
                tbProduct.Columns.Add("Микдори");
                tbProduct.Columns.Add("Штрих_код");
                tbProduct.Columns.Add("Гурух");
                string productContent = await GetObject("http://santexnika.backoffice.uz/api/product/");
                lblStatus.Visible = false;
                form1.btnFakturaTayy.Enabled = true;
                JArray productArray = JArray.Parse(productContent);
                if (productArray != null)
                {
                    foreach (var productItem in productArray)
                    {
                        DataRow rowProduct = tbProduct.NewRow();
                        rowProduct["Махсулот_ид"] = productItem["id"];
                        rowProduct["Махсулот_Номи"] = productItem["name"];
                        rowProduct["Ишлаб_чикарувчи"] = productItem["preparer"];
                        rowProduct["Сўм"] = productItem["som"];
                        rowProduct["Доллар"] = productItem["dollar"];
                        rowProduct["Курс"] = productItem["kurs"];
                        rowProduct["Микдори"] = productItem["quantity"];
                        rowProduct["Штрих_код"] = productItem["barcode"];
                        rowProduct["Гурух"] = productItem["group"];
                        tbProduct.Rows.Add(rowProduct);
                    }
                }
                managerProduct = (CurrencyManager)BindingContext[tbProduct];
                dbgridProduct.DataSource = tbProduct;
                dbgridProduct.Columns[0].Visible = false;
                dbgridProduct.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                faktura_id = Form1.faktura_id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Form1 form = new Form1();
                form.btnFakturaTayy.Enabled = true;
                lblQayta.Visible = true;
                lblStatus.Visible = false;
            }
            */
            if (Form1.filial == false)
            {
                try
                {
                    lblStatus.Visible = true;
                    tbFilial = new DataTable();
                    tbFilial.Columns.Add("id", typeof(int));
                    tbFilial.Columns.Add("name");
                    tbFilial.Columns.Add("address");
                    string FilialContent = await GetObject("http://santexnika.backoffice.uz/api/filial/");
                    lblStatus.Visible = false;
                    JArray filialArray = JArray.Parse(FilialContent);
                    if (filialArray != null)
                    {
                        foreach (var filialItem in filialArray)
                        {
                            DataRow rowProduct = tbFilial.NewRow();
                            rowProduct["id"] = filialItem["id"];
                            rowProduct["name"] = filialItem["name"];
                            rowProduct["address"] = filialItem["address"];
                            tbFilial.Rows.Add(rowProduct);
                        }
                    }
                    managerFilial = (CurrencyManager)BindingContext[tbFilial];
                    comboFilial.DataSource = tbFilial;
                    comboFilial.DisplayMember = "name";
                    Form1.filial = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblQayta.Visible = true;
                    lblStatus.Visible = false;
                }

            }
            else
            {
                comboFilial.DataSource = tbFilial;
                comboFilial.DisplayMember = "name";
            }
            if(faktura_id !="")
            {
                FakturaShow(faktura_id);
                btnCreate.Enabled = false;
                f5 = false;
                comboFilial.Enabled = false;
            }
            waitForm.Close();
            this.Focus();
            txtSearch.Focus();
        }

        private void dbgridProduct_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //using (SolidBrush b = new SolidBrush(dbgridProduct.RowHeadersDefaultCellStyle.ForeColor))
            //{
            //    e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Y + 4);
            //}
        }
        public static bool dv = false;
        public static CurrencyManager managerPr;
        public static DataView DvProduct;
        public static DataTable tbPr;
        private void metroSetTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (Form1.tbProduct.Rows.Count > 0 && txtSearch.Text.Length >= 2)
            {
                DataRow[] rows;
                try
                {
                    int number = int.Parse(txtSearch.Text, CultureInfo.InvariantCulture);
                    rows = Form1.tbProduct.Select("Штрих_код like '%" + txtSearch.Text + "%'");

                    tbPr = new DataTable();
                    tbPr.Columns.Add("Махсулот_ид", typeof(int));
                    tbPr.Columns.Add("Гурух");
                    tbPr.Columns.Add("Махсулот_Номи");
                    tbPr.Columns.Add("Ишлаб_чикарувчи");
                    tbPr.Columns.Add("Сўм");
                    tbPr.Columns.Add("Доллар");
                    tbPr.Columns.Add("Курс");
                    tbPr.Columns.Add("Микдори");
                    tbPr.Columns.Add("Улчов");
                    tbPr.Columns.Add("Штрих_код");

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

                    dbgridProduct.MaximumSize = new Size(this.dbgridProduct.Width, 300);
                    dbgridProduct.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dbgridProduct.Columns[0].Visible = false;
                    dbgridProduct.Columns[1].Visible = false;

                    dbgridProduct.Columns[3].Visible = false;
                    dbgridProduct.RowHeadersVisible = false;
                    dbgridProduct.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                    dbgridProduct.Visible = true;
                    managerPr = (CurrencyManager)BindingContext[tbPr];
                    tbPr.Dispose();
                    dv = true;

                    if(tbPr.Rows.Count == 0)
                    {
                        rows = Form1.tbProduct.Select("Махсулот_Номи like '%" + txtSearch.Text + "%'");
                        tbPr = new DataTable();
                        tbPr.Columns.Add("Махсулот_ид", typeof(int));
                        tbPr.Columns.Add("Гурух");
                        tbPr.Columns.Add("Махсулот_Номи");
                        tbPr.Columns.Add("Ишлаб_чикарувчи");
                        tbPr.Columns.Add("Сўм");
                        tbPr.Columns.Add("Доллар");
                        tbPr.Columns.Add("Курс");
                        tbPr.Columns.Add("Микдори");
                        tbPr.Columns.Add("Улчов");
                        tbPr.Columns.Add("Штрих_код");

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

                        dbgridProduct.MaximumSize = new Size(this.dbgridProduct.Width, 300);
                        dbgridProduct.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dbgridProduct.Columns[0].Visible = false;
                        dbgridProduct.Columns[1].Visible = false;

                        dbgridProduct.Columns[3].Visible = false;
                        dbgridProduct.RowHeadersVisible = false;
                        dbgridProduct.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                        dbgridProduct.Visible = true;
                        managerPr = (CurrencyManager)BindingContext[tbPr];
                        tbPr.Dispose();
                        dv = true;
                    }
                }
                catch (Exception)
                {
                    rows = Form1.tbProduct.Select("Махсулот_Номи like '%" + txtSearch.Text + "%'");
                    tbPr = new DataTable();
                    tbPr.Columns.Add("Махсулот_ид", typeof(int));
                    tbPr.Columns.Add("Гурух");
                    tbPr.Columns.Add("Махсулот_Номи");
                    tbPr.Columns.Add("Ишлаб_чикарувчи");
                    tbPr.Columns.Add("Сўм");
                    tbPr.Columns.Add("Доллар");
                    tbPr.Columns.Add("Курс");
                    tbPr.Columns.Add("Микдори");
                    tbPr.Columns.Add("Улчов");
                    tbPr.Columns.Add("Штрих_код");

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

                    dbgridProduct.MaximumSize = new Size(this.dbgridProduct.Width, 300);
                    dbgridProduct.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dbgridProduct.Columns[0].Visible = false;
                    dbgridProduct.Columns[1].Visible = false;

                    dbgridProduct.Columns[3].Visible = false;
                    dbgridProduct.RowHeadersVisible = false;
                    dbgridProduct.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                    dbgridProduct.Visible = true;
                    managerPr = (CurrencyManager)BindingContext[tbPr];
                    tbPr.Dispose();
                    dv = true;
                }
            }
            else
            {
                dbgridProduct.Visible = false;
                dbgridProduct.DataSource = tbProduct;
                dbgridProduct.MaximumSize = new Size(this.dbgridProduct.Width, 300);
                dbgridProduct.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dbgridProduct.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                dv = false;
            }
        }
        public static async Task<string> GetObject(string restCallURL)
        {
            HttpClient apiCallClient = new HttpClient();
            string authToken = "token 28aeccd6cbbb18b16fddf2967d0b35242ad6a0a3";
            HttpRequestMessage apirequest = new HttpRequestMessage(HttpMethod.Get, restCallURL);
            apirequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apirequest.Headers.Add("Authorization", authToken);
            HttpResponseMessage apiCallResponse = await apiCallClient.SendAsync(apirequest);

            string requestresponse = await apiCallResponse.Content.ReadAsStringAsync();
            return requestresponse;
        }

        static async Task<string> PostURI(Uri u, HttpContent c)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "token 28aeccd6cbbb18b16fddf2967d0b35242ad6a0a3");
                try
                {
                    HttpResponseMessage result = await client.PostAsync(u, c);
                    if (result.IsSuccessStatusCode)
                    {
                        using (HttpContent content = result.Content)
                        {
                            response = await content.ReadAsStringAsync();
                        }
                    }
                    else
                    {
                        response = "Error!";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return response;
        }

        public void iconButton3_Click(object sender, EventArgs e)
        {
            if(f5)
            {
                MessageBox.Show("Фактура яратилмаган!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool isopen = false;
            foreach (Form f1 in Application.OpenForms)
            {
                if (f1.Text == "Корзинка")
                {
                    isopen = true;
                    f1.BringToFront();
                    break;
                }
            }
            if (isopen == false)
            {
                frmFakturaAddProduct fakturaAddProduct = new frmFakturaAddProduct();
                if (dv == false)
                {
                    fakturaAddProduct.name = tbProduct.Rows[managerProduct.Position]["Махсулот_Номи"].ToString();
                    fakturaAddProduct.som = tbProduct.Rows[managerProduct.Position]["Сўм"].ToString();
                    fakturaAddProduct.dollar = tbProduct.Rows[managerProduct.Position]["Доллар"].ToString();
                    fakturaAddProduct.kurs = tbProduct.Rows[managerProduct.Position]["Курс"].ToString();
                    fakturaAddProduct.quanOmbor = tbProduct.Rows[managerProduct.Position]["Микдори"].ToString();

                }
                else
                {
                    fakturaAddProduct.name = tbPr.Rows[managerPr.Position]["Махсулот_Номи"].ToString();
                    fakturaAddProduct.som = tbPr.Rows[managerPr.Position]["Сўм"].ToString();
                    fakturaAddProduct.dollar = tbPr.Rows[managerPr.Position]["Доллар"].ToString();
                    fakturaAddProduct.kurs = tbPr.Rows[managerPr.Position]["Курс"].ToString();
                    fakturaAddProduct.quanOmbor = tbPr.Rows[managerPr.Position]["Микдори"].ToString();
                }
                fakturaAddProduct.ShowDialog();
                if (tbFaktura.Rows.Count > 0)
                    tbFaktura.Clear();
                FakturaShow(faktura_id);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public class Fakturaobject
        {
            public int id { set; get; }
            public string date { set; get; }
            public double summa { set; get; }
            public int status { set; get; }
            public int difference { set; get; }
            public int filial { set; get; }
        }

        private void dbgridFakturaSave_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridFakturaSave.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Y + 4);
            }
        }

        private void dbgridFakturaItemSave_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridFakturaItemSave.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Y + 4);
            }
        }

        private void dbgridFaktura_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridFaktura.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Y + 4);
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            if (faktura_id != "")
            {
                if (tbFaktura.Rows.Count > 0)
                {
                    try
                    {
                        tbFaktura.Clear();
                        tbFakturaSumma.Clear();
                    }
                    catch (Exception) { }
                }
                btnCreate.Enabled = true;
                f5 = true;
                comboFilial.Enabled = true;
                Form1.faktura = false;
                faktura_id = "";
                Form1.faktura_id = "";
                MessageBox.Show("Фактура саклангалар рўйхатига кўшилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static bool cell = false;
        private async void dbgridFakturaSave_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cell == false)
            {
                cell = true;
                if(dv1 == false)
                {
                    if (tbFakturaSave.Rows.Count > 0)
                    {
                        if (tbFakturaItem.Rows.Count > 0) { tbFakturaItem.Clear(); }
                        else
                        {
                            tbFakturaItem = new DataTable();
                            tbFakturaItem.Columns.Add("Фактура");
                            tbFakturaItem.Columns.Add("Махсулот");
                            tbFakturaItem.Columns.Add("Сум");
                            tbFakturaItem.Columns.Add("Доллар");
                            tbFakturaItem.Columns.Add("Микдори");
                        }
                        try
                        {
                            string url = "http://santexnika.backoffice.uz/api/fakturaitem/st1/?fak=" + tbFakturaSave.Rows[managerFakturaSave.Position]["Фактура_ид"].ToString();
                            string fakturaItemContent = await GetObject(url);
                            List<FakturaItemAdd> fakturaItemArray = JsonConvert.DeserializeObject<List<FakturaItemAdd>>(fakturaItemContent);
                            if (fakturaItemArray != null)
                            {
                                foreach (var fakturaItem in fakturaItemArray)
                                {
                                    DataRow rowFakturaItem = tbFakturaItem.NewRow();
                                    rowFakturaItem["Фактура"] = fakturaItem.faktura;
                                    rowFakturaItem["Махсулот"] = fakturaItem.name;
                                    rowFakturaItem["Сум"] = fakturaItem.som;
                                    rowFakturaItem["Доллар"] = fakturaItem.dollar;
                                    rowFakturaItem["Микдори"] = fakturaItem.quantity;
                                    tbFakturaItem.Rows.Add(rowFakturaItem);
                                }
                            }
                            dbgridFakturaItemSave.DataSource = tbFakturaItem;
                            dbgridFakturaItemSave.Columns[0].Visible = false;
                            dbgridFakturaItemSave.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cell = false;
                            return;
                        }
                    }
                }
                
                else
                {
                    if (tbFkSave.Rows.Count > 0)
                    {
                        if (tbFakturaItem.Rows.Count > 0) { tbFakturaItem.Clear(); }
                        else
                        {
                            tbFakturaItem = new DataTable();
                            tbFakturaItem.Columns.Add("Фактура");
                            tbFakturaItem.Columns.Add("Махсулот");
                            tbFakturaItem.Columns.Add("Сум");
                            tbFakturaItem.Columns.Add("Доллар");
                            tbFakturaItem.Columns.Add("Микдори");
                        }
                        try
                        {
                            string url = "http://santexnika.backoffice.uz/api/fakturaitem/st1/?fak=" + tbFkSave.Rows[managerFkSave.Position]["Фактура_ид"].ToString();
                            string fakturaItemContent = await GetObject(url);
                            List<FakturaItemAdd> fakturaItemArray = JsonConvert.DeserializeObject<List<FakturaItemAdd>>(fakturaItemContent);
                            if (fakturaItemArray != null)
                            {
                                foreach (var fakturaItem in fakturaItemArray)
                                {
                                    DataRow rowFakturaItem = tbFakturaItem.NewRow();
                                    rowFakturaItem["Фактура"] = fakturaItem.faktura;
                                    rowFakturaItem["Махсулот"] = fakturaItem.name;
                                    rowFakturaItem["Сум"] = fakturaItem.som;
                                    rowFakturaItem["Доллар"] = fakturaItem.dollar;
                                    rowFakturaItem["Микдори"] = fakturaItem.quantity;
                                    tbFakturaItem.Rows.Add(rowFakturaItem);
                                }
                            }
                            dbgridFakturaItemSave.DataSource = tbFakturaItem;
                            dbgridFakturaItemSave.Columns[0].Visible = false;
                            dbgridFakturaItemSave.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cell = false;
                            return;
                        }
                    }
                }

                cell = false;
            }

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (managerFakturaSave.Count > 0)
            {
                btnCreate.Enabled = false;
                f5 = false;
                comboFilial.Enabled = false;
                faktura_edit = true;
                string faktura = tbFakturaSave.Rows[managerFakturaSave.Position]["Фактура_ид"].ToString();
                FakturaShow(faktura);
                faktura_id = faktura;
                Form1.faktura_id = faktura;
                MessageBox.Show("Фактура фактура тайёрлаш бўлимига ўтказилди!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl1.SelectedIndex = 0;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Uri u = new Uri("http://santexnika.backoffice.uz/api/faktura/st/");
                string faktura = tbFakturaSave.Rows[managerFakturaSave.Position]["Фактура_ид"].ToString();
                var payload = "{\"faktura\": \"" + faktura + "\"}";//
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                var t = Task.Run(() => PostURI(u, content));
                t.Wait();
                if (t.Result != "Error!" && t.Result.Length != 0)
                {
                    Form1.faktura = false;
                    tabControl1_Click(sender, e);
                    MessageBox.Show("Фактура муваффакиятли жўнатилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1.fakturaSend = false; // Faktura bo'limiuchun
                }
                else
                {
                    MessageBox.Show("Сэрвэр билан богланишда хатолик, илтимос интэрнэтни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public static bool send = false;
        public void btnSend_Click(object sender, EventArgs e)
        {
            if (faktura_id != "" && tbFaktura.Rows.Count > 0)
            {
                if (send == false)
                {
                    send = true;
                    try
                    {
                        Uri u = new Uri("http://santexnika.backoffice.uz/api/faktura/st/");
                        string faktura = tbFaktura.Rows[managerFaktura.Position]["Фактура_ид"].ToString();
                        var payload = "{\"faktura\": \"" + faktura + "\"}";//
                        HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                        var t = Task.Run(() => PostURI(u, content));
                        t.Wait();
                        if (t.Result != "Error!" && t.Result.Length != 0)
                        {
                            Form1.faktura = false; // saqlanganalar uchun
                            tbFaktura.Clear();
                            btnCreate.Enabled = true;
                            comboFilial.Enabled = true;
                            faktura_id = "";
                            Form1.faktura_id = "";
                            try { tbFakturaSumma.Clear(); } catch (Exception) { }
                            MessageBox.Show("Фактура муваффакиятли жўнатилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Form1.fakturaSend = false; // Faktura bo'limiuchun
                        }
                        else
                        {
                            MessageBox.Show("Сэрвэр билан богланишда хатолик, илтимос интэрнэтни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    send = false;
                }
            }

        }

        private void metroSetTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void lblQayta_Click(object sender, EventArgs e)
        {
            if(fakturaShow)
            {
                FakturaShow(faktura_id);
            }
            else
            {
                frmFakturaTayyorlash_Load(sender, e);
            }
            lblQayta.Visible = false;
        }

        public static bool form1 = false;
        public static DataTable tbFkSave;
        public static CurrencyManager managerFkSave;
        private async void metroSetTextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        public string DoubleToStr(string s)
        {
            if (s.IndexOf(',') > -1)
            {
                int index = s.IndexOf(',');
                string first = s.Substring(0, index);
                string last = s.Substring(index + 1);
                s = first + "." + last;
            }
            return s;
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            if (faktura_id == "") return;
            try
            {
                string url = "http://santexnika.backoffice.uz/api/faktura/otkaz/?fak=" + faktura_id;
                string responce = await GetObject(url);
                try
                {
                    int CountFaktura = managerFaktura.Count;
                    managerFaktura.Position = 0;
                    string quan_faktura = "", fakproduct_id = "", quan_product = "";
                    for (int i = 0; i < CountFaktura; i++)
                    {
                        quan_faktura = tbFaktura.Rows[managerFaktura.Position]["Микдори"].ToString();//
                        quan_faktura = DoubleToStr(quan_faktura);
                        fakproduct_id = tbFaktura.Rows[managerFaktura.Position]["product"].ToString();
                        DataRow row_product = Form1.tbProduct.Select("Махсулот_ид='" + fakproduct_id + "'", "Махсулот_ид ASC").Last();
                        quan_product = row_product["Микдори"].ToString();//
                        quan_product = DoubleToStr(quan_product);

                        double Dquan_faktura = double.Parse(quan_faktura);
                        double Dquan_product = double.Parse(quan_product);
                        double result_quan = Dquan_faktura + Dquan_product;
                        string str_rsquan = result_quan.ToString();
                        str_rsquan = DoubleToStr(str_rsquan);
                        row_product["Микдори"] = str_rsquan;
                        row_product.EndEdit();
                        Form1.tbProduct.AcceptChanges();
                        managerFaktura.Position++;

                    }
                    tbFaktura.Clear();
                    try
                    {
                        tbFakturaSumma.Clear();
                        tbFakturaSumma.Dispose();
                    }
                    catch (Exception) { }
                }
                catch (Exception) { }
                btnCreate.Enabled = true;
                f5 = true;
                comboFilial.Enabled = true;
                Form1.faktura = false;
                faktura_id = "";
                Form1.faktura_id = "";
                //frmFakturaTayyorlash_Load(sender, e);
                MessageBox.Show("Фактура бэкор килинди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(Exception)
            {
                MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private async void iconButton3_Click_1(object sender, EventArgs e)
        {
            if (dv == false)
            {
                try
                {
                    string url = "http://santexnika.backoffice.uz/api/faktura/otkaz/?fak=" + tbFakturaSave.Rows[managerFakturaSave.Position]["Фактура_ид"].ToString();
                    string response = await GetObject(url);
                    Form1.faktura = false;
                    tabControl1_Click(sender, e);
                    Form1.fakturaSend = false;
                    MessageBox.Show("Фактура бэкор килинди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception)
                {
                    MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
               
                try
                {
                    string url = "http://santexnika.backoffice.uz/api/faktura/otkaz/?fak=" + tbFkSave.Rows[managerFkSave.Position]["Фактура_ид"].ToString();
                    string response = await GetObject(url);
                    Form1.faktura = false;
                    tabControl1_Click(sender, e);
                    Form1.fakturaSend = false;
                    MessageBox.Show("Фактура бэкор килинди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception)
                {
                    MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               
            }
        }

        private void tabControl1_SizeChanged(object sender, EventArgs e)
        {
            if (Width > 1378 && Height >= 780)
            {
                dbgridProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                dbgridProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            } 
        }

        public static bool fakturaItem = false;
        public static bool faktura_cancel = false;
        public static bool tabControl = false;
        public static bool dv1 = false;
        public class Product
        {
            public int id { get; set; }
            public string name { get; set; }
            public string measurement { get; set; }
            public string preparer { get; set; }
            public double min_count { get; set; }
        }

        public class FakturaItemAdd
        {
            public int id { get; set; }
            public Product product { get; set; }
            public string name { get; set; }
            public double som { get; set; }
            public double dollar { get; set; }
            public double quantity { get; set; }
            public string barcode { get; set; }
            public int faktura { get; set; }
            public int group { get; set; }
        }

        private async void metroSetTextBox2_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                if (tbFakturaSave.Rows.Count > 0 && txtSearchFil.Text != "")
                {
                    DataRow[] rows = tbFakturaSave.Select("Филиал like '%" + txtSearchFil.Text + "%'");
                    tbFkSave = new DataTable();
                    tbFkSave.Columns.Add("Фактура_ид");
                    tbFkSave.Columns.Add("Сум");
                    tbFkSave.Columns.Add("Доллар");
                    tbFkSave.Columns.Add("Филиал");
                    tbFkSave.Columns.Add("Сана");
                    tbFkSave.Columns.Add("Статус");

                    foreach (var item in rows)
                    {
                        DataRow row = tbFkSave.NewRow();
                        row["Фактура_ид"] = item["Фактура_ид"];
                        row["Сум"] = item["Сумма"];
                        row["Доллар"] = item["Сумма"];
                        row["Филиал"] = item["Филиал"];
                        row["Сана"] = item["Сана"];
                        row["Статус"] = item["Статус"];
                        tbFkSave.Rows.Add(row);
                    }
                    managerFkSave = (CurrencyManager)BindingContext[tbFkSave];
                    dbgridFakturaSave.DataSource = tbFkSave;
                    dbgridFakturaSave.Columns[0].Visible = false;
                    dbgridFakturaItemSave.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                    tbFkSave.Dispose();
                    tbFakturaItem.Clear();
                    if (tbFkSave.Rows.Count > 0)
                    {
                        if (tbFkSave.Rows.Count > 0) { tbFakturaItem.Clear(); }
                        else
                        {
                            tbFakturaItem = new DataTable();
                            tbFakturaItem.Columns.Add("Фактура");
                            tbFakturaItem.Columns.Add("Махсулот");
                            tbFakturaItem.Columns.Add("Сум");
                            tbFakturaItem.Columns.Add("Доллар");
                            tbFakturaItem.Columns.Add("Микдори");
                        }
                        string url = "http://santexnika.backoffice.uz/api/fakturaitem/st1/?fak=" + tbFkSave.Rows[0]["Фактура_ид"].ToString();
                        string fakturaItemContent = await GetObject(url);
                        List<FakturaItemAdd> fakturaItemArray = JsonConvert.DeserializeObject<List<FakturaItemAdd>>(fakturaItemContent);
                        if (fakturaItemArray != null)
                        {
                            foreach (var fakturaItem in fakturaItemArray)
                            {
                                DataRow rowFakturaItem = tbFakturaItem.NewRow();
                                rowFakturaItem["Фактура"] = fakturaItem.faktura;
                                rowFakturaItem["Махсулот"] = fakturaItem.name;
                                rowFakturaItem["Сум"] = fakturaItem.som;
                                rowFakturaItem["Доллар"] = fakturaItem.dollar;
                                rowFakturaItem["Микдори"] = fakturaItem.quantity;
                                tbFakturaItem.Rows.Add(rowFakturaItem);
                            }
                        }
                        dbgridFakturaItemSave.DataSource = tbFakturaItem;
                        dbgridFakturaItemSave.Columns[0].Visible = false;
                        dbgridFakturaItemSave.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                    }
                    dv1 = true;

                }
                else if (txtSearchFil.Text == "")
                {
                    dbgridFakturaSave.DataSource = tbFakturaSave;
                    dbgridFakturaSave.Columns[0].Visible = false;
                    dbgridFakturaSave.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                    if (tbFakturaSave.Rows.Count > 0)
                    {
                        tbFakturaItem.Clear();
                        string url = "http://santexnika.backoffice.uz/api/fakturaitem/st1/?fak=" + tbFakturaSave.Rows[0]["Фактура_ид"].ToString();
                        string fakturaItemContent = await GetObject(url);
                        List<FakturaItemAdd> fakturaItemArray = JsonConvert.DeserializeObject<List<FakturaItemAdd>>(fakturaItemContent);
                        if (fakturaItemArray != null)
                        {
                            foreach (var fakturaItem in fakturaItemArray)
                            {
                                DataRow rowFakturaItem = tbFakturaItem.NewRow();
                                rowFakturaItem["Фактура"] = fakturaItem.faktura;
                                rowFakturaItem["Махсулот"] = fakturaItem.name;
                                rowFakturaItem["Сум"] = fakturaItem.som;
                                rowFakturaItem["Доллар"] = fakturaItem.dollar;
                                rowFakturaItem["Микдори"] = fakturaItem.quantity;
                                tbFakturaItem.Rows.Add(rowFakturaItem);
                            }
                        }
                        dbgridFakturaItemSave.DataSource = tbFakturaItem;
                        dbgridFakturaItemSave.Columns[0].Visible = false;
                        dbgridFakturaItemSave.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                    }
                    dv1 = false;
                }
            }
        }

        private void dbgridProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void iconPictureBox2_Click(object sender, EventArgs e)
        {
            if (tbFakturaSave.Rows.Count > 0 && txtSearchFil.Text != "")
            {
                DataRow[] rows = tbFakturaSave.Select("Филиал like '%" + txtSearchFil.Text + "%'");
                tbFkSave = new DataTable();
                tbFkSave.Columns.Add("Фактура_ид");
                tbFkSave.Columns.Add("Сум");
                tbFkSave.Columns.Add("Доллар");
                tbFkSave.Columns.Add("Филиал");
                tbFkSave.Columns.Add("Сана");
                tbFkSave.Columns.Add("Статус");

                foreach (var item in rows)
                {
                    DataRow row = tbFkSave.NewRow();
                    row["Фактура_ид"] = item["Фактура_ид"];
                    row["Сум"] = item["Сум"];
                    row["Доллар"] = item["Доллар"];
                    row["Филиал"] = item["Филиал"];
                    row["Сана"] = item["Сана"];
                    row["Статус"] = item["Статус"];
                    tbFkSave.Rows.Add(row);
                }
                managerFkSave = (CurrencyManager)BindingContext[tbFkSave];
                dbgridFakturaSave.DataSource = tbFkSave;
                dbgridFakturaSave.Columns[0].Visible = false;
                dbgridFakturaItemSave.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                tbFkSave.Dispose();
                tbFakturaItem.Clear();
                if (tbFkSave.Rows.Count > 0)
                {
                    if (tbFkSave.Rows.Count > 0) { tbFakturaItem.Clear(); }
                    else
                    {
                        tbFakturaItem = new DataTable();
                        tbFakturaItem.Columns.Add("Фактура");
                        tbFakturaItem.Columns.Add("Махсулот");
                        tbFakturaItem.Columns.Add("Сум");
                        tbFakturaItem.Columns.Add("Доллар");
                        tbFakturaItem.Columns.Add("Микдори");
                    }
                    string url = "http://santexnika.backoffice.uz/api/fakturaitem/st1/?fak=" + tbFkSave.Rows[0]["Фактура_ид"].ToString();
                    string fakturaItemContent = await GetObject(url);
                    List<FakturaItemAdd> fakturaItemArray = JsonConvert.DeserializeObject<List<FakturaItemAdd>>(fakturaItemContent);
                    if (fakturaItemArray != null)
                    {
                        foreach (var fakturaItem in fakturaItemArray)
                        {
                            DataRow rowFakturaItem = tbFakturaItem.NewRow();
                            rowFakturaItem["Фактура"] = fakturaItem.faktura;
                            rowFakturaItem["Махсулот"] = fakturaItem.name;
                            rowFakturaItem["Сум"] = fakturaItem.som;
                            rowFakturaItem["Доллар"] = fakturaItem.dollar;
                            rowFakturaItem["Микдори"] = fakturaItem.quantity;
                            tbFakturaItem.Rows.Add(rowFakturaItem);
                        }
                    }
                    dbgridFakturaItemSave.DataSource = tbFakturaItem;
                    dbgridFakturaItemSave.Columns[0].Visible = false;
                    dbgridFakturaItemSave.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                }
                dv1 = true;

            }
            else if (txtSearchFil.Text == "")
            {
                dbgridFakturaSave.DataSource = tbFakturaSave;
                dbgridFakturaSave.Columns[0].Visible = false;
                dbgridFakturaSave.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                if (tbFakturaSave.Rows.Count > 0)
                {
                    tbFakturaItem.Clear();
                    string url = "http://santexnika.backoffice.uz/api/fakturaitem/st1/?fak=" + tbFakturaSave.Rows[0]["Фактура_ид"].ToString();
                    string fakturaItemContent = await GetObject(url);
                    List<FakturaItemAdd> fakturaItemArray = JsonConvert.DeserializeObject<List<FakturaItemAdd>>(fakturaItemContent);
                    if (fakturaItemArray != null)
                    {
                        foreach (var fakturaItem in fakturaItemArray)
                        {
                            DataRow rowFakturaItem = tbFakturaItem.NewRow();
                            rowFakturaItem["Фактура"] = fakturaItem.faktura;
                            rowFakturaItem["Махсулот"] = fakturaItem.name;
                            rowFakturaItem["Сум"] = fakturaItem.som;
                            rowFakturaItem["Доллар"] = fakturaItem.dollar;
                            rowFakturaItem["Микдори"] = fakturaItem.quantity;
                            tbFakturaItem.Rows.Add(rowFakturaItem);
                        }
                    }
                    dbgridFakturaItemSave.DataSource = tbFakturaItem;
                    dbgridFakturaItemSave.Columns[0].Visible = false;
                    dbgridFakturaItemSave.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                }
                dv1 = false;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dbgridProduct.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (f5)
                {
                    MessageBox.Show("Фактура яратилмаган!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dbgridProduct.Rows.Count == 0) return;
                bool isopen = false;
                foreach (Form f1 in Application.OpenForms)
                {
                    if (f1.Text == "Корзинка")
                    {
                        isopen = true;
                        f1.BringToFront();
                        break;
                    }
                }
                if (isopen == false)
                {
                    faktura_cancel = false;
                    faktura_edit = false;
                    frmFakturaAddProduct fakturaAddProduct = new frmFakturaAddProduct();

                    fakturaAddProduct.name = tbPr.Rows[managerPr.Position]["Махсулот_Номи"].ToString();
                    fakturaAddProduct.som = tbPr.Rows[managerPr.Position]["Сўм"].ToString();
                    fakturaAddProduct.dollar = tbPr.Rows[managerPr.Position]["Доллар"].ToString();
                    fakturaAddProduct.kurs = tbPr.Rows[managerPr.Position]["Курс"].ToString();
                    fakturaAddProduct.quanOmbor = tbPr.Rows[managerPr.Position]["Микдори"].ToString();
                    txtSearch.Clear();
                    fakturaAddProduct.ShowDialog();
                    FakturaShow(faktura_id);
                }
            }
        }

        private void dbgridProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dbgridProduct.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (f5)
                {
                    MessageBox.Show("Фактура яратилмаган!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dbgridProduct.Rows.Count == 0) return;
                bool isopen = false;
                foreach (Form f1 in Application.OpenForms)
                {
                    if (f1.Text == "Корзинка")
                    {
                        isopen = true;
                        f1.BringToFront();
                        break;
                    }
                }
                if (isopen == false)
                {
                    faktura_cancel = false;
                    faktura_edit = false;
                    frmFakturaAddProduct fakturaAddProduct = new frmFakturaAddProduct();

                    fakturaAddProduct.name = tbPr.Rows[managerPr.Position]["Махсулот_Номи"].ToString();
                    fakturaAddProduct.som = tbPr.Rows[managerPr.Position]["Сўм"].ToString();
                    fakturaAddProduct.dollar = tbPr.Rows[managerPr.Position]["Доллар"].ToString();
                    fakturaAddProduct.kurs = tbPr.Rows[managerPr.Position]["Курс"].ToString();
                    fakturaAddProduct.quanOmbor = tbPr.Rows[managerPr.Position]["Микдори"].ToString();
                    txtSearch.Clear();
                    fakturaAddProduct.ShowDialog();
                    FakturaShow(faktura_id);
                }
            }
        }

        public async void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl == false)
            {
                tabControl = true;
                if (tabControl1.SelectedIndex == 1)
                {
                    
                    if (Form1.filial == false)
                    {
                        try
                        {
                            tbFilial = new DataTable();
                            tbFilial.Columns.Add("id", typeof(int));
                            tbFilial.Columns.Add("name");
                            tbFilial.Columns.Add("address");
                            string FilialContent = await GetObject("http://santexnika.backoffice.uz/api/filial/");
                            JArray filialArray = JArray.Parse(FilialContent);
                            if (filialArray != null)
                            {
                                foreach (var filialItem in filialArray)
                                {
                                    DataRow rowFilial = tbFilial.NewRow();
                                    rowFilial["id"] = filialItem["id"];
                                    rowFilial["name"] = filialItem["name"];
                                    rowFilial["address"] = filialItem["address"];
                                    tbFilial.Rows.Add(rowFilial);
                                }
                            }
                            managerFilial = (CurrencyManager)BindingContext[tbFilial];
                            tbFilial.Dispose();
                            form1 = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        form1 = false;
                    }
                    if (Form1.faktura == false)
                    {
                        try
                        {
                            tbFakturaSave = new DataTable();
                            tbFakturaSave.Columns.Add("Фактура_ид");
                            tbFakturaSave.Columns.Add("Сум");
                            tbFakturaSave.Columns.Add("Доллар");
                            tbFakturaSave.Columns.Add("Филиал");
                            tbFakturaSave.Columns.Add("Сана");
                            tbFakturaSave.Columns.Add("Статус");
                            string FakturaContent = await GetObject("http://santexnika.backoffice.uz/api/faktura/ombor0/");
                            JArray fakturaArray = JArray.Parse(FakturaContent);
                            if (fakturaArray != null)
                            {
                                foreach (var fakturaItem in fakturaArray)
                                {
                                    DataRow rowFaktura = tbFakturaSave.NewRow();
                                    rowFaktura["Фактура_ид"] = fakturaItem["id"];
                                    rowFaktura["Сум"] = fakturaItem["som"];
                                    rowFaktura["Доллар"] = fakturaItem["dollar"];
                                    if (form1)
                                    {
                                        DataRow[] rowFilial = tbFilial.Select("id='" + fakturaItem["filial"] + "'");
                                        rowFaktura["Филиал"] = rowFilial[0]["name"];
                                    }
                                    else
                                    {

                                        DataRow[] rowFilial = frmFakturaTayyorlash.tbFilial.Select("id='" + fakturaItem["filial"] + "'");
                                        rowFaktura["Филиал"] = rowFilial[0]["name"];
                                    }
                                    rowFaktura["Сана"] = fakturaItem["date"];
                                    rowFaktura["Статус"] = "Жўнатилмаган";
                                    tbFakturaSave.Rows.Add(rowFaktura);
                                }
                            }
                            managerFakturaSave = (CurrencyManager)BindingContext[tbFakturaSave];
                            dbgridFakturaSave.DataSource = tbFakturaSave;
                            dbgridFakturaSave.Columns[0].Visible = false;
                            dbgridFakturaSave.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                            tbFakturaSave.Dispose();

                            if (tbFakturaSave.Rows.Count > 0)
                            {
                                tbFakturaItem = new DataTable();
                                tbFakturaItem.Columns.Add("Фактура");
                                tbFakturaItem.Columns.Add("Махсулот");
                                tbFakturaItem.Columns.Add("Сум");
                                tbFakturaItem.Columns.Add("Доллар");
                                tbFakturaItem.Columns.Add("Микдори");
                                string url = "http://santexnika.backoffice.uz/api/fakturaitem/st1/?fak=" + tbFakturaSave.Rows[0]["Фактура_ид"].ToString();
                                string fakturaItemContent = await GetObject(url);
                                List<FakturaItemAdd> fakturaItemArray = JsonConvert.DeserializeObject<List<FakturaItemAdd>>(fakturaItemContent);
                                if (fakturaItemArray != null)
                                {
                                    foreach (var fakturaItem in fakturaItemArray)
                                    {
                                        DataRow rowFakturaItem = tbFakturaItem.NewRow();
                                        rowFakturaItem["Фактура"] = fakturaItem.faktura;
                                        rowFakturaItem["Махсулот"] = fakturaItem.name;
                                        rowFakturaItem["Сум"] = fakturaItem.som;
                                        rowFakturaItem["Доллар"] = fakturaItem.dollar;
                                        rowFakturaItem["Микдори"] = fakturaItem.quantity;
                                        tbFakturaItem.Rows.Add(rowFakturaItem);
                                    }
                                }
                                dbgridFakturaItemSave.DataSource = tbFakturaItem;
                                dbgridFakturaItemSave.Columns[0].Visible = false;
                                dbgridFakturaItemSave.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                            }
                            else
                            {
                                try
                                {
                                    tbFakturaItem.Clear();
                                }
                                catch (Exception) { }
                            }
                            Form1.faktura = true;
                            fakturaItem = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        dbgridFakturaSave.DataSource = tbFakturaSave;
                        dbgridFakturaSave.Columns[0].Visible = false;
                        dbgridFakturaSave.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                        if (fakturaItem)
                        {
                            dbgridFakturaItemSave.DataSource = tbFakturaItem;
                            dbgridFakturaItemSave.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                        }
                    }
                    
                }
                tabControl = false;
                
            }
        }

        private void txtSearchFil_Validated(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        public static string edit_price = "", edit_quantity = "";
        public static bool edit = false;

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEditFaktura editFaktura = new frmEditFaktura();
            editFaktura.fakturaItem_id = tbFaktura.Rows[managerFaktura.Position]["id"].ToString();
            editFaktura.faktura_id = faktura_id;
            editFaktura.name = tbFaktura.Rows[managerFaktura.Position]["Махсулот"].ToString();
            editFaktura.price = tbFaktura.Rows[managerFaktura.Position]["Нархи"].ToString();
            editFaktura.quantity = tbFaktura.Rows[managerFaktura.Position]["Микдори"].ToString();

        }

        private void frmFakturaTayyorlash_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Tab)
            {
                txtSearch.Focus();
            }
        }

        private void btnQabulUlash_Click(object sender, EventArgs e)
        {
            if (tbFakturaSave.Rows.Count == 0)
            {
                MessageBox.Show("Fakturani tanlang!","Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(frmRecieveProduct.faktura_id!="0")
            {
                MessageBox.Show("Qabulga ulanish mumkin emas\nQabulga ulangan faktura mavjud!", "Ogohlantirish", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (frmRecieveProduct.faktura_id == "0")
            {
                frmRecieveProduct.faktura_id = tbFakturaSave.Rows[managerFakturaSave.Position]["Фактура_ид"].ToString();
                MessageBox.Show("Faktura qabulga muvaffaqiyatli ulandi!\nMaxsulot qabuli bo'limiga o'tish qabulni davom ettirishingiz mumkin!","Xabar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        public void EditFaktura(string fakturaItem_id, string product_id)
        {
            try
            {

            }
            catch(Exception)
            {

            }
        }

        public static bool f5 = true;
        public static bool create = false;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (create == false)
            {
                create = true;
                filial_id = tbFilial.Rows[managerFilial.Position]["id"].ToString();
                try
                {
                    Uri u = new Uri("http://santexnika.backoffice.uz/api/faktura/");
                    var payload = "{\"filial\": \"" + filial_id + "\"}";
                    HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                    var t = Task.Run(() => PostURI(u, content));
                    t.Wait();
                    if (t.Result != "Error!" && t.Result.Length != 0)
                    {
                        string FakturaContent = t.Result;
                        Fakturaobject faktura = JsonConvert.DeserializeObject<Fakturaobject>(FakturaContent);
                        faktura_id = faktura.id.ToString();
                        Form1.faktura_id = faktura_id;
                        txtSom.Text = "0";
                        tbFaktura = new DataTable();
                        tbFaktura.Columns.Add("Фактура_ид");
                        tbFaktura.Columns.Add("Махсулот");
                        tbFaktura.Columns.Add("Сум");
                        tbFaktura.Columns.Add("Доллар");
                        tbFaktura.Columns.Add("Микдори");
                        tbFaktura.Columns.Add("Улчов");
                        tbFaktura.Columns.Add("Ишлаб_чикарувчи");
                        tbFaktura.Columns.Add("product");
                        tbFaktura.Columns.Add("id");
                        managerFaktura = (CurrencyManager)BindingContext[tbFaktura];
                        dbgridFaktura.DataSource = tbFaktura;
                        dbgridFaktura.Columns[0].Visible = false;
                        dbgridFaktura.Columns[7].Visible = false;
                        dbgridFaktura.Columns[8].Visible = false;
                        dbgridFaktura.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                        tbFaktura.Dispose();
                        MessageBox.Show("Янги фактура муваффакиятли яратилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnCreate.Enabled = false;
                        f5 = false;
                        comboFilial.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Сэрвэр билан богланишда хатолик, илтимос интэрнэтни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                create = false;
            }
        }
        public static bool fakturaShow = false;
        public static string faktura = "", product_name = "", som = "", dollar="", quantity = "", product_id = "", id="", preparer="",measurement="";
        public async void FakturaShow(string faktura)
        {
            try
            {
                if (faktura_edit == false && faktura_cancel == false)
                {
                    try
                    {
                        DataTable tb = new DataTable();
                        dbgridFaktura.DataSource = tb;
                        DataRow row = tbFaktura.NewRow();
                        row["Фактура_ид"] = faktura;
                        row["Махсулот"] = product_name;
                        row["Сум"] = som;
                        row["Доллар"] = dollar;
                        row["Микдори"] = quantity;
                        row["Улчов"] = measurement;
                        row["Ишлаб_чикарувчи"] = preparer;
                        row["product"] = product_id;
                        row["id"] = id;
                        tbFaktura.Rows.Add(row);
                        dbgridFaktura.DataSource = tbFaktura;
                        dbgridFaktura.Columns[0].Visible = false;
                        dbgridFaktura.Columns[7].Visible = false;
                        dbgridFaktura.Columns[8].Visible = false;
                        dbgridFaktura.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                    }
                    catch (Exception)
                    {
                        DataTable tb = new DataTable();
                        dbgridFaktura.DataSource = tb;
                        tbFaktura = new DataTable();
                        tbFaktura.Columns.Add("Фактура_ид");
                        tbFaktura.Columns.Add("Махсулот");
                        tbFaktura.Columns.Add("Сум");
                        tbFaktura.Columns.Add("Доллар");
                        tbFaktura.Columns.Add("Улчов");
                        tbFaktura.Columns.Add("Ишлаб_чикарувчи");
                        tbFaktura.Columns.Add("product");
                        tbFaktura.Columns.Add("id");

                        DataRow row = tbFaktura.NewRow();
                        row["Фактура_ид"] = faktura;
                        row["Махсулот"] = product_name;
                        row["Сум"] = som;
                        row["Доллар"] = dollar;
                        row["Микдори"] = quantity;
                        row["Улчов"] = measurement;
                        row["Ишлаб_чикарувчи"] = preparer;
                        row["product"] = product_id;
                        row["id"] = id;
                        tbFaktura.Rows.Add(row);
                        dbgridFaktura.DataSource = tbFaktura;
                        dbgridFaktura.Columns[0].Visible = false;
                        dbgridFaktura.Columns[7].Visible = false;
                        dbgridFaktura.Columns[8].Visible = false;
                        dbgridFaktura.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                        tbFaktura.Dispose();
                    }
                    faktura_cancel = false;
                }

                if (faktura_edit && faktura_cancel == false)
                {
                    try
                    {
                        lblStatus.Visible = true;
                        tbFaktura = new DataTable();
                        tbFaktura.Columns.Add("Фактура_ид");
                        tbFaktura.Columns.Add("Махсулот");
                        tbFaktura.Columns.Add("Сум");
                        tbFaktura.Columns.Add("Доллар");
                        tbFaktura.Columns.Add("Микдори");
                        tbFaktura.Columns.Add("Улчов");
                        tbFaktura.Columns.Add("Ишлаб_чикарувчи");
                        tbFaktura.Columns.Add("product");
                        tbFaktura.Columns.Add("id");

                        string url = "http://santexnika.backoffice.uz/api/fakturaitem/st1/?fak=" + faktura;
                        string FakturaContent = await GetObject(url);
                        lblStatus.Visible = false;
                        List<FakturaItemAdd> fakturaItemAdd = new List<FakturaItemAdd>();
                        fakturaItemAdd = JsonConvert.DeserializeObject<List<FakturaItemAdd>>(FakturaContent);
                        if (fakturaItemAdd != null)
                        {
                            foreach (var fakturaItem in fakturaItemAdd)
                            {
                                DataRow rowProduct = tbFaktura.NewRow();
                                rowProduct["Фактура_ид"] = fakturaItem.faktura;
                                rowProduct["Махсулот"] = fakturaItem.name;
                                rowProduct["Сум"] = fakturaItem.som;
                                rowProduct["Доллар"] = fakturaItem.dollar;
                                rowProduct["Микдори"] = fakturaItem.quantity;
                                rowProduct["Улчов"] = fakturaItem.product.measurement;
                                rowProduct["Ишлаб_чикарувчи"] = fakturaItem.product.preparer;
                                rowProduct["product"] = fakturaItem.product.id;
                                rowProduct["id"] = fakturaItem.id;
                                tbFaktura.Rows.Add(rowProduct);
                            }
                        }
                        managerFaktura = (CurrencyManager)BindingContext[tbFaktura];
                        dbgridFaktura.DataSource = tbFaktura;
                        dbgridFaktura.Columns[0].Visible = false;
                        dbgridFaktura.Columns[7].Visible = false;
                        dbgridFaktura.Columns[8].Visible = false;
                        dbgridFaktura.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                        tbFaktura.Dispose();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        fakturaShow = true;
                        lblQayta.Visible = true;
                        lblStatus.Visible = false;
                    }
                    faktura_edit = false;
                    faktura_cancel = false;
                }

                try
                {
                    lblStatus.Visible = true;
                    tbFakturaSumma = new DataTable();
                    tbFakturaSumma.Columns.Add("id");
                    tbFakturaSumma.Columns.Add("date");
                    tbFakturaSumma.Columns.Add("som");
                    tbFakturaSumma.Columns.Add("dollar");
                    tbFakturaSumma.Columns.Add("status");
                    tbFakturaSumma.Columns.Add("difference");
                    tbFakturaSumma.Columns.Add("filial");
                    string url1 = "http://santexnika.backoffice.uz/api/faktura/" + faktura_id + "/";
                    string SummaContent = await GetObject(url1);
                    lblStatus.Visible = false;
                    JObject arrayfakturaSumma = JObject.Parse(SummaContent);
                    if (arrayfakturaSumma != null)
                    {
                        DataRow rowFakturaSumma = tbFakturaSumma.NewRow();
                        rowFakturaSumma["id"] = arrayfakturaSumma["id"];
                        rowFakturaSumma["date"] = arrayfakturaSumma["date"];
                        rowFakturaSumma["som"] = arrayfakturaSumma["som"];
                        rowFakturaSumma["dollar"] = arrayfakturaSumma["dollar"];
                        rowFakturaSumma["status"] = arrayfakturaSumma["status"];
                        rowFakturaSumma["difference"] = arrayfakturaSumma["difference"];
                        rowFakturaSumma["filial"] = arrayfakturaSumma["filial"];
                        tbFakturaSumma.Rows.Add(rowFakturaSumma);
                    }
                    txtSom.DataSource = tbFakturaSumma;
                    txtSom.DisplayMember = "som";

                    txtDollar.DataSource = tbFakturaSumma;
                    txtDollar.DisplayMember = "dollar";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fakturaShow = true;
                    lblQayta.Visible = true;
                    lblStatus.Visible = false;

                }
                btnCreate.Enabled = false;
                comboFilial.Enabled = false;
            }
            catch(Exception)
            {
                MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fakturaShow = true;
                lblQayta.Visible = true;
                lblStatus.Visible = false;
            }
        }
    }
}