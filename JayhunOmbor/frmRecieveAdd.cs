using Newtonsoft.Json.Linq;
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

namespace JayhunOmbor
{
    public partial class frmRecieveAdd : MetroFramework.Forms.MetroForm
    {
        public frmRecieveAdd()
        {
            InitializeComponent();
        }
        public event System.Windows.Forms.KeyEventHandler KeyDown;
        public string recieve_id = "";
        public string product_id = "";
        public string som = "", dollar = "", kurs = "";
        public string name = "";
        public string faktura_id = "0", group="", barcode="";

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtSom.Focus();
                e.Handled = true;
            }
        }

        private void txtSom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSotishSom.Focus();
                e.Handled = true;
            }
        }

        private void txtSotishSom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDollar.Focus();
                e.Handled = true;
            }
        }

        private void txtDollar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSotishDollar.Focus();
                e.Handled = true;
            }
        }

        private void txtSotishDollar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtKurs.Focus();
                e.Handled = true;
            }
        }

        private void txtKurs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iconButton1.Focus();
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        WaitForm waitForm = new WaitForm();
        private async void iconButton1_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Введите количество!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            waitForm.Show(this);
            try
            {
                string som = "0", dollar = "0", kurs = "0";
                string product = product_id;
                string quantity = txtQuantity.Text;
                if (txtSom.Text != "0" || txtSom.Text != "") { som = txtSom.Text; }
                if (txtDollar.Text != "0" || txtDollar.Text != "") { dollar = txtDollar.Text; }
                if (txtKurs.Text != "0" || txtKurs.Text != "") { kurs = txtKurs.Text; }

                Uri u = new Uri("http://santexnika.backoffice.uz/api/recieveitem/add/");
                var payload = "{\"recieve\": \"" + recieve_id + "\",\"product\": \"" + product + "\",\"som\": \"" + som + "\",\"dollar\": \"" + dollar + "\",\"kurs\": \"" + kurs + "\",\"quantity\": \"" + quantity + "\"}";
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                var t = Task.Run(() => PostURI(u, content));
                t.Wait();
                if (t.Result != "Error" && t.Result.Length != 0)
                {
                    string Responce = t.Result;
                    JObject objectRecieve = JObject.Parse(Responce);
                    frmRecieveProduct.id = objectRecieve["id"].ToString();
                    frmRecieveProduct.som = objectRecieve["som"].ToString();
                    frmRecieveProduct.dollar = objectRecieve["dollar"].ToString();
                    frmRecieveProduct.kurs = objectRecieve["kurs"].ToString();
                    frmRecieveProduct.quantity = objectRecieve["quantity"].ToString();
                    frmRecieveProduct.recieve = objectRecieve["recieve"].ToString();
                    frmRecieveProduct.product1 = objectRecieve["product"].ToString();
                    Form1.recieve = false;
                   

                    if (faktura_id != "0")
                    {
                        string sotishSom = "0", sotishDollar = "0", Pname = "";
                        if (txtSotishSom.Text != "0") { sotishSom = txtSotishSom.Text; }
                        if (txtSotishDollar.Text != "0") { sotishDollar = txtSotishDollar.Text; }
                        Pname = txtProduct.Text;

                        Uri ur = new Uri("http://santexnika.backoffice.uz/api/fakturaitem/add/");
                        var payloadr = "{\"name\": \"" + Pname + "\",\"faktura\": \"" + faktura_id + "\",\"product\": \"" + product + "\",\"som\": \"" + sotishSom + "\",\"dollar\": \"" + sotishDollar + "\",\"group\": \"" + group + "\",\"barcode\": \"" + barcode + "\",\"quantity\": \"" + txtQuantity.Text + "\",\"body_som\": \"" + som + "\",\"body_dollar\": \"" + dollar + "\"}";

                        HttpContent contentr = new StringContent(payloadr, Encoding.UTF8, "application/json");
                        var tr = Task.Run(() => PostURI(ur, contentr));
                        tr.Wait();
                        if (tr.Result != "Error!" && tr.Result.Length != 0)
                        {
                            waitForm.Close();
                            txtQuantity.Clear();
                            txtSom.Text = "0";
                            txtDollar.Text = "0";
                            txtKurs.Text = "0";
                        }
                        else
                        {
                            MessageBox.Show("Server bilan bo'glanishda xatolik", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                   
                    Close();
                }
                else
                {
                    MessageBox.Show("Ошибка при подключении к серверу, проверьте параметры сети", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmRecieveAdd_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            txtProduct.Text = name;
            txtSom.Text = som;
            txtDollar.Text = dollar;
            txtKurs.Text = kurs;
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
    }
}
