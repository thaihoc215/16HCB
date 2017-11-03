using _1642021ApiClient.Model;
using Newtonsoft.Json;
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

namespace _1642021ApiClient
{
    public partial class frmDangNhap : Form
    {
        HttpClient client;
        public frmDangNhap()
        {
            InitializeComponent();
            client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:3000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var res = client.GetAsync("/nganhang").Result;
            if (res.IsSuccessStatusCode)
            {
                NganHangModel[] lstNganHang = res.Content.ReadAsAsync<NganHangModel[]>().Result;
                cboNganHang.ValueMember = "MaNganHang";
                cboNganHang.DisplayMember = "TenNganHang";
                cboNganHang.Items.AddRange(lstNganHang);
                cboNganHang.SelectedIndex = 0;

            }
        }

        private void bntXemThongTin_Click(object sender, EventArgs e)
        {


            int maThe;
            if (!int.TryParse(txtMaThe.Text, out maThe))
            {
                MessageBox.Show("Mã thẻ phải là số.");
                return;
            }
            int maNganHang = int.Parse(((NganHangModel)cboNganHang.SelectedItem).MaNganHang.ToString());
            object content = new
            {
                mathe = maThe,
                matkhau = txtMatKhau.Text,
                nganhang = maNganHang
            };

            //var response = client.GetAsync("/taikhoan").Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    var list = response.Content.ReadAsAsync<Object>().Result;
            //    //Console.WriteLine(list.Length);
            //}
            string myContent = JsonConvert.SerializeObject(content);
            var response = client.PostAsync("/taikhoan", new StringContent(myContent, Encoding.UTF8, "application/json")).Result;
            TaiKhoanModel nd;
            if (response.IsSuccessStatusCode)
            {
                nd = response.Content.ReadAsAsync<TaiKhoanModel>().Result;
                if (nd == null)
                {
                    MessageBox.Show("Mã thẻ hoặc mật khẩu không đúng", "Lỗi");
                    return;
                }
                this.Hide();
                frmThongTin frm = new frmThongTin(nd);
                frm.Closed += (s, args) => this.Close();
                frm.Show();
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
