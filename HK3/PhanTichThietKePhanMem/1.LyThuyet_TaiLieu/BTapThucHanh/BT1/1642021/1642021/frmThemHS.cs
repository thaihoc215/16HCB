using _1642021.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1642021
{
    public partial class frmThemHS : Form
    {
        public frmThemHS()
        {
            InitializeComponent();
            ActiveControl = txtHoTen;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if("".Equals(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên học sinh", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            HocSinhModel hs = new HocSinhModel();
            hs.TenHS = txtHoTen.Text;
            hs.NgaySinh = dtpNgaySinh.Value;
            hs.SDT = txtSDT.Text;
            hs.DiaChi = txtDiaChi.Text;
            if (DBUtils.QLHSDB.ThemHocSinh(hs))
            {
                MessageBox.Show("Thêm học sinh thành công", "Thành Công", MessageBoxButtons.OK);
                DialogResult = DialogResult.Yes;
                return;
            }
            MessageBox.Show("Thêm học sinh không thành công", "Lỗi", MessageBoxButtons.OK);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
