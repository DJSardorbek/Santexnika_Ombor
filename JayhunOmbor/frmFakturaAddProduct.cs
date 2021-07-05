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
    public partial class frmFakturaAddProduct : MetroFramework.Forms.MetroForm
    {
        public frmFakturaAddProduct()
        {
            InitializeComponent();
        }
        public string name = "", som = "", dollar="", kurs="", quanOmbor="";
        private void frmFakturaAddProduct_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            txtName.Text = name;
            txtSom.Text = som;
            txtDollar.Text = dollar;
            txtKurs.Text = kurs;
            txtOmborQuan.Text = quanOmbor;
            txtSoldPrice.Focus();
            if(dollar=="0" && kurs == "0")
            {
                panelDollar.Visible = false;
                panelDollar.Dock = DockStyle.None;
                Width = 727; Height = 439;
            }
            else
            {
                panelDollar.Visible = true;
                panelDollar.Dock = DockStyle.Top;
                Width = 727; Height = 551;
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            frmFakturaTayyorlash.faktura_cancel = true;
            Close();
        }

        static async Task<string> GetObject()
        {
            HttpClient apiCallClient = new HttpClient();
            String restCallURL = "http://santexnika.backoffice.uz/api/product/";
            string authToken = "token 62115f83e1c1e8b588fa419330976ea6012d1cd4";
            HttpRequestMessage apirequest = new HttpRequestMessage(HttpMethod.Get, restCallURL);
            apirequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apirequest.Headers.Add("Authorization", authToken);
            HttpResponseMessage apiCallResponse = await apiCallClient.SendAsync(apirequest);

            String requestresponse = await apiCallResponse.Content.ReadAsStringAsync();
            return requestresponse;
        }

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

        static async Task<string> PostURI(Uri u, HttpContent c)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "token 62115f83e1c1e8b588fa419330976ea6012d1cd4");
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

        public static string product = "",price_som="", price_dollar="", tan_som="", tan_dollar="",quantity="", barcode="", Pname="",guruh="";

        public void iconButton1_Click(object sender, EventArgs e)
        {
            if(txtQuantity.Text=="")
            {
                MessageBox.Show("Микдорни киритинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtQuantity.Text.IndexOf(',') > -1)
            {
                MessageBox.Show("Нукта билан киритинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string quanOm = DoubleToStr(txtOmborQuan.Text);
            if(double.Parse(quanOm, CultureInfo.InvariantCulture) < double.Parse(txtQuantity.Text,CultureInfo.InvariantCulture))
            {
                MessageBox.Show("Жўнатиш микдори кўп киритилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtSoldPrice.Text == "")
            {
                MessageBox.Show("Сотиш нархини киритинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                product = frmFakturaTayyorlash.tbPr.Rows[frmFakturaTayyorlash.managerPr.Position]["Махсулот_ид"].ToString();
                if (panelDollar.Visible)
                {
                    price_dollar = txtSoldPrice.Text;
                    tan_dollar = txtDollar.Text;
                    tan_som = "0";
                    price_som = "0";
                }
                else
                {
                    price_dollar = "0";
                    tan_dollar = "0";
                    price_som = txtSoldPrice.Text;
                    tan_som = txtSom.Text;
                }
                quantity = txtQuantity.Text;
                barcode = frmFakturaTayyorlash.tbPr.Rows[frmFakturaTayyorlash.managerPr.Position]["Штрих_код"].ToString();
                Pname = frmFakturaTayyorlash.tbPr.Rows[frmFakturaTayyorlash.managerPr.Position]["Махсулот_Номи"].ToString();
                guruh = frmFakturaTayyorlash.tbPr.Rows[frmFakturaTayyorlash.managerPr.Position]["Гурух"].ToString();
                
                Uri u = new Uri("http://santexnika.backoffice.uz/api/fakturaitem/add/");
                var payload = "{\"name\": \"" + Pname + "\",\"faktura\": \"" + frmFakturaTayyorlash.faktura_id + "\",\"product\": \"" + product + "\",\"som\": \"" + price_som + "\",\"dollar\": \""+price_dollar+ "\",\"group\": \"" + guruh + "\",\"barcode\": \"" + barcode + "\",\"quantity\": \"" + quantity + "\",\"body_som\": \""+tan_som+"\",\"body_dollar\": \""+tan_dollar+"\"}";

                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                var t = Task.Run(() => PostURI(u, content));
                t.Wait();
                if (t.Result != "Error!" && t.Result.Length != 0)
                {
                    string Responce = t.Result;
                    FakturaItemAdd objectFaktura = JsonConvert.DeserializeObject<FakturaItemAdd>(Responce);
                    Form1.faktura = false;
                    string product_quantity = txtQuantity.Text;
                    string total_quantity = frmFakturaTayyorlash.tbPr.Rows[frmFakturaTayyorlash.managerPr.Position]["Микдори"].ToString();
                    total_quantity = DoubleToStr(total_quantity);
                    double Dproduct_quantity = double.Parse(product_quantity, CultureInfo.InvariantCulture);
                    double Dtotal_quantity = double.Parse(total_quantity, CultureInfo.InvariantCulture);
                    double result_quantity = Dtotal_quantity - Dproduct_quantity;
                    string str_result_quantity = result_quantity.ToString();
                    str_result_quantity = DoubleToStr(str_result_quantity);
                    DataRow row = Form1.tbProduct.Select("Махсулот_ид='" + product + "'", "Махсулот_ид ASC").Last();
                    row["Микдори"] = str_result_quantity;
                    row.EndEdit();
                    Form1.tbProduct.AcceptChanges();
                    frmFakturaTayyorlash.faktura = objectFaktura.faktura.ToString();
                    frmFakturaTayyorlash.product_name = objectFaktura.name;
                    frmFakturaTayyorlash.som = objectFaktura.som.ToString();
                    frmFakturaTayyorlash.dollar = objectFaktura.dollar.ToString();
                    frmFakturaTayyorlash.quantity = objectFaktura.quantity.ToString();
                    frmFakturaTayyorlash.preparer = objectFaktura.product.preparer;
                    frmFakturaTayyorlash.measurement = objectFaktura.product.measurement;
                    frmFakturaTayyorlash.product_id = objectFaktura.product.id.ToString();
                    frmFakturaTayyorlash.id = objectFaktura.id.ToString();
                    Close();
                }
                else
                {
                    MessageBox.Show("Сэрвэр билан богланишда хатолик, илтимос интэрнэтни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmFakturaAddProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                iconButton1_Click(sender, e);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
