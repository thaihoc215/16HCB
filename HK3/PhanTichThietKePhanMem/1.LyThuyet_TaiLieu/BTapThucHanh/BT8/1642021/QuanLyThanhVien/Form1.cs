using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThanhVien
{
    
    public partial class Form1 : Form
    {
        bool _isThem = true;
        public Form1()
        {
            InitializeComponent();
            gridThanhVien.DataSource = ThanhVienBUS.LayDanhSach();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTen.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            ToggleControl(true);
            _isThem = true;
        }

        //cap nhat
        private void button2_Click(object sender, EventArgs e)
        {
            ToggleControl(true);
            _isThem = false;
        }

        //xoa
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa thành viên", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            ThanhVienBUS.DeleteThanhVien((int)gridThanhVien.SelectedRows[0].Cells[0].Value);
            gridThanhVien.DataSource = ThanhVienBUS.LayDanhSach();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (gridThanhVien.SelectedRows.Count <= 0)
                return;
            txtMa.Text = gridThanhVien.SelectedRows[0].Cells[0].Value.ToString();
            txtTen.Text = gridThanhVien.SelectedRows[0].Cells[1].Value.ToString();
            dtpNgaySinh.Value = DateTime.Parse(gridThanhVien.SelectedRows[0].Cells[2].Value.ToString());
            txtSDT.Text = gridThanhVien.SelectedRows[0].Cells[3].Value.ToString();
            txtEmail.Text = gridThanhVien.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btnXemDS_Click(object sender, EventArgs e)
        {
            gridThanhVien.DataSource = ThanhVienBUS.LayDanhSach();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ThanhVienDTO tv = new ThanhVienDTO();
            tv.MaTV = string.IsNullOrEmpty(txtMa.Text)? 0: int.Parse(txtMa.Text);
            tv.TenTV = txtTen.Text;
            tv.NgaySinh = dtpNgaySinh.Value;
            tv.SDT = txtSDT.Text;
            tv.Email = txtEmail.Text;
            if (_isThem)
            {
                if (ThanhVienBUS.AddThanhVien(tv))
                    MessageBox.Show("Them thanh vien thanh cong");
                else
                    MessageBox.Show("Them thanh vien that bai");
            }
            else
            {
                if (ThanhVienBUS.UpdateThanhVien(tv))
                    MessageBox.Show("Them thanh vien thanh cong");
                else
                    MessageBox.Show("Them thanh vien that bai");
            }
            ToggleControl(false);
            gridThanhVien.DataSource = ThanhVienBUS.LayDanhSach();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ToggleControl(false);
        }

        void ToggleControl(bool isEnable)
        {
            txtTen.Enabled = isEnable;
            txtSDT.Enabled = isEnable;
            txtEmail.Enabled = isEnable;
            dtpNgaySinh.Enabled = isEnable;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
