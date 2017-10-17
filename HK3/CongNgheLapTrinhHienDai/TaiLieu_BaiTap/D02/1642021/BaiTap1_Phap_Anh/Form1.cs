using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaiTap1_Phap_Anh
{
    public partial class Form1 : Form
    {
        PhapAnhServiceProxy.PhapAnhService prx;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            prx = new PhapAnhServiceProxy.PhapAnhService();
            prx.InitDictionary();
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            string enW = string.Empty;
            if ((enW = prx.Translate(txtFr.Text)).Equals(string.Empty))
                MessageBox.Show("Can not find this word", "Error", MessageBoxButtons.OK);
            else
                txtEn.Text = enW;
        }
    }
}
