using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1642021
{
    public partial class DongHoDienTu : UserControl
    {
        private int _second = 0;
        public int Second { get { return _second; }}
        private string _sc1 = "";
        private string _sc2 = "";
        public delegate void MyEventHandler(int msg);
        public event MyEventHandler CheckStopClock;
        public DongHoDienTu()
        {
            InitializeComponent();
        }

        private void DongHoDienTu_Load(object sender, EventArgs e)
        {
            //ptSecond1.Image = Image.FromFile(@"..\..\Digits\0.png");
            //ptSecond2.Image = Image.FromFile(@"..\..\Digits\0.png");
            //ptDigitSep.Image = Image.FromFile(@"..\..\Digits\-.png");
            //ptMinute1.Image = Image.FromFile(@"..\..\Digits\0.png");
            //ptMinute2.Image = Image.FromFile(@"..\..\Digits\0.png");
        }

        

        private void tmClock_Tick(object sender, EventArgs e)
        {
            //get real time
            tmClock.Interval = 1000;
            _second++;
            _sc1 = (_second / 10 % 10).ToString();
            _sc2 = (_second % 10).ToString();
            ptSecond1.Image = Image.FromFile(@"..\..\Digits\" + _sc1 + ".png");
            ptSecond2.Image = Image.FromFile(@"..\..\Digits\" + _sc2 + ".png");
            if(_second == 60)
            {
                ptSecond1.Image = Image.FromFile(@"..\..\Digits\0.png");
                ptSecond2.Image = Image.FromFile(@"..\..\Digits\0.png");
                ptMinute2.Image = Image.FromFile(@"..\..\Digits\1.png");
                CheckStopClock(_second);
            }

            
        }

        public void StartTime(ListBox lstTime)
        {
            _second = 0;
            ptSecond1.Image = Image.FromFile(@"..\..\Digits\0.png");
            ptSecond2.Image = Image.FromFile(@"..\..\Digits\0.png");
            ptMinute1.Image = Image.FromFile(@"..\..\Digits\0.png");
            ptMinute2.Image = Image.FromFile(@"..\..\Digits\0.png");
            tmClock.Enabled = true;
            tmClock.Start();
            lstTime.Items.Clear();
        }

        public void StopTime()
        {
            tmClock.Stop();
        }

        public void Pause(ListBox lstTime)
        {
            tmClock.Stop();
            lstTime.Items.Add("00:" + _sc1 + _sc2);
        }

        public void Resume()
        {
            if (_second != 0)
                tmClock.Start();
        }
        //public delegate bool CheckTime(string time1, string time2);
        //public bool checkTime(string time1,string time2)
        //{
        //    return String.Compare(time1, time2) > 0;
        //}

        internal void SetEndSession(Form1 form1)
        {
            tmClock.Stop();
            MessageBox.Show("End of time! Application close!");
            form1.Close();
        }
    }
}
