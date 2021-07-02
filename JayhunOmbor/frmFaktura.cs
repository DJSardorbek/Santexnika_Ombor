using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JayhunOmbor
{
    public partial class frmFaktura : Form
    {
        public frmFaktura()
        {
            InitializeComponent();
        }
        public static DataTable tbFakturaSend,tbFaktura, tbFilial, tbFakturaItemSend, tbFakturaItem;
        public static CurrencyManager managerFakturaSend,managerFaktura, managerFilial;
        public static bool form1 = false;

        private void dbgridFaktura_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridFakturaSend.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Y + 4);
            }
        }

        private void dbgridFakturaItem_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridFakturaItemSend.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Y + 4);
            }
        }
        public static bool dv = false;
        public static DataTable tbFkSend;
        public static CurrencyManager managertbFkSend;
        private async void metroSetTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void lblQayta_Click(object sender, EventArgs e)
        {
            frmFaktura_Load(sender, e);
            lblQayta.Visible = false;
        }

        private async void iconButton3_Click(object sender, EventArgs e)
        {
            if (dv == false)
            {
                try
                {
                    string url = "http://santexnika.backoffice.uz/api/faktura/otkaz/?fak=" + tbFakturaItemSend.Rows[managerFakturaSend.Position]["Фактура"].ToString();
                    string response = await GetObject(url);
                    Form1.fakturaSend = false;
                    try { tbFakturaItemSend.Clear();} catch (Exception) { }
                    frmFaktura_Load(sender, e);
                    MessageBox.Show("Фактура бэкор килинди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                
                try
                {
                    string url = "http://santexnika.backoffice.uz/api/faktura/otkaz/?fak=" + tbFkSend.Rows[managertbFkSend.Position]["Фактура"].ToString();
                    string response = await GetObject(url);
                    Form1.fakturaSend = false;
                    try { tbFakturaItemSend.Clear(); } catch (Exception) { }
                    frmFaktura_Load(sender, e);
                    MessageBox.Show("Фактура бэкор килинди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception)
                {
                    MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
        }

        private void frmFaktura_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private async void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private async void txtSearch_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                    if (tbFakturaSend.Rows.Count > 0 && txtSearch.Text != "")
                    {
                        DataRow[] rows = tbFakturaSend.Select("Филиал like '%" + txtSearch.Text + "%'");
                        tbFkSend = new DataTable();
                        tbFkSend.Columns.Add("Фактура_ид");
                        tbFkSend.Columns.Add("Сум");
                        tbFkSend.Columns.Add("Доллар");
                        tbFkSend.Columns.Add("Филиал");
                        tbFkSend.Columns.Add("Сана");
                        tbFkSend.Columns.Add("Статус");

                        foreach (var item in rows)
                        {
                            DataRow row = tbFkSend.NewRow();
                            row["Фактура_ид"] = item["Фактура_ид"];
                            row["Сум"] = item["Сум"];
                            row["Доллар"] = item["Доллар"];
                            row["Филиал"] = item["Филиал"];
                            row["Сана"] = item["Сана"];
                            row["Статус"] = item["Статус"];
                            tbFkSend.Rows.Add(row);
                        }
                        dbgridFakturaSend.DataSource = tbFkSend;
                        dbgridFakturaSend.Columns[0].Visible = false;
                        dbgridFakturaSend.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                        managertbFkSend = (CurrencyManager)BindingContext[tbFkSend];
                        tbFkSend.Dispose();
                        tbFakturaItemSend.Clear();
                        if (tbFkSend.Rows.Count > 0)
                        {
                            tbFakturaItemSend.Clear();
                            lblStatus.Visible = true;
                            if (tbFkSend.Rows.Count > 0) { tbFakturaItemSend.Clear(); }
                            else
                            {
                                tbFakturaItemSend = new DataTable();
                                tbFakturaItemSend.Columns.Add("Фактура");
                                tbFakturaItemSend.Columns.Add("Махсулот");
                                tbFakturaItemSend.Columns.Add("Сум");
                                tbFakturaItemSend.Columns.Add("Доллар");
                                tbFakturaItemSend.Columns.Add("Микдори");
                            }
                            string url = "http://santexnika.backoffice.uz/api/fakturaitem/st1/?fak=" + tbFkSend.Rows[0]["Фактура_ид"].ToString();
                            string fakturaItemContent = await GetObject(url);
                            lblStatus.Visible = false;
                            if (fakturaItemContent != "[]")
                            {
                                JArray fakturaItemArray = JArray.Parse(fakturaItemContent);
                                if (fakturaItemArray != null)
                                {
                                    foreach (var fakturaItem in fakturaItemArray)
                                    {
                                    DataRow rowFakturaItem = tbFakturaItemSend.NewRow();
                                    rowFakturaItem["Фактура"] = fakturaItem["faktura"];
                                    //DataRow[] rowProduct = Form1.tbProduct.Select("Махсулот_ид='" + fakturaItem["product"] + "'");
                                    rowFakturaItem["Махсулот"] = fakturaItem["name"];
                                    rowFakturaItem["Сум"] = fakturaItem["som"];
                                    rowFakturaItem["Доллар"] = fakturaItem["dollar"];
                                    rowFakturaItem["Микдори"] = fakturaItem["quantity"];
                                    tbFakturaItemSend.Rows.Add(rowFakturaItem);
                                }
                                }
                            }
                            dbgridFakturaItemSend.DataSource = tbFakturaItemSend;
                            dbgridFakturaItemSend.Columns[0].Visible = false;
                            dbgridFakturaItemSend.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                        }
                        dv = true;
                    }
                    else if (txtSearch.Text == "")
                    {
                        dbgridFakturaSend.DataSource = tbFakturaSend;
                        dbgridFakturaSend.Columns[0].Visible = false;
                        dbgridFakturaSend.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                        if (tbFakturaSend.Rows.Count > 0)
                        {
                            lblStatus.Visible = true;
                            tbFakturaItemSend.Clear();
                            string url = "http://santexnika.backoffice.uz/api/fakturaitem/st1/?fak=" + tbFakturaSend.Rows[0]["Фактура_ид"].ToString();
                            string fakturaItemContent = await GetObject(url);
                            lblStatus.Visible = false;
                            if (fakturaItemContent != "[]")
                            {
                                JArray fakturaItemArray = JArray.Parse(fakturaItemContent);
                                if (fakturaItemArray != null)
                                {
                                    foreach (var fakturaItem in fakturaItemArray)
                                    {
                                        DataRow rowFakturaItem = tbFakturaItemSend.NewRow();
                                        rowFakturaItem["Фактура"] = fakturaItem["faktura"];
                                        //DataRow[] rowProduct = Form1.tbProduct.Select("Махсулот_ид='" + fakturaItem["product"] + "'");
                                        rowFakturaItem["Махсулот"] = fakturaItem["name"];
                                        rowFakturaItem["Сум"] = fakturaItem["som"];
                                        rowFakturaItem["Доллар"] = fakturaItem["dollar"];
                                        rowFakturaItem["Микдори"] = fakturaItem["quantity"];
                                        tbFakturaItemSend.Rows.Add(rowFakturaItem);
                                    }
                                }
                            }
                            dbgridFakturaItemSend.DataSource = tbFakturaItemSend;
                            dbgridFakturaItemSend.Columns[0].Visible = false;
                            dbgridFakturaItemSend.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                        }
                        dv = false;
                    }
                
            }
        }

        private async void iconPictureBox1_Click(object sender, EventArgs e)
        {
            if (tbFakturaSend.Rows.Count > 0 && txtSearch.Text != "")
            {
                DataRow[] rows = tbFakturaSend.Select("Филиал like '%" + txtSearch.Text + "%'");
                tbFkSend = new DataTable();
                tbFkSend.Columns.Add("Фактура_ид");
                tbFkSend.Columns.Add("Сум");
                tbFkSend.Columns.Add("Доллар");
                tbFkSend.Columns.Add("Филиал");
                tbFkSend.Columns.Add("Сана");
                tbFkSend.Columns.Add("Статус");

                foreach (var item in rows)
                {
                    DataRow row = tbFkSend.NewRow();
                    row["Фактура_ид"] = item["Фактура_ид"];
                    row["Сум"] = item["Сум"];
                    row["Доллар"] = item["Доллар"];
                    row["Филиал"] = item["Филиал"];
                    row["Сана"] = item["Сана"];
                    row["Статус"] = item["Статус"];
                    tbFkSend.Rows.Add(row);
                }
                dbgridFakturaSend.DataSource = tbFkSend;
                dbgridFakturaSend.Columns[0].Visible = false;
                dbgridFakturaSend.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                managertbFkSend = (CurrencyManager)BindingContext[tbFkSend];
                tbFkSend.Dispose();
                tbFakturaItemSend.Clear();
                if (tbFkSend.Rows.Count > 0)
                {
                    tbFakturaItemSend.Clear();
                    lblStatus.Visible = true;
                    if (tbFkSend.Rows.Count > 0) { tbFakturaItemSend.Clear(); }
                    else
                    {
                        tbFakturaItemSend = new DataTable();
                        tbFakturaItemSend.Columns.Add("Фактура");
                        tbFakturaItemSend.Columns.Add("Махсулот");
                        tbFakturaItemSend.Columns.Add("Сум");
                        tbFakturaItemSend.Columns.Add("Доллар");
                        tbFakturaItemSend.Columns.Add("Микдори");
                    }
                    string url = "http://santexnika.backoffice.uz/api/fakturaitem/st1/?fak=" + tbFkSend.Rows[0]["Фактура_ид"].ToString();
                    string fakturaItemContent = await GetObject(url);
                    lblStatus.Visible = false;
                    if (fakturaItemContent != "[]")
                    {
                        JArray fakturaItemArray = JArray.Parse(fakturaItemContent);
                        if (fakturaItemArray != null)
                        {
                            foreach (var fakturaItem in fakturaItemArray)
                            {
                                DataRow rowFakturaItem = tbFakturaItemSend.NewRow();
                                rowFakturaItem["Фактура"] = fakturaItem["faktura"];
                                //DataRow[] rowProduct = Form1.tbProduct.Select("Махсулот_ид='" + fakturaItem["product"] + "'");
                                rowFakturaItem["Махсулот"] = fakturaItem["product"];
                                rowFakturaItem["Сум"] = fakturaItem["som"];
                                rowFakturaItem["Доллар"] = fakturaItem["dollar"];
                                rowFakturaItem["Микдори"] = fakturaItem["quantity"];
                                tbFakturaItemSend.Rows.Add(rowFakturaItem);
                            }
                        }
                    }
                    dbgridFakturaItemSend.DataSource = tbFakturaItemSend;
                    dbgridFakturaItemSend.Columns[0].Visible = false;
                    dbgridFakturaItemSend.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                }
                dv = true;
            }
            else if (txtSearch.Text == "")
            {
                dbgridFakturaSend.DataSource = tbFakturaSend;
                dbgridFakturaSend.Columns[0].Visible = false;
                dbgridFakturaSend.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                if (tbFakturaSend.Rows.Count > 0)
                {
                    lblStatus.Visible = true;
                    tbFakturaItemSend.Clear();
                    string url = "http://santexnika.backoffice.uz/api/fakturaitem/st1/?fak=" + tbFakturaSend.Rows[0]["Фактура_ид"].ToString();
                    string fakturaItemContent = await GetObject(url);
                    lblStatus.Visible = false;
                    if (fakturaItemContent != "[]")
                    {
                        JArray fakturaItemArray = JArray.Parse(fakturaItemContent);
                        if (fakturaItemArray != null)
                        {
                            foreach (var fakturaItem in fakturaItemArray)
                            {
                                DataRow rowFakturaItem = tbFakturaItemSend.NewRow();
                                rowFakturaItem["Фактура"] = fakturaItem["faktura"];
                                //DataRow[] rowProduct = Form1.tbProduct.Select("Махсулот_ид='" + fakturaItem["product"] + "'");
                                rowFakturaItem["Махсулот"] = fakturaItem["product"];
                                rowFakturaItem["Сум"] = fakturaItem["som"];
                                rowFakturaItem["Доллар"] = fakturaItem["dollar"];
                                rowFakturaItem["Микдори"] = fakturaItem["quantity"];
                                tbFakturaItemSend.Rows.Add(rowFakturaItem);
                            }
                        }
                    }
                    dbgridFakturaItemSend.DataSource = tbFakturaItemSend;
                    dbgridFakturaItemSend.Columns[0].Visible = false;
                    dbgridFakturaItemSend.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                }
                dv = false;
            }
        }

        public static bool cell = false;
        private async void dbgridFakturaSend_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cell == false)
            {
                cell = true;

                if(dv == false)
                {
                    if (tbFakturaSend.Rows.Count > 0)
                    {
                        lblStatus.Visible = true;
                        if (tbFakturaSend.Rows.Count > 0) { tbFakturaItemSend.Clear(); }
                        else
                        {
                            tbFakturaItemSend = new DataTable();
                            tbFakturaItemSend.Columns.Add("Фактура");
                            tbFakturaItemSend.Columns.Add("Махсулот");
                            tbFakturaItemSend.Columns.Add("Сум");
                            tbFakturaItemSend.Columns.Add("Доллар");
                            tbFakturaItemSend.Columns.Add("Микдори");
                        }
                        try
                        {
                            string url = "http://santexnika.backoffice.uz/api/fakturaitem/st1/?fak=" + tbFakturaSend.Rows[managerFakturaSend.Position]["Фактура_ид"].ToString();
                            string fakturaItemContent = await GetObject(url);
                            lblStatus.Visible = false;
                            if (fakturaItemContent != "[]")
                            {
                                JArray fakturaItemArray = JArray.Parse(fakturaItemContent);
                                if (fakturaItemArray != null)
                                {
                                    foreach (var fakturaItem in fakturaItemArray)
                                    {
                                        DataRow rowFakturaItem = tbFakturaItemSend.NewRow();
                                        rowFakturaItem["Фактура"] = fakturaItem["faktura"];
                                        //DataRow[] rowProduct = Form1.tbProduct.Select("Махсулот_ид='" + fakturaItem["product"] + "'");
                                        rowFakturaItem["Махсулот"] = fakturaItem["name"];
                                        rowFakturaItem["Сум"] = fakturaItem["som"];
                                        rowFakturaItem["Доллар"] = fakturaItem["dollar"];
                                        rowFakturaItem["Микдори"] = fakturaItem["quantity"];
                                        tbFakturaItemSend.Rows.Add(rowFakturaItem);
                                    }
                                }
                            }
                            dbgridFakturaItemSend.DataSource = tbFakturaItemSend;
                            dbgridFakturaItemSend.Columns[0].Visible = false;
                            dbgridFakturaItemSend.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
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
                    if (tbFkSend.Rows.Count > 0)
                    {
                        lblStatus.Visible = true;
                        if (tbFkSend.Rows.Count > 0) { tbFakturaItemSend.Clear(); }
                        else
                        {
                            tbFakturaItemSend = new DataTable();
                            tbFakturaItemSend.Columns.Add("Фактура");
                            tbFakturaItemSend.Columns.Add("Махсулот");
                            tbFakturaItemSend.Columns.Add("Сум");
                            tbFakturaItemSend.Columns.Add("Доллар");
                            tbFakturaItemSend.Columns.Add("Микдори");
                        }
                        try
                        {
                            string url = "http://santexnika.backoffice.uz/api/fakturaitem/st1/?fak=" + tbFkSend.Rows[managertbFkSend.Position]["Фактура_ид"].ToString();
                            string fakturaItemContent = await GetObject(url);
                            lblStatus.Visible = false;
                            if (fakturaItemContent != "[]")
                            {
                                JArray fakturaItemArray = JArray.Parse(fakturaItemContent);
                                if (fakturaItemArray != null)
                                {
                                    foreach (var fakturaItem in fakturaItemArray)
                                    {
                                        DataRow rowFakturaItem = tbFakturaItemSend.NewRow();
                                        rowFakturaItem["Фактура"] = fakturaItem["faktura"];
                                        //DataRow[] rowProduct = Form1.tbProduct.Select("Махсулот_ид='" + fakturaItem["product"] + "'");
                                        rowFakturaItem["Махсулот"] = fakturaItem["name"];
                                        rowFakturaItem["Сум"] = fakturaItem["som"];
                                        rowFakturaItem["Доллар"] = fakturaItem["dollar"];
                                        rowFakturaItem["Микдори"] = fakturaItem["quantity"];
                                        tbFakturaItemSend.Rows.Add(rowFakturaItem);
                                    }
                                }
                            }
                            dbgridFakturaItemSend.DataSource = tbFakturaItemSend;
                            dbgridFakturaItemSend.Columns[0].Visible = false;
                            dbgridFakturaItemSend.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
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

        public class Product
        {
            public int id { get; set; }
            public string name { get; set; }
            public string measurement { get; set; }

            public string preparer { get; set; }
        }

        private void frmFaktura_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Tab)
            {
                txtSearch.Focus();
            }
        }

        public class FakturaItemAdd
        {
            public int id { get; set; }
            public Product product { get; set; }
            public string name { get; set; }
            public double price { get; set; }
            public double quantity { get; set; }
            public string barcode { get; set; }
            public int faktura { get; set; }
            public int group { get; set; }
        }

        public static bool fakturaItem = false;
        public static bool fakturaItemSend = false;
        static async Task<string> GetObject(string restCallURL)
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


        WaitForm waitForm = new WaitForm();
        public async void frmFaktura_Load(object sender, EventArgs e)
        {

            waitForm.Show(this);
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
                catch(Exception ex)
                {
                    MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Visible = false;
                    lblQayta.Visible = true;
                    return;
                }
            }
            else
            {
                form1 = false;
            }
            if (Form1.fakturaSend == false)
            {
                try
                {
                    lblStatus.Visible = true;
                    tbFakturaSend = new DataTable();
                    tbFakturaSend.Columns.Add("Фактура_ид");
                    tbFakturaSend.Columns.Add("Сум");
                    tbFakturaSend.Columns.Add("Доллар");
                    tbFakturaSend.Columns.Add("Филиал");
                    tbFakturaSend.Columns.Add("Сана");
                    tbFakturaSend.Columns.Add("Статус");
                    string FakturaContent = await GetObject("http://santexnika.backoffice.uz/api/faktura/ombor1/");
                    lblStatus.Visible = false;
                    JArray fakturaArray = JArray.Parse(FakturaContent);
                    if (fakturaArray != null)
                    {
                        foreach (var fakturaItem in fakturaArray)
                        {
                            DataRow rowFaktura = tbFakturaSend.NewRow();
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
                            rowFaktura["Статус"] = "Жўнатилган";
                            tbFakturaSend.Rows.Add(rowFaktura);
                        }
                    }
                    managerFakturaSend = (CurrencyManager)BindingContext[tbFakturaSend];
                    dbgridFakturaSend.DataSource = tbFakturaSend;
                    dbgridFakturaSend.Columns[0].Visible = false;
                    dbgridFakturaSend.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                    tbFakturaSend.Dispose();

                    if (tbFakturaSend.Rows.Count > 0)
                    {
                        lblStatus.Visible = true;
                        tbFakturaItemSend = new DataTable();
                        tbFakturaItemSend.Columns.Add("Фактура");
                        tbFakturaItemSend.Columns.Add("Махсулот");
                        tbFakturaItemSend.Columns.Add("Сум");
                        tbFakturaItemSend.Columns.Add("Доллар");
                        tbFakturaItemSend.Columns.Add("Микдори");
                        string url = "http://santexnika.backoffice.uz/api/fakturaitem/st1/?fak=" + tbFakturaSend.Rows[0]["Фактура_ид"].ToString();
                        string fakturaItemContent = await GetObject(url);
                        lblStatus.Visible = false;
                        if (fakturaItemContent != "[]")
                        {
                            JArray fakturaItemArray = JArray.Parse(fakturaItemContent);
                            if (fakturaItemArray != null)
                            {
                                foreach (var fakturaItem in fakturaItemArray)
                                {
                                    DataRow rowFakturaItem = tbFakturaItemSend.NewRow();
                                    rowFakturaItem["Фактура"] = fakturaItem["faktura"];
                                    //DataRow[] rowProduct = Form1.tbProduct.Select("Махсулот_ид='" + fakturaItem["product"] + "'");
                                    rowFakturaItem["Махсулот"] = fakturaItem["name"];
                                    rowFakturaItem["Сум"] = fakturaItem["som"];
                                    rowFakturaItem["Доллар"] = fakturaItem["dollar"];
                                    rowFakturaItem["Микдори"] = fakturaItem["quantity"];
                                    tbFakturaItemSend.Rows.Add(rowFakturaItem);
                                }
                            }
                        }
                        dbgridFakturaItemSend.DataSource = tbFakturaItemSend;
                        dbgridFakturaItemSend.Columns[0].Visible = false;
                        dbgridFakturaItemSend.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                    }
                    Form1.fakturaSend = true;
                    fakturaItemSend = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Visible = false;
                    lblQayta.Visible = true;
                    return;
                }
                
            }
            else
            {
                dbgridFakturaSend.DataSource = tbFakturaSend;
                dbgridFakturaSend.Columns[0].Visible = false;
                dbgridFakturaSend.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                if (fakturaItemSend)
                {
                    dbgridFakturaItemSend.DataSource = tbFakturaItemSend;
                    dbgridFakturaItemSend.Columns[0].Visible = false;
                    dbgridFakturaItemSend.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                }
            }
            waitForm.Close();
            this.Focus();
            txtSearch.Focus();
        }
    }
}
