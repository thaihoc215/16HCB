using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaiTap3_Phap_Viet
{
    public partial class Form1 : Form
    {
        PhapAnhServiceProxy.PhapAnhService prxPA = new PhapAnhServiceProxy.PhapAnhService();
        AnhVietServiceProxy.AnhVietService prxAV = new AnhVietServiceProxy.AnhVietService();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            prxAV.InitDictionary();
            prxPA.InitDictionary();
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            string viW = string.Empty;
            string enW = string.Empty;
            if ((enW = prxPA.Translate(txtFr.Text)).Equals(string.Empty)){
                MessageBox.Show("Can not find this word", "Error", MessageBoxButtons.OK);
            }
            else
            {
                if ((viW = prxAV.Translate(enW)).Equals(string.Empty))
                {
                    MessageBox.Show("Can not find this word", "Error", MessageBoxButtons.OK);
                }
                else
                    txtVi.Text = viW;
            }
                

        }
    }
}
