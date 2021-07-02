using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace JayhunOmbor
{
    public partial class frmRecieveProduct : Form
    {
        public frmRecieveProduct()
        {
            InitializeComponent();
        }
        public static DataTable tbRecieveItem, tbRecieve_id;
        public static DataTable tbProduct;
        public static CurrencyManager managerProduct;
        public static string filial_id = "0", faktura_id="0";

        public static string last_barcode = "";
        public static string recieve_id = "";
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
        public static bool product = false;
        public static bool load = false;
        public async void frmRecieveProduct_Load(object sender, EventArgs e)
        {
            
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
            managerProduct = (CurrencyManager)BindingContext[tbProduct];
            dbgridSearch.DataSource = tbProduct;
            tbProduct.Dispose();

            if (Form1.recieve == false)
            {
                waitForm.Show(this);
                try
                {
                    tbRecieve_id = new DataTable();
                    tbRecieve_id.Columns.Add("id", typeof(int));
                    tbRecieve_id.Columns.Add("date");
                    tbRecieve_id.Columns.Add("som");
                    tbRecieve_id.Columns.Add("dollar");
                    tbRecieve_id.Columns.Add("status");
                    string Recieve_id = await GetObject("http://santexnika.backoffice.uz/api/recieve/recieve0/"); // recieve_id ni olish uchun
                    JArray arrayRecieve_id = JArray.Parse(Recieve_id);
                    if (arrayRecieve_id != null)
                    {
                        foreach (var id in arrayRecieve_id)
                        {
                            DataRow rowRecieve_id = tbRecieve_id.NewRow();
                            rowRecieve_id["id"] = id["id"];
                            rowRecieve_id["date"] = id["date"];
                            rowRecieve_id["som"] = id["som"];
                            rowRecieve_id["dollar"] = id["dollar"];
                            rowRecieve_id["status"] = id["status"];
                            tbRecieve_id.Rows.Add(rowRecieve_id);
                        }
                    }
                    if (tbRecieve_id.Rows.Count > 0)
                    {
                        recieve_id = tbRecieve_id.Rows[0]["id"].ToString();
                        Form1.recieve_id = recieve_id;
                        txtSummaSom.DataSource = tbRecieve_id;
                        txtSummaSom.DisplayMember = "som";

                        txtSummaDollar.DataSource = tbRecieve_id;
                        txtSummaDollar.DisplayMember = "dollar";

                    }
                    Form1.recieve = true;
                    lblStatus.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblQayta.Visible = true;
                    lblStatus.Visible = false;
                }
                waitForm.Close();
            }
            else
            {
                recieve_id = Form1.recieve_id;
                if (recieve_id != "")
                {
                    try
                    {
                        lblStatus.Visible = true;
                        try { tbRecieve_id.Dispose(); }
                        catch (Exception)
                        {
                            tbRecieve_id = new DataTable();
                            tbRecieve_id.Columns.Add("id", typeof(int));
                            tbRecieve_id.Columns.Add("date");
                            tbRecieve_id.Columns.Add("som");
                            tbRecieve_id.Columns.Add("dollar");
                            tbRecieve_id.Columns.Add("status");
                        }
                        string url = "http://santexnika.backoffice.uz/api/recieve/" + recieve_id + "/";
                        string RecieveIdContent = await GetObject(url);
                        lblStatus.Visible = false;
                        JObject objectRecieveId = JObject.Parse(RecieveIdContent);
                        if (objectRecieveId != null)
                        {
                            DataRow rowRecieveId = tbRecieve_id.NewRow();
                            rowRecieveId["id"] = objectRecieveId["id"];
                            rowRecieveId["date"] = objectRecieveId["date"];
                            rowRecieveId["som"] = objectRecieveId["som"];
                            rowRecieveId["dollar"] = objectRecieveId["dollar"];
                            rowRecieveId["status"] = objectRecieveId["status"];
                            tbRecieve_id.Rows.Add(rowRecieveId);
                        }

                        txtSummaSom.DataSource = tbRecieve_id;
                        txtSummaSom.DisplayMember = "som";

                        txtSummaDollar.DataSource = tbRecieve_id;
                        txtSummaDollar.DisplayMember = "dollar";
                        }
                        catch (Exception ex) { }
                }
            }

            if (recieve_id != "" && load == false)
            {
                load = true;
                try
                {
                    tbRecieveItem = new DataTable();
                    tbRecieveItem.Columns.Add("Кабул_ид", typeof(int)); // recieve_id
                    tbRecieveItem.Columns.Add("Махсулот");
                    tbRecieveItem.Columns.Add("Микдори");
                    tbRecieveItem.Columns.Add("Сўм");
                    tbRecieveItem.Columns.Add("Доллар");
                    tbRecieveItem.Columns.Add("Курс");
                    tbRecieveItem.Columns.Add("id");
                    tbRecieveItem.Columns.Add("product");
                    

                    string url = "http://santexnika.backoffice.uz/api/recieveitem/rv1/?rec=" + recieve_id; // recieveitem ni olish uchun
                    string RecieveItemContent = await GetObject(url);
                    JArray arrayRecieveItem = JArray.Parse(RecieveItemContent);
                    if (arrayRecieveItem != null)
                    {
                        foreach (var RecieveItem in arrayRecieveItem)
                        {
                            DataRow rowRecieveItem = tbRecieveItem.NewRow();
                            rowRecieveItem["Кабул_ид"] = RecieveItem["recieve"];
                            rowRecieveItem["Сўм"] = RecieveItem["som"];
                            rowRecieveItem["Доллар"] = RecieveItem["dollar"];
                            rowRecieveItem["Курс"] = RecieveItem["kurs"];
                            rowRecieveItem["Микдори"] = RecieveItem["quantity"];
                            DataRow[] rows = Form1.tbProduct.Select("Махсулот_ид ='" + RecieveItem["product"].ToString() + "'");
                            rowRecieveItem["Махсулот"] = rows[0]["Махсулот_Номи"];
                            rowRecieveItem["id"] = RecieveItem["id"];
                            rowRecieveItem["product"] = RecieveItem["product"];
                            tbRecieveItem.Rows.Add(rowRecieveItem);
                        }
                    }
                    managerRecieveItem = (CurrencyManager)BindingContext[tbRecieveItem];
                    dbgridRecieve.DataSource = tbRecieveItem;
                    dbgridRecieve.Columns[0].Visible = false;
                    dbgridRecieve.Columns[6].Visible = false;
                    dbgridRecieve.Columns[7].Visible = false;
                    dbgridRecieve.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                    btnQabul.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblQayta.Visible = true;
                    lblStatus.Visible = false;
                }
                load = false;
            }
            this.Focus();
            textBox1.Focus();
        }

        public static bool added = false;
        private void iconButton4_Click(object sender, EventArgs e)
        {
            if (btnQabul.Enabled)
            {
                MessageBox.Show("Кабул бошланмаган, Илтимос аввал 'Кабулни бошлаш' тугмасини босинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Form1.tbProduct.Rows.Count > 0)
            {
                DataRow rowBarcode = Form1.tbProduct.Select("Штрих_код like '1%'", "Штрих_код ASC").Last();
                last_barcode = rowBarcode["Штрих_код"].ToString();
            }
            else
            {
                last_barcode = "9999999";
            }
            s newProduct = new s();

            added = false;
            newProduct.last_barcode = last_barcode;
            newProduct.faktura_id = faktura_id;
            if(newProduct.ShowDialog() == DialogResult.OK)
            {
                if(added)
                {
                    try
                    {
                        ShowProduct();
                        ShowRecieve(recieve_id);
                    }
                    catch (Exception)
                    {
                        added = false;
                    }
                }
            }
            
        }
        
        private void dbgridRecieve_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridRecieve.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Y + 4);
            }
        }

        public static CurrencyManager managerRecieveItem;

        private void iconButton5_Click(object sender, EventArgs e)
        {
            frmCreateRecieve createRecieve = new frmCreateRecieve();
            if (createRecieve.ShowDialog() == DialogResult.OK)
            {
                txtSummaSom.DataSource = tbRecieve_id;
                txtSummaSom.DisplayMember = "som";

                txtSummaDollar.DataSource = tbRecieve_id;
                txtSummaDollar.DisplayMember = "dollar";

                try
                {
                    managerRecieveItem = (CurrencyManager)BindingContext[tbRecieveItem];
                    dbgridRecieve.DataSource = tbRecieveItem;
                    dbgridRecieve.Columns[0].Visible = false;
                    dbgridRecieve.Columns[6].Visible = false;
                    dbgridRecieve.Columns[7].Visible = false;
                    dbgridRecieve.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                    tbRecieveItem.Dispose();
                    btnQabul.Enabled = false;
                }
                catch (Exception) { }
            }
            //try
            //{
            //    Uri u = new Uri("http://santexnika.backoffice.uz/api/recieve/"); // yangi recieve_id ni olish uchun
            //    HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
            //    var t = Task.Run(() => PostURI(u, content));
            //    t.Wait();
            //    if (t.Result != "Error!" && t.Result.Length != 0)
            //    {
            //        tbRecieve_id = new DataTable();
            //        tbRecieve_id.Columns.Add("id", typeof(int));
            //        tbRecieve_id.Columns.Add("date");
            //        tbRecieve_id.Columns.Add("som");
            //        tbRecieve_id.Columns.Add("dollar");
            //        tbRecieve_id.Columns.Add("status");

            //        string RecieveIdContent = t.Result;
            //        JObject objectRecieveId = JObject.Parse(RecieveIdContent);
            //        if (objectRecieveId != null)
            //        {
            //            DataRow rowRecieve_id = tbRecieve_id.NewRow();
            //            rowRecieve_id["id"] = objectRecieveId["id"];
            //            rowRecieve_id["date"] = objectRecieveId["date"];
            //            rowRecieve_id["som"] = objectRecieveId["som"];
            //            rowRecieve_id["dollar"] = objectRecieveId["dollar"];
            //            rowRecieve_id["status"] = objectRecieveId["status"];
            //            tbRecieve_id.Rows.Add(rowRecieve_id);

            //            txtSummaSom.DataSource = tbRecieve_id;
            //            txtSummaSom.DisplayMember = "som";

            //            txtSummaDollar.DataSource = tbRecieve_id;
            //            txtSummaDollar.DisplayMember = "dollar";

            //            recieve_id = objectRecieveId["id"].ToString();
            //            Form1.recieve_id = recieve_id;
            //            Form1.recieve = false;
            //            tbRecieve_id.Dispose();
            //        }

            //        tbRecieveItem = new DataTable();
            //        tbRecieveItem.Columns.Add("Кабул_ид", typeof(int)); // recieve_id
            //        tbRecieveItem.Columns.Add("Сўм");
            //        tbRecieveItem.Columns.Add("Доллар");
            //        tbRecieveItem.Columns.Add("Курс");
            //        tbRecieveItem.Columns.Add("Микдори");
            //        tbRecieveItem.Columns.Add("Махсулот");
            //        dbgridRecieve.DataSource = tbRecieveItem;
            //        dbgridRecieve.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            //        tbRecieveItem.Dispose();
            //        MessageBox.Show("Кабул килиш муваффакиятли бошланди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        btnQabul.Enabled = false;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Сэрвэр билан богланишда хатолик, илтимос интэрнэтни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        public static async Task<string> GetObject()
        {
            HttpClient apiCallClient = new HttpClient();
            String restCallURL = "http://santexnika.backoffice.uz/api/product/";
            string authToken = "token 28aeccd6cbbb18b16fddf2967d0b35242ad6a0a3";
            HttpRequestMessage apirequest = new HttpRequestMessage(HttpMethod.Get, restCallURL);
            apirequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apirequest.Headers.Add("Authorization", authToken);
            HttpResponseMessage apiCallResponse = await apiCallClient.SendAsync(apirequest);

            String requestresponse = await apiCallResponse.Content.ReadAsStringAsync();
            return requestresponse;
        }
        WaitFormFunc waitForm = new WaitFormFunc();

        private async void iconButton2_Click(object sender, EventArgs e)
        {
           
            if (tbRecieveItem.Rows.Count == 0) return;
            waitForm.Show(this);
            try
            {
                Uri u = new Uri("http://santexnika.backoffice.uz/api/product/add/");
                var payload = "{\"recieve\": \"" + recieve_id + "\"}";
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                var t = Task.Run(() => PostURI(u, content));
                t.Wait();

                if (t.Result != "Error!" && t.Result.Length != 0)
                {
                    recieve_id = "";
                    Form1.recieve_id = "";
                    tbRecieve_id.Clear();
                    tbRecieve_id.Dispose();
                    tbRecieveItem.Clear();
                    tbRecieveItem.Dispose();

                    if (faktura_id != "0")
                    {
                        try
                        {
                            Uri ur = new Uri("http://santexnika.backoffice.uz/api/faktura/st/");
                            string faktura = faktura_id;
                            var payloadr = "{\"faktura\": \"" + faktura + "\"}";//
                            HttpContent contentr = new StringContent(payloadr, Encoding.UTF8, "application/json");
                            var tr = Task.Run(() => PostURI(ur, contentr));
                            t.Wait();
                            if (tr.Result != "Error!" && tr.Result.Length != 0)
                            {
                                
                                MessageBox.Show("Махсулотлар омборга муваффакиятли кабул килинди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                waitForm.Close();
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        
                    }
                    else
                    {
                        waitForm.Close();
                        MessageBox.Show("Махсулотлар омборга муваффакиятли кабул килинди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    btnQabul.Enabled = true;
                    faktura_id = "0";
                    #region Maxsulotlarni qaytadan yuklaymiz
                    try
                    {
                        Form1.tbProduct.Clear();
                        waitForm.Show(this);
                        string productContent = await GetObject();
                        waitForm.Close();
                        this.Focus();
                    
                        JArray productArray = JArray.Parse(productContent);
                        if (productArray != null)
                        {
                            foreach (var productItem in productArray)
                            {
                                DataRow rowProduct = Form1.tbProduct.NewRow();
                                rowProduct["Махсулот_ид"] = productItem["id"];
                                rowProduct["Махсулот_Номи"] = productItem["name"];
                                rowProduct["Ишлаб_чикарувчи"] = productItem["preparer"];
                                rowProduct["Сўм"] = productItem["som"];
                                rowProduct["Доллар"] = productItem["dollar"];
                                rowProduct["Курс"] = productItem["kurs"];
                                rowProduct["Микдори"] = productItem["quantity"];
                                rowProduct["Улчов"] = productItem["measurement"];
                                rowProduct["Штрих_код"] = productItem["barcode"];
                                rowProduct["Гурух"] = productItem["group"];
                                Form1.tbProduct.Rows.Add(rowProduct);
                            }
                        }
                        Form1.managerProduct = (CurrencyManager)BindingContext[Form1.tbProduct];
                        //tbProduct.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        try { waitForm.Close(); } catch (Exception) { }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static bool showRecieve = false;
        public static string id = "0", som = "", dollar = "", kurs = "", quantity = "", recieve = "", product1 = ""; // recieveitemuchun

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnQabul.Enabled)
            {
                MessageBox.Show("Кабул бошланмаган, Илтимос аввал 'Кабулни бошлаш' тугмасини босинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (e.KeyCode == Keys.Down)
            {
                dbgridSearch.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (dbgridSearch.Rows.Count > 0)
                {
                    frmRecieveAdd recieveAdd = new frmRecieveAdd();
                    recieveAdd.recieve_id = recieve_id;
                    recieveAdd.product_id = tbPr.Rows[managerPr.Position]["Махсулот_ид"].ToString();
                    recieveAdd.name = tbPr.Rows[managerPr.Position]["Махсулот_Номи"].ToString();
                    recieveAdd.som = tbPr.Rows[managerPr.Position]["Сўм"].ToString();
                    recieveAdd.dollar = tbPr.Rows[managerPr.Position]["Доллар"].ToString();
                    recieveAdd.kurs = tbPr.Rows[managerPr.Position]["Курс"].ToString();
                    recieveAdd.group = tbPr.Rows[managerPr.Position]["Гурух"].ToString();
                    recieveAdd.barcode = tbPr.Rows[managerPr.Position]["Штрих_код"].ToString();
                    recieveAdd.faktura_id = faktura_id;
                    if (recieveAdd.ShowDialog() == DialogResult.OK)
                    {
                        textBox1.Clear();
                        ShowRecieve(recieve_id);
                    }
                    else
                    {
                        textBox1.Clear();
                    }
                }
            }
        }

        private void dbgridSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnQabul.Enabled)
            {
                MessageBox.Show("Кабул бошланмаган, Илтимос аввал 'Кабулни бошлаш' тугмасини босинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (btnQabul.Enabled)
                {
                    MessageBox.Show("Кабул бошланмаган, Илтимос аввал 'Кабулни бошлаш' тугмасини босинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frmRecieveAdd recieveAdd = new frmRecieveAdd();
                recieveAdd.recieve_id = recieve_id;
                recieveAdd.product_id = tbPr.Rows[managerPr.Position]["Махсулот_ид"].ToString();
                recieveAdd.name = tbPr.Rows[managerPr.Position]["Махсулот_Номи"].ToString();
                recieveAdd.som = tbPr.Rows[managerPr.Position]["Сўм"].ToString();
                recieveAdd.dollar = tbPr.Rows[managerPr.Position]["Доллар"].ToString();
                recieveAdd.kurs = tbPr.Rows[managerPr.Position]["Курс"].ToString();
                recieveAdd.group = tbPr.Rows[managerPr.Position]["Гурух"].ToString();
                recieveAdd.barcode = tbPr.Rows[managerPr.Position]["Штрих_код"].ToString();
                recieveAdd.faktura_id = faktura_id;
                if (recieveAdd.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Clear();
                    ShowRecieve(recieve_id);
                }
                else
                {
                    textBox1.Clear();
                }
            }
        }

        public static DataTable tbPr;

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (btnQabul.Enabled)
            {
                MessageBox.Show("Кабул бошланмаган, Илтимос аввал 'Кабулни бошлаш' тугмасини босинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            edit = false;
            frmEditRecieve editRecieve = new frmEditRecieve();
            editRecieve.name = tbRecieveItem.Rows[managerRecieveItem.Position]["Махсулот"].ToString();
            editRecieve.product_id = tbRecieveItem.Rows[managerRecieveItem.Position]["product"].ToString();
            editRecieve.recieveItem_id = tbRecieveItem.Rows[managerRecieveItem.Position]["id"].ToString();
            editRecieve.som = tbRecieveItem.Rows[managerRecieveItem.Position]["Сўм"].ToString();
            editRecieve.dollar = tbRecieveItem.Rows[managerRecieveItem.Position]["Доллар"].ToString();
            editRecieve.kurs = tbRecieveItem.Rows[managerRecieveItem.Position]["Курс"].ToString();
            editRecieve.quantity = tbRecieveItem.Rows[managerRecieveItem.Position]["Микдори"].ToString();
            editRecieve.recieve_id = recieve_id;
            if(editRecieve.ShowDialog() == DialogResult.OK)
            {
                EditRecieve(tbRecieveItem.Rows[managerRecieveItem.Position]["id"].ToString(),
                    tbRecieveItem.Rows[managerRecieveItem.Position]["product"].ToString());
            }
        }

        public static bool edit = false;
        public static string edit_som = "", edit_dollar = "", edit_kurs = "", edit_quantity = "";

        private async void iconButton5_Click_1(object sender, EventArgs e)
        {
            if (recieve_id != "" && dbgridRecieve.Rows.Count > 0)
            {

                try
                {
                    Uri u = new Uri("http://santexnika.backoffice.uz/api/recieveitem/delete/");
                    var payload = "{\"item\": \""+tbRecieveItem.Rows[managerRecieveItem.Position]["id"].ToString()+"\"}";
                    HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                    var t = Task.Run(() => PostURI(u, content));
                    t.Wait();
                    if (t.Result != "Error!" && t.Result.Length != 0)
                    {
                        
                        if(faktura_id !="0")
                        {

                        }

                        DataTable t1 = new DataTable();
                        t1.Columns.Add("id");
                        dbgridRecieve.DataSource = t1;

                        DataRow rowItem = tbRecieveItem.Select("id='" + tbRecieveItem.Rows[managerRecieveItem.Position]["id"] + "'", "id ASC").Last();
                        rowItem.Delete();
                        tbRecieveItem.AcceptChanges();
                        dbgridRecieve.DataSource = tbRecieveItem;
                        dbgridRecieve.Columns[0].Visible = false;
                        dbgridRecieve.Columns[6].Visible = false;
                        dbgridRecieve.Columns[7].Visible = false;
                        try
                        {
                            lblStatus.Visible = true;
                            if (recieve_id != "") { try { tbRecieve_id.Clear(); } catch (Exception) { } }
                            else
                            {
                                tbRecieve_id = new DataTable();
                                tbRecieve_id.Columns.Add("id", typeof(int));
                                tbRecieve_id.Columns.Add("date");
                                tbRecieve_id.Columns.Add("som");
                                tbRecieve_id.Columns.Add("dollar");
                                tbRecieve_id.Columns.Add("status");
                            }
                            string url = "http://santexnika.backoffice.uz/api/recieve/" + recieve_id + "/";
                            string RecieveIdContent = await GetObject(url);
                            lblStatus.Visible = false;
                            JObject objectRecieveId = JObject.Parse(RecieveIdContent);
                            if (objectRecieveId != null)
                            {
                                DataRow rowRecieveId = tbRecieve_id.NewRow();
                                rowRecieveId["id"] = objectRecieveId["id"];
                                rowRecieveId["date"] = objectRecieveId["date"];
                                rowRecieveId["som"] = objectRecieveId["som"];
                                rowRecieveId["dollar"] = objectRecieveId["dollar"];
                                rowRecieveId["status"] = objectRecieveId["status"];
                                tbRecieve_id.Rows.Add(rowRecieveId);
                            }

                            txtSummaSom.DataSource = tbRecieve_id;
                            txtSummaSom.DisplayMember = "som";

                            txtSummaDollar.DataSource = tbRecieve_id;
                            txtSummaDollar.DisplayMember = "dollar";

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lblStatus.Visible = false;
                            lblQayta.Visible = true;
                            edit = true;
                        }
                        MessageBox.Show("Махсулот муваффакиятли ўчирилди!!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void frmRecieveProduct_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Tab)
            {
                textBox1.Focus();
            }
        }

        private async void iconButton3_Click(object sender, EventArgs e)
        {
            waitForm.Show(this);
            if (recieve_id != "")
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://santexnika.backoffice.uz/");
                    client.DefaultRequestHeaders.Add("Authorization", "token 28aeccd6cbbb18b16fddf2967d0b35242ad6a0a3");
                    string url = "api/recieve/" + recieve_id + "/";
                    var response = client.DeleteAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        tbRecieveItem.Clear();
                        tbRecieve_id.Clear();
                        recieve_id = "";
                        Form1.recieve_id = "";
                        btnQabul.Enabled = true;

                        if(faktura_id !="0")
                        {
                            string urlr = "http://santexnika.backoffice.uz/api/faktura/otkaz/?fak=" + faktura_id;
                            string responce = await GetObject(urlr);
                        }


                        faktura_id = "0";

                        MessageBox.Show("Кабул бeкор килинди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        waitForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Интeрнeт билан богланишни тeкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                
            }
        }

        public string DoubleToStr(string s)
        {
            if(s.IndexOf(',') > -1)
            {
                int index = s.IndexOf(',');
                string first = s.Substring(0, index);
                string last = s.Substring(index + 1);
                s = first + "." + last;
            }
            return s;
        }

        public async void EditRecieve(string recieveItem_id, string product_id)
        {
            if (edit)
            {
                DataTable t = new DataTable();
                t.Columns.Add("id");
                dbgridRecieve.DataSource = t;
                DataRow row = tbRecieveItem.Select("id='" + recieveItem_id + "'", "id ASC").Last();
                row["Сўм"] = edit_som;
                row["Доллар"] = edit_dollar;
                row["Курс"] = edit_kurs;
                row["Микдори"] = edit_quantity;

                row.EndEdit();
                tbRecieveItem.AcceptChanges();
                dbgridRecieve.DataSource = tbRecieveItem;
                dbgridRecieve.Columns[0].Visible = false;
                dbgridRecieve.Columns[6].Visible = false;
                dbgridRecieve.Columns[7].Visible = false;

                try
                {
                    lblStatus.Visible = true;
                    if (recieve_id != "") { try { tbRecieve_id.Clear(); } catch (Exception) { } }
                    else
                    {
                        tbRecieve_id = new DataTable();
                        tbRecieve_id.Columns.Add("id", typeof(int));
                        tbRecieve_id.Columns.Add("date");
                        tbRecieve_id.Columns.Add("som");
                        tbRecieve_id.Columns.Add("dollar");
                        tbRecieve_id.Columns.Add("status");
                    }
                    string url = "http://santexnika.backoffice.uz/api/recieve/" + recieve_id + "/";
                    string RecieveIdContent = await GetObject(url);
                    lblStatus.Visible = false;
                    JObject objectRecieveId = JObject.Parse(RecieveIdContent);
                    if (objectRecieveId != null)
                    {
                        DataRow rowRecieveId = tbRecieve_id.NewRow();
                        rowRecieveId["id"] = objectRecieveId["id"];
                        rowRecieveId["date"] = objectRecieveId["date"];
                        rowRecieveId["som"] = objectRecieveId["som"];
                        rowRecieveId["dollar"] = objectRecieveId["dollar"];
                        rowRecieveId["status"] = objectRecieveId["status"];
                        tbRecieve_id.Rows.Add(rowRecieveId);
                    }

                    txtSummaSom.DataSource = tbRecieve_id;
                    txtSummaSom.DisplayMember = "som";

                    txtSummaDollar.DataSource = tbRecieve_id;
                    txtSummaDollar.DisplayMember = "dollar";

                }
                catch(Exception)
                {
                    MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Visible = false;
                    lblQayta.Visible = true;
                    edit = true;
                }
            }
        }

        public static CurrencyManager managerPr;
        public static bool dv = false;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Form1.tbProduct.Rows.Count > 0 && textBox1.Text.Length > 2)
            {
                DataRow[] rows;
                try
                {
                    double number = double.Parse(textBox1.Text, CultureInfo.InvariantCulture);
                    if (textBox1.Text.Length > 2)
                    {
                        rows = Form1.tbProduct.Select("Штрих_код like '%" + textBox1.Text + "%'");
                        tbPr = new DataTable();
                        tbPr.Columns.Add("Махсулот_ид", typeof(int));
                        tbPr.Columns.Add("Гурух");
                        tbPr.Columns.Add("Махсулот_Номи");
                        tbPr.Columns.Add("Ишлаб_чикарувчи");
                        tbPr.Columns.Add("Сўм");
                        tbPr.Columns.Add("Доллар");
                        tbPr.Columns.Add("Курс");
                        tbPr.Columns.Add("Микдори");
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
                            row["Штрих_код"] = item["Штрих_код"];
                            row["Гурух"] = item["Гурух"];
                            tbPr.Rows.Add(row);
                        }
                        dbgridSearch.DataSource = tbPr;
                        dbgridSearch.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dbgridSearch.MaximumSize = new Size(this.dbgridSearch.Width, 300);
                        //dbgridSearch.AutoSize = true;
                        dbgridSearch.Columns[0].Visible = false;
                        dbgridSearch.Columns[1].Visible = false;

                        dbgridSearch.Columns[3].Visible = false;
                        dbgridSearch.RowHeadersVisible = false;
                        dbgridSearch.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

                        managerPr = (CurrencyManager)BindingContext[tbPr];
                        tbPr.Dispose();
                        if(tbPr.Rows.Count == 0)
                        {
                            rows = Form1.tbProduct.Select("Махсулот_Номи like '%" + textBox1.Text + "%'");

                            //rows = Form1.tbProduct.Select("Штрих_код like '%" + textBox1.Text + "%'");

                            tbPr = new DataTable();
                            tbPr.Columns.Add("Махсулот_ид", typeof(int));
                            tbPr.Columns.Add("Гурух");
                            tbPr.Columns.Add("Махсулот_Номи");
                            tbPr.Columns.Add("Ишлаб_чикарувчи");
                            tbPr.Columns.Add("Сўм");
                            tbPr.Columns.Add("Доллар");
                            tbPr.Columns.Add("Курс");
                            tbPr.Columns.Add("Микдори");
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
                                row["Штрих_код"] = item["Штрих_код"];
                                row["Гурух"] = item["Гурух"];
                                tbPr.Rows.Add(row);
                            }
                            dbgridSearch.DataSource = tbPr;
                            dbgridSearch.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dbgridSearch.MaximumSize = new Size(this.dbgridSearch.Width, 300);
                            //dbgridSearch.AutoSize = true;
                            dbgridSearch.Columns[0].Visible = false;
                            dbgridSearch.Columns[1].Visible = false;
                            dbgridSearch.Columns[3].Visible = false;
                            dbgridSearch.RowHeadersVisible = false;
                            dbgridSearch.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

                            managerPr = (CurrencyManager)BindingContext[tbPr];
                            tbPr.Dispose();
                        }
                    }
                }
                catch (Exception)
                {
                    rows = Form1.tbProduct.Select("Махсулот_Номи like '%" + textBox1.Text + "%'");

                    //rows = Form1.tbProduct.Select("Штрих_код like '%" + textBox1.Text + "%'");

                    tbPr = new DataTable();
                    tbPr.Columns.Add("Махсулот_ид", typeof(int));
                    tbPr.Columns.Add("Гурух");
                    tbPr.Columns.Add("Махсулот_Номи");
                    tbPr.Columns.Add("Ишлаб_чикарувчи");
                    tbPr.Columns.Add("Сўм");
                    tbPr.Columns.Add("Доллар");
                    tbPr.Columns.Add("Курс");
                    tbPr.Columns.Add("Микдори");
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
                        row["Штрих_код"] = item["Штрих_код"];
                        row["Гурух"] = item["Гурух"];
                        tbPr.Rows.Add(row);
                    }
                    dbgridSearch.DataSource = tbPr;
                    dbgridSearch.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dbgridSearch.MaximumSize = new Size(this.dbgridSearch.Width, 300);
                    //dbgridSearch.AutoSize = true;
                    dbgridSearch.Columns[0].Visible = false;
                    dbgridSearch.Columns[1].Visible = false;
                    dbgridSearch.Columns[3].Visible = false;
                    dbgridSearch.RowHeadersVisible = false;
                    dbgridSearch.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

                    managerPr = (CurrencyManager)BindingContext[tbPr];
                    tbPr.Dispose();
                }
                dv = true;
                dbgridSearch.Visible = true;
            }
            else
            {
                dbgridSearch.Visible = false;
                dbgridSearch.DataSource = tbProduct;
                dbgridSearch.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dbgridSearch.MaximumSize = new Size(this.dbgridSearch.Width, 300);
                //dbgridSearch.AutoSize = true;
                dbgridSearch.RowHeadersVisible = false;
                dbgridSearch.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

                dv = false;
            }
        }

        public async void ShowRecieve(string recieve_id)
        {
            try
            {
                lblStatus.Visible = true;
                if (recieve_id != "") { try { tbRecieve_id.Clear(); } catch (Exception) { } }
                else
                {
                    tbRecieve_id = new DataTable();
                    tbRecieve_id.Columns.Add("id", typeof(int));
                    tbRecieve_id.Columns.Add("date");
                    tbRecieve_id.Columns.Add("som");
                    tbRecieve_id.Columns.Add("dollar");
                    tbRecieve_id.Columns.Add("status");
                }
                string url = "http://santexnika.backoffice.uz/api/recieve/" + recieve_id +"/";
                string RecieveIdContent = await GetObject(url);
                lblStatus.Visible = false;
                JObject objectRecieveId = JObject.Parse(RecieveIdContent);
                if (objectRecieveId != null)
                {
                    DataRow rowRecieveId = tbRecieve_id.NewRow();
                    rowRecieveId["id"] = objectRecieveId["id"];
                    rowRecieveId["date"] = objectRecieveId["date"];
                    rowRecieveId["som"] = objectRecieveId["som"];
                    rowRecieveId["dollar"] = objectRecieveId["dollar"];
                    rowRecieveId["status"] = objectRecieveId["status"];
                    tbRecieve_id.Rows.Add(rowRecieveId);
                }

                txtSummaSom.DataSource = tbRecieve_id;
                txtSummaSom.DisplayMember = "som";

                txtSummaDollar.DataSource = tbRecieve_id;
                txtSummaDollar.DisplayMember = "dollar";

                try
                {
                    DataTable tb = new DataTable();
                    dbgridRecieve.DataSource = tb;
                    DataRow row = tbRecieveItem.NewRow();
                    row["Кабул_ид"] = recieve;
                    row["Сўм"] = som;
                    row["Доллар"] = dollar;
                    row["Курс"] = kurs;
                    row["Микдори"] = quantity;
                    DataRow[] rows = Form1.tbProduct.Select("Махсулот_ид ='" + product1 + "'");
                    row["Махсулот"] = rows[0]["Махсулот_Номи"];
                    row["id"] = id;
                    row["product"] = product1;
                    tbRecieveItem.Rows.Add(row);
                    dbgridRecieve.DataSource = tbRecieveItem;
                    dbgridRecieve.Columns[0].Visible = false;
                    dbgridRecieve.Columns[6].Visible = false;
                    dbgridRecieve.Columns[7].Visible = false;
                    dbgridRecieve.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Shu yer 2");
                    MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Visible = false;
                    lblQayta.Visible = true;
                    showRecieve = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Visible = false;
                lblQayta.Visible = true;
                showRecieve = true;
            }
        }

        private void lblQayta_Click(object sender, EventArgs e)
        {
            if(edit)
            {
                try
                {
                    EditRecieve(tbRecieveItem.Rows[managerRecieveItem.Position]["id"].ToString(),
                        tbRecieveItem.Rows[managerRecieveItem.Position]["product"].ToString());
                    edit = false;
                }
                catch (Exception) { }
            }
            if(showRecieve)
            {
                ShowRecieve(recieve_id);
            }
            else
            {
                frmRecieveProduct_Load(sender, e);
                lblQayta.Visible = false;
            }

            
        }
        public static string product_id = "", product_name = "", product_preparer = "", product_som = "", product_dollar = "", product_kurs = "", product_quantity = "", product_barcode = "", product_group = "";
        public async void ShowProduct()
        {
            try
            {
                DataRow row = Form1.tbProduct.NewRow();
                row["Махсулот_ид"] = product_id;
                row["Гурух"] = product_group;
                row["Махсулот_Номи"] = product_name;
                row["Ишлаб_чикарувчи"] = product_preparer;
                row["Сўм"] = product_som;
                row["Доллар"] = product_dollar;
                row["Курс"] = product_kurs;
                row["Микдори"] = product_quantity;
                row["Штрих_код"] = product_barcode;
                Form1.tbProduct.Rows.Add(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Shu yer 3");
                MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}