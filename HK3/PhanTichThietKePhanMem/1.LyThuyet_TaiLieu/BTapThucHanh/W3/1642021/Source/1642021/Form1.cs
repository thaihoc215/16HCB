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

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnResume.Visible = false;
            dongHoDienTu1.StartTime(lstListTime);
            dongHoDienTu1.CheckStopClock += DongHoDienTu1_CheckStopClock;
            lblStop.Text = "";
        }

        private void DongHoDienTu1_CheckStopClock(int time)
        {
                dongHoDienTu1.SetEndSession(this);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnResume.Visible = false;
            btnPause.Visible = false;
            dongHoDienTu1.StopTime();
            lblStop.Text ="Time Stop: " + "00" + ":" + dongHoDienTu1.Second.ToString("00");
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            btnResume.Visible = true;
            btnPause.Visible = false;
            dongHoDienTu1.Pause(lstListTime);
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            btnPause.Visible = true;
            btnResume.Visible = false;
            dongHoDienTu1.Resume();
        }
    }
}
