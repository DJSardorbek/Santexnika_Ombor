using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static DataTable tbProduct;
        public static CurrencyManager managerProduct;
        public static bool filial = false;
        public static bool faktura = false;
        public static bool fakturaSend = false;
        public static string faktura_id = "";
        public static bool recieve = false;
        public static string recieve_id = "";
        public Form activateForm = null;
        public void openChildForm(Form childForm)
        {
            if (activateForm != null)
                activateForm.Close();
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMenu.Controls.Add(childForm);
            panelMenu.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new frmOmborMaxsulot());
            lblDisplay.Text = btnProduct.Text;
            btnProduct.BackColor = Color.FromArgb(75, 158, 253);
            btnHome.BackColor = Color.FromArgb(30, 31, 68);
            btnRecieve.BackColor = Color.FromArgb(30, 31, 68);
            btnFakturaTayy.BackColor = Color.FromArgb(30, 31, 68);
            btnFiliallar.BackColor = Color.FromArgb(30, 31, 68);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
                panel1.Dock = DockStyle.None;
                iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Bars;
            }
            else
            {
                panel1.Visible = true;
                panel1.Dock = DockStyle.Left;
                iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.CalendarTimes;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (activateForm != null)
                activateForm.Close();
            lblDisplay.Text = btnHome.Text;
            btnHome.BackColor = Color.FromArgb(75, 158, 253);
            btnProduct.BackColor = Color.FromArgb(30, 31, 68);
            btnRecieve.BackColor = Color.FromArgb(30, 31, 68);
            btnFakturaTayy.BackColor = Color.FromArgb(30, 31, 68);
            btnFiliallar.BackColor = Color.FromArgb(30, 31, 68);


        }

        private void btnRecieve_Click(object sender, EventArgs e)
        {
            openChildForm(new frmRecieveProduct());
            lblDisplay.Text = btnRecieve.Text;
            btnRecieve.BackColor = Color.FromArgb(75, 158, 253);
            btnHome.BackColor = Color.FromArgb(30, 31, 68);
            btnProduct.BackColor = Color.FromArgb(30, 31, 68);
            btnFakturaTayy.BackColor = Color.FromArgb(30, 31, 68);
            btnFiliallar.BackColor = Color.FromArgb(30, 31, 68);
        }

        private void btnFiliallar_Click(object sender, EventArgs e)
        {
            openChildForm(new frmFaktura());
            lblDisplay.Text = btnFiliallar.Text;
            btnFiliallar.BackColor = Color.FromArgb(75, 158, 253);
            btnRecieve.BackColor = Color.FromArgb(30, 31, 68);
            btnHome.BackColor = Color.FromArgb(30, 31, 68);
            btnProduct.BackColor = Color.FromArgb(30, 31, 68);
            btnFakturaTayy.BackColor = Color.FromArgb(30, 31, 68);
        }

        private void btnFakturaTayy_Click(object sender, EventArgs e)
        {
            openChildForm(new frmFakturaTayyorlash());
            lblDisplay.Text = btnFakturaTayy.Text;
            btnFakturaTayy.BackColor = Color.FromArgb(75, 158, 253);
            btnFiliallar.BackColor = Color.FromArgb(30, 31, 68);
            btnRecieve.BackColor = Color.FromArgb(30, 31, 68);
            btnHome.BackColor = Color.FromArgb(30, 31, 68);
            btnProduct.BackColor = Color.FromArgb(30, 31, 68);
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
        public async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                lblRetry.Visible = false;
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
                lblStatus.Visible = true;
                waitForm.Show(this);
                string productContent = await GetObject();
                waitForm.Close();
                this.Focus();
                lblStatus.Visible = false;
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
                        rowProduct["Улчов"] = productItem["measurement"];
                        rowProduct["Штрих_код"] = productItem["barcode"];
                        rowProduct["Гурух"] = productItem["group"];
                        tbProduct.Rows.Add(rowProduct);
                    }
                }
                managerProduct = (CurrencyManager)BindingContext[tbProduct];
                //tbProduct.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try { waitForm.Close(); } catch (Exception) { }
                lblRetry.Visible = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);

        }
        public int esc = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                esc++;
                if (esc == 2)
                {
                    Application.Exit();
                }
            }
            if (btnFakturaTayy.BackColor == Color.FromArgb(75, 158, 253))
            {
                frmFakturaTayyorlash fakturaTayyorlash = new frmFakturaTayyorlash();
                if (e.KeyCode == Keys.F2)
                {
                    fakturaTayyorlash.btnSave_Click(sender, e);
                }
                if (e.KeyCode == Keys.F1)
                {
                    fakturaTayyorlash.btnSend_Click(sender, e);
                }
            }
        }

        static async Task<string> PutURI(Uri u, HttpContent c)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "token 28aeccd6cbbb18b16fddf2967d0b35242ad6a0a3");
                try
                {
                    HttpResponseMessage result = await client.PutAsync(u, c);
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(btnFakturaTayy.BackColor == Color.FromArgb(75, 158, 253))
            {
                frmFakturaTayyorlash fakturaTayyorlash = new frmFakturaTayyorlash();
                fakturaTayyorlash.txtSearch.Focus();
            }
        }
    }
}
