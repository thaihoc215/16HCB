using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaiTap2_Anh_Viet
{
    public partial class Form1 : Form
    {
        AnhVietServiceProxy.AnhVietService prx = new AnhVietServiceProxy.AnhVietService();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            string viW = string.Empty;
            if ((viW = prx.Translate(txtEng.Text)).Equals(string.Empty))
                MessageBox.Show("Can not find this word", "Error", MessageBoxButtons.OK);
            else
                txtVi.Text = viW;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            prx = new AnhVietServiceProxy.AnhVietService();
            prx.InitDictionary();
        }

        private void txtVi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEng_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
