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

        public string fakturaItem_id = "", product_id = "", name = "", price = "", quantity = "", faktura_id = "";

        private void frmEditFaktura_Load(object sender, EventArgs e)
        {
            txtName.Text = name;
            txtSom.Text = price;
            txtQuantity.Text = quantity;
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Микдорни киритинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string price = txtSom.Text;
            string quantity = txtQuantity.Text;
            try
            {
                Uri u = new Uri("http://santexnika.backoffice.uz/api/fakturaitem/up/");
                var payload = "{\"faktura\": \""+faktura_id+"\",\"item\": \"" + fakturaItem_id + "\",\"price\": \"" + price + "\",\"quantity\": \"" + quantity + "\"}";
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                var t = Task.Run(() => PostURI(u, content));
                t.Wait();
                if (t.Result != "Error!" && t.Result.Length != 0)
                {
                    MessageBox.Show("Махсулот муваффакиятли ўзгартирилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmFakturaTayyorlash.edit_price = price;
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
                MessageBox.Show(ex.Message);
            }
        }
    }
}
