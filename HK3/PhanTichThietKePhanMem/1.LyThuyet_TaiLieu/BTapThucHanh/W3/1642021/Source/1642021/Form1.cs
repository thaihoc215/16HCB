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
            btnPause.Visible = false;
            btnResume.Visible = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnResume.Visible = false;
            btnPause.Visible = true;
            dongHoDienTu1.StartTime(lstListTime);
            dongHoDienTu1.CheckStopClock += DongHoDienTu1_CheckStopClock;
            lblStop.Text = "";
        }

        private void DongHoDienTu1_CheckStopClock()
        {
                dongHoDienTu1.SetEndSession(this);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnResume.Visible = false;
            btnPause.Visible = false;
            dongHoDienTu1.StopTime();
            lblStop.Text ="Time Stop: " + dongHoDienTu1.Minute.ToString("00")
                + ":" + dongHoDienTu1.Second.ToString("00") + ":" + dongHoDienTu1.MiliSecond.ToString("00");
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

        private void btnCountDown_Click(object sender, EventArgs e)
        {
            if(dateTimePicker1.Value.Minute <=0 &&dateTimePicker1.Value.Second <=0)
            {
                MessageBox.Show("Please set the count down time!!!");
                return;
            }
            dongHoDienTu1.CountDown(dateTimePicker1);
            dongHoDienTu1.CheckStopClock += DongHoDienTu1_CheckStopClock;
        }

        private void btnStopCount_Click(object sender, EventArgs e)
        {
            dongHoDienTu1.StopCountDown();
        }
    }
}
