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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvDshs.AutoGenerateColumns = false;
            dgvDshs.DataSource = DBUtils.QLHSDB.LayDSHocSinh();
            ActiveControl = txtTimHS;

        }
        private void btnThemHS_Click(object sender, EventArgs e)
        {
            frmThemHS frmThem = new frmThemHS();
            if (frmThem.ShowDialog() == DialogResult.No)
                return;
            dgvDshs.DataSource = DBUtils.QLHSDB.LayDSHocSinh();
        }

        private void btnXoaHS_Click(object sender, EventArgs e)
        {

            if (dgvDshs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn học sinh", "Lỗi", MessageBoxButtons.OK);
            }
            int maHs = int.Parse(dgvDshs.SelectedRows[0].Cells[0].Value.ToString());
            if (DBUtils.QLHSDB.XoaHocSinh(maHs))
            {
                MessageBox.Show("Xóa học sinh thành công", "Thành Công", MessageBoxButtons.OK);
                dgvDshs.DataSource = DBUtils.QLHSDB.LayDSHocSinh();
                return;
            }
            MessageBox.Show("Xóa học sinh không thành công", "Lỗi", MessageBoxButtons.OK);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTimHS_Click(object sender, EventArgs e)
        {
            dgvDshs.DataSource = null;
            DataTable dt = DBUtils.QLHSDB.TimHocSinh(txtTimHS.Text);
            if (dt == null || dt.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy học sinh", "Lỗi", MessageBoxButtons.OK);
            dgvDshs.DataSource = dt;
            txtTimHS.Focus();
        }
    }
}
