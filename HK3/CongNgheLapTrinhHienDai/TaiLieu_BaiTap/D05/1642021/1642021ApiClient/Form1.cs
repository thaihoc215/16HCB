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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HttpClient client = new HttpClient();

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
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:3000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            object content = new
            {
                mathe = 1,
                matkhau = 123,
                nganhang = 1
            };

            //var response = client.GetAsync("/taikhoan").Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    var list = response.Content.ReadAsAsync<Object>().Result;
            //    //Console.WriteLine(list.Length);
            //}


            string myContent = JsonConvert.SerializeObject(content);
            var response = client.PostAsync("/taikhoan", new StringContent(myContent, Encoding.UTF8, "application/json")).Result;

            if (response.IsSuccessStatusCode)
            {

                var nd = response.Content.ReadAsAsync<TaiKhoanModel>().Result;
                //var lst = JsonConvert.DeserializeObject<TaiKhoanModel[]>(list.ToString());
                //Console.WriteLine(list.Length);
            }
        }
    }
}
