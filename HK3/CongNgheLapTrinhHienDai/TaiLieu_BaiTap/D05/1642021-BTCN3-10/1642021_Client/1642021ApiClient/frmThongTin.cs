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
    public partial class frmThongTin : Form
    {
        HttpClient client;
        TaiKhoanModel _chuTaiKhoan;

        public frmThongTin(TaiKhoanModel nd)
        {
            InitializeComponent();
            dgvGiaoDich.AutoGenerateColumns = false;
            _chuTaiKhoan = nd;
            lblMaThe.Text = _chuTaiKhoan.MaThe.ToString();
            lblTenChuThe.Text = _chuTaiKhoan.TenChuThe;
            lblNganHang.Text = _chuTaiKhoan.TenNganHang;
            lblSoDu.Text = string.Format("{0:n0}", _chuTaiKhoan.SoDuKhaDung);
            lblNgayHetHan.Text = _chuTaiKhoan.NgayHetHan.ToString("dd/MM/yyyy");

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

        private void btnRutTien_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận rút tiền", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            int sotienrut = 0;
            if (rdo1t.Checked)
                sotienrut = 1000000;
            else if (rdo2t.Checked)
                sotienrut = 2000000;
            else if (rdo5t.Checked)
                sotienrut = 5000000;
            else
                sotienrut = (int)nmrSoTien.Value;
            object content = new
            {
                mathe = _chuTaiKhoan.MaThe,
                matkhau = _chuTaiKhoan.MatKhau,
                manganhang = _chuTaiKhoan.MaNganHang,
                sotienrut = sotienrut
            };
            string myContent = JsonConvert.SerializeObject(content);
            var response = client.PostAsync("/giaodich/ruttien", new StringContent(myContent, Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                var nd = response.Content.ReadAsAsync<TaiKhoanModel>().Result;
                if (nd == null)
                {
                    MessageBox.Show("Rút tiền không thành công", "Lỗi");
                    return;
                }
                lblSauRutTien.Text = "Rút tiền thành công. Số dư tài khoản: " + string.Format("{0:n0}", nd.SoDuKhaDung);
                lblSoDu.Text = string.Format("{0:n0}", nd.SoDuKhaDung);
            }
            else
            {
                MessageBox.Show(response.Content.ReadAsAsync<String>().Result, "Lỗi");
            }
        }
        private void btnChuyenTien_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận chuyển tiền", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            int maTheNhan;
            if (!int.TryParse(txtMaNguoiNhan.Text, out maTheNhan))
            {
                MessageBox.Show("Mã người nhận phải là số.");
                return;
            }
            int nganHangNhan = int.Parse(((NganHangModel)cboNganHang.SelectedItem).MaNganHang.ToString());
            object content = new
            {
                maNguoiGui = _chuTaiKhoan.MaThe,
                nganHangGui = _chuTaiKhoan.MaNganHang,
                maNguoiNhan = maTheNhan,
                nganHangNhan = nganHangNhan,
                soTienGui = (int)nmrSoTienChuyen.Value
            };
            string myContent = JsonConvert.SerializeObject(content);
            var response = client.PostAsync("/giaodich/chuyentien", new StringContent(myContent, Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                var nd = response.Content.ReadAsAsync<TaiKhoanModel>().Result;
                if (nd == null)
                {
                    MessageBox.Show("chuyển tiền không thành công", "Lỗi");
                    return;
                }
                lblSauKhiChuyenTien.Text = "Chuyển tiền thành công. Số dư tài khoản: " + string.Format("{0:n0}", nd.SoDuKhaDung);
                lblSoDu.Text = string.Format("{0:n0}", nd.SoDuKhaDung);
            }
            else
            {
                MessageBox.Show(response.Content.ReadAsAsync<String>().Result, "Lỗi");
            }
        }
        private void rdoSoKhac_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSoKhac.Checked)
                nmrSoTien.Enabled = true;
            else
                nmrSoTien.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            var res = client.GetAsync("/giaodich/ngay?mathe=" + _chuTaiKhoan.MaThe +"&ngaybatdau=" + dtpFrom.Value.ToShortDateString()
                + "&ngayketthuc=" + dtpTo.Value.ToShortDateString()).Result;
            if (res.IsSuccessStatusCode)
            {
                GiaoDichModel[] lstGiaoDich = res.Content.ReadAsAsync<GiaoDichModel[]>().Result;
                dgvGiaoDich.DataSource = lstGiaoDich;
            }
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            var res = client.GetAsync("/giaodich?mathe=" + _chuTaiKhoan.MaThe).Result;
            if (res.IsSuccessStatusCode)
            {
                GiaoDichModel[] lstGiaoDich = res.Content.ReadAsAsync<GiaoDichModel[]>().Result;
                dgvGiaoDich.DataSource = lstGiaoDich;
            }
        }
    }
}
