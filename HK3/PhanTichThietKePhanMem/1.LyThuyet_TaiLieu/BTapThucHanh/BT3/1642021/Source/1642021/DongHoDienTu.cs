using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace _1642021
{
    public partial class DongHoDienTu : UserControl
    {
        private static string PATH_LOCAL = Directory.GetParent(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).Parent.FullName;
        private int _miliSecond = 0;
        public int MiliSecond { get { return _miliSecond; } }
        private string _msc1 = "";
        private string _msc2 = "";

        private int _second = 0;
        public int Second { get { return _second; } }
        private string _sc1 = "";
        private string _sc2 = "";

        private int _minute = 0;
        public int Minute { get { return _minute; } }
        private string _mn1 = "";
        private string _mn2 = "";

        private int _countDownValue;
        public delegate void MyEventHandler();
        public event MyEventHandler CheckStopClock;

        private bool _isCountDown = false;
        public DongHoDienTu()
        {
            InitializeComponent();
        }

        private void DongHoDienTu_Load(object sender, EventArgs e)
        {
            tmClock.Interval = 1;
        }


        private Stopwatch stopWatch = new Stopwatch();
        private void tmClock_Tick(object sender, EventArgs e)
        {
            TimeSpan elapse = stopWatch.Elapsed;
            if (_isCountDown)
            {
                //get real time
                _miliSecond = 999 - elapse.Milliseconds;
                _countDownValue--;
                _msc1 = (_miliSecond / 100 % 10).ToString();
                _msc2 = (_miliSecond % 10).ToString();
                picMili1.Image = Image.FromFile(PATH_LOCAL + @"\Digits\" + _msc1 + ".png");
                picMili2.Image = Image.FromFile(PATH_LOCAL + @"\Digits\" + _msc2 + ".png");

                _second = _countDownValue / 60 % 60;
                _sc1 = (_second / 10).ToString();
                _sc2 = (_second % 10).ToString();
                ptSecond1.Image = Image.FromFile(PATH_LOCAL + @"\Digits\" + _sc1 + ".png");
                ptSecond2.Image = Image.FromFile(PATH_LOCAL + @"\Digits\" + _sc2 + ".png");
                _minute = _countDownValue / 3600;
                _mn1 = (_minute / 10).ToString();
                _mn2 = (_minute % 10).ToString();
                ptMinute1.Image = Image.FromFile(PATH_LOCAL + @"\Digits\" + _mn1 + ".png");
                ptMinute2.Image = Image.FromFile(PATH_LOCAL + @"\Digits\" + _mn2 + ".png");

                if (_countDownValue == 0)
                    CheckStopClock();
            }
            else
            {
                //get real time
                _miliSecond = elapse.Milliseconds;

                _msc1 = (_miliSecond / 100 % 10).ToString();
                _msc2 = (_miliSecond % 10).ToString();
                picMili1.Image = Image.FromFile(PATH_LOCAL + @"\Digits\" + _msc1 + ".png");
                picMili2.Image = Image.FromFile(PATH_LOCAL + @"\Digits\" + _msc2 + ".png");

                _second = elapse.Seconds;
                _sc1 = (_second / 10 % 10).ToString();
                _sc2 = (_second % 10).ToString();
                ptSecond1.Image = Image.FromFile(PATH_LOCAL + @"\Digits\" + _sc1 + ".png");
                ptSecond2.Image = Image.FromFile(PATH_LOCAL + @"\Digits\" + _sc2 + ".png");

                _minute = elapse.Minutes;
                _mn1 = (_minute / 10 % 10).ToString();
                _mn2 = (_minute % 10).ToString();

                ptMinute1.Image = Image.FromFile(PATH_LOCAL + @"\Digits\" + _mn1 + ".png");
                ptMinute2.Image = Image.FromFile(PATH_LOCAL + @"\Digits\" + _mn2 + ".png");
            }

            //if(_second == 60)
            //{
            //    ptSecond1.Image = Image.FromFile(PATH_LOCAL + @"\Digits\0.png");
            //    ptSecond2.Image = Image.FromFile(PATH_LOCAL + @"\Digits\0.png");
            //    ptMinute2.Image = Image.FromFile(PATH_LOCAL + @"\Digits\1.png");
            //    CheckStopClock(_second);
            //}


        }

        internal void StopCountDown()
        {
            tmClock.Stop();
            stopWatch.Stop();
            MessageBox.Show("Count down stop at: " + _minute + ":" + _second + ":" + _miliSecond);
        }

        public void CountDown(DateTimePicker dtpCoundount)
        {
            _isCountDown = true;
            _miliSecond = dtpCoundount.Value.Millisecond;
            _msc1 = (_miliSecond / 100 % 10).ToString();
            _msc2 = (_miliSecond % 10).ToString();
            picMili1.Image = Image.FromFile(PATH_LOCAL + @"\Digits\" + _msc1 + ".png");
            picMili2.Image = Image.FromFile(PATH_LOCAL + @"\Digits\" + _msc2 + ".png");

            _second = dtpCoundount.Value.Second;
            _sc1 = (_second / 10 % 10).ToString();
            _sc2 = (_second % 10).ToString();
            ptSecond1.Image = Image.FromFile(PATH_LOCAL + @"\Digits\" + _sc1 + ".png");
            ptSecond2.Image = Image.FromFile(PATH_LOCAL + @"\Digits\" + _sc2 + ".png");

            _minute = dtpCoundount.Value.Minute;
            _mn1 = (_minute / 10 % 10).ToString();
            _mn2 = (_minute % 10).ToString();

            ptMinute1.Image = Image.FromFile(PATH_LOCAL + @"\Digits\" + _mn1 + ".png");
            ptMinute2.Image = Image.FromFile(PATH_LOCAL + @"\Digits\" + _mn2 + ".png");
            _countDownValue = _minute * 3600 + _second * 60;
            stopWatch.Restart();
            tmClock.Start();
        }

        public void StartTime(ListBox lstTime)
        {
            _second = 0;
            _isCountDown = false;
            picMili1.Image = Image.FromFile(PATH_LOCAL + @"\Digits\0.png");
            picMili2.Image = Image.FromFile(PATH_LOCAL + @"\Digits\0.png");
            ptSecond1.Image = Image.FromFile(PATH_LOCAL + @"\Digits\0.png");
            ptSecond2.Image = Image.FromFile(PATH_LOCAL + @"\Digits\0.png");
            ptMinute1.Image = Image.FromFile(PATH_LOCAL + @"\Digits\0.png");
            ptMinute2.Image = Image.FromFile(PATH_LOCAL + @"\Digits\0.png");
            tmClock.Enabled = true;
            tmClock.Start();
            stopWatch.Restart();
            lstTime.Items.Clear();
        }

        public void StopTime()
        {
            tmClock.Stop();
            stopWatch.Stop();
        }

        public void Pause(ListBox lstTime)
        {
            tmClock.Stop();
            stopWatch.Stop();
            lstTime.Items.Add(_mn1 + _mn2 + ":" + _sc1 + _sc2 + ":" + _msc1 + _msc2);
        }

        public void Resume()
        {
            tmClock.Start();
            stopWatch.Start();
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
