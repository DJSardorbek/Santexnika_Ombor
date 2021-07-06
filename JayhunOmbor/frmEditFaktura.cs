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
    public partial class frmEditFaktura : MetroFramework.Forms.MetroForm
    {
        public frmEditFaktura()
        {
            InitializeComponent();
        }

        public string fakturaItem_id = "", product_id = "", name = "", som = "", dollar="", quantity = "", faktura_id = "";

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnEdit.Focus();
            }
        }

        private void txtDollar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtQuantity.Focus();
            }
        }

        private void txtSom_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtDollar.Focus();
            }
        }

        private void frmEditFaktura_Load(object sender, EventArgs e)
        {
            txtName.Text = name;
            txtSom.Text = som;
            txtDollar.Text = dollar;
            txtQuantity.Text = quantity;
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
            if(s.IndexOf(',') > -1)
            {
                int index = s.IndexOf(',');
                string first = s.Substring(0, index);
                string last = s.Substring(index + 1);
                s = first + "." + last;
            }
            return s;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Микдорни киритинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string som = txtSom.Text;
            som = DoubleToStr(som);
            string dollar = txtDollar.Text;
            dollar = DoubleToStr(dollar);
            string quantity = txtQuantity.Text;
            quantity = DoubleToStr(quantity);

            try
            {
                Uri u = new Uri("http://santexnika.backoffice.uz/api/fakturaitem/up/");
                var payload = "{\"item\": \"" + fakturaItem_id + "\",\"som\": \"" + som + "\",\"dollar\": \""+dollar+"\",\"quantity\": \"" + quantity + "\"}";
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                var t = Task.Run(() => PostURI(u, content));
                t.Wait();
                if (t.Result != "Error!" && t.Result.Length != 0)
                {
                    MessageBox.Show(t.Result.ToString());
                    MessageBox.Show("Махсулот муваффакиятли ўзгартирилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmFakturaTayyorlash.edit_som = som;
                    frmFakturaTayyorlash.edit_dollar = dollar;
                    frmFakturaTayyorlash.edit_quantity = quantity;
                    frmFakturaTayyorlash.edit = true;
                }
                else
                {
                    MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
