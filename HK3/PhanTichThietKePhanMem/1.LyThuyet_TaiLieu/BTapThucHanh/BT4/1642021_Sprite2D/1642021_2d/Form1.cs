using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1642021_2d
{
    public partial class frmSprite : Form
    {
        bool _moveUp = false;
        bool _moveDown = false;
        bool _moveLeft = false;
        bool _moveRight = false;
        bool _isPause = false;
        int _moveDistance = 5;
        Point mouseLocation;
        ContextMenuStrip popupMenu;
        public frmSprite()
        {
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            this.KeyDown += FrmSprite_KeyDown;
            this.KeyUp += FrmSprite_KeyUp;
            this.Load += FrmSprite_Load;
            //picMain.MouseDown += PicMain_MouseDown;
            //picMain.MouseMove += PicMain_MouseMove;
            this.MouseDown += FrmSprite_MouseDown;
            this.MouseMove += FrmSprite_MouseMove;

            popupMenu = new ContextMenuStrip();
            popupMenu.Items.Add("+ : Up speed", null, ItemUpspeedClick);
            popupMenu.Items.Add("- : Down speed", null, ItemDownSpeedClick);
            popupMenu.Items.Add("[ : Zoom out", null, ItemZoomoutClick);
            popupMenu.Items.Add("] : Zoom in", null, ItemZoominClick);
            popupMenu.Items.Add("S : Pause", null, ItemPauseClick);
            popupMenu.Items.Add("P : Continue", null, ItemContinueClick);
            popupMenu.Items.Add("B : Edit Sprite", null, ItemChangeSpriteClick);
            popupMenu.Items.Add("ESC - Close", null, ItemCloseClick);
        }
        private void FrmSprite_Load(object sender, EventArgs e)
        {
            timeMove.Start();
            timeMove.Interval = 10;
            timeChange.Start();
            timeChange.Interval = 100;
        }

        private void FrmSprite_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (int)Keys.Right:
                    _moveRight = true;
                    break;
                case (int)Keys.Left:
                    _moveLeft = true;
                    break;
                case (int)Keys.Up:
                    _moveUp = true;
                    break;
                case (int)Keys.Down:
                    _moveDown = true;
                    break;
                case (int)Keys.S:
                    _isPause = true;
                    break;
                case (int)Keys.P:
                    _isPause = false;
                    break;
                case (int)Keys.Oemplus:
                case (int)Keys.Add:
                    _moveDistance += 1;
                    if (timeChange.Interval > 5)
                        timeChange.Interval -= 5;
                    break;
                case (int)Keys.OemMinus:
                case (int)Keys.Subtract:
                    if (_moveDistance > 0)
                        _moveDistance -= 1;
                    timeChange.Interval += 5;
                    break;
                case (int)Keys.OemOpenBrackets:
                    this.Size = new Size(this.Width - 10, this.Height - 10);
                    //picMain.Size = new Size(picMain.Width - 10, picMain.Height - 10);
                    break;
                case (int)Keys.OemCloseBrackets:
                    this.Size = new Size(this.Width + 10, this.Height + 10);
                    //picMain.Size = new Size(picMain.Width + 10, picMain.Height + 10);
                    break;
                case (int)Keys.B:
                    using (var fbd = new OpenFileDialog())
                    {
                        CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                        dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                        dialog.IsFolderPicker = true;
                        if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                        {
                            MessageBox.Show("You selected: " + dialog.FileName);
                        }
                    }
                    break;
                case (int)Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void FrmSprite_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (int)Keys.Right:
                    _moveRight = false;
                    break;
                case (int)Keys.Left:
                    _moveLeft = false;
                    break;
                case (int)Keys.Up:
                    _moveUp = false;
                    break;
                case (int)Keys.Down:
                    _moveDown = false;
                    break;
            }
        }
        int _attack = 1;
        int _walk = 1;
        int _dead = 1;
        int _ide = 1;
       

        private void FrmSprite_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left = e.X + this.Left - mouseLocation.X;
                this.Top = e.Y + this.Top - mouseLocation.Y;
            }
        }

        private void FrmSprite_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseLocation = e.Location;
            }
            if (e.Button == MouseButtons.Right)
            {
                popupMenu.Show(Cursor.Position);
            }
        }

        private void ItemContinueClick(object sender, EventArgs e)
        {
            _isPause = false;
        }

        private void ItemPauseClick(object sender, EventArgs e)
        {
            _isPause = true;
        }

        private void ItemZoomoutClick(object sender, EventArgs e)
        {
            this.Size = new Size(this.Width - 10, this.Height - 10);
            //picMain.Size = new Size(picMain.Width - 10, picMain.Height - 10);
        }

        private void ItemZoominClick(object sender, EventArgs e)
        {
            this.Size = new Size(this.Width + 10, this.Height + 10);
            //picMain.Size = new Size(picMain.Width + 10, picMain.Height + 10);
        }

        private void ItemDownSpeedClick(object sender, EventArgs e)
        {
            if (_moveDistance > 0)
                _moveDistance -= 1;
            timeChange.Interval += 5;
        }

        private void ItemUpspeedClick(object sender, EventArgs e)
        {
            _moveDistance += 1;
            if (timeChange.Interval > 5)
                timeChange.Interval -= 5;
        }

        private void ItemChangeSpriteClick(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                MessageBox.Show("You selected: " + dialog.FileName);
            }
        }

        private void ItemCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PicMain_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    picMain.Left = e.X + picMain.Left - mouseLocation.X;
            //    picMain.Top = e.Y + picMain.Top - mouseLocation.Y;
            //}
        }
        private void PicMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseLocation = e.Location;
            }
            if (e.Button == MouseButtons.Right)
            {
                popupMenu.Show(Cursor.Position);
            }
        }

        private void timeMove_Tick_1(object sender, EventArgs e)
        {
            if (_isPause)
                return;
            if (_moveRight)
                this.Location = new Point(this.Left + _moveDistance, this.Top);
            //picMain.Location = new Point(picMain.Left + _moveDistance, picMain.Top);
            if (_moveLeft)
                this.Location = new Point(this.Left - _moveDistance, this.Top);
            //picMain.Location = new Point(picMain.Left - _moveDistance, picMain.Top);
            if (_moveUp)
                this.Location = new Point(this.Left, this.Top - _moveDistance);
            //picMain.Location = new Point(picMain.Left, picMain.Top - _moveDistance);
            if (_moveDown)
                this.Location = new Point(this.Left, this.Top + _moveDistance);
            //picMain.Location = new Point(picMain.Left, picMain.Top + _moveDistance);
        }

        private void timeChange_Tick_1(object sender, EventArgs e)
        {
            if (_isPause)
                return;
            if (_ide < 16)
                this.BackgroundImage = Image.FromFile(@"..\..\Resources\male\" + "Idle (" + _ide++ + ")" + ".png");
            else if (_walk < 11)
                this.BackgroundImage = Image.FromFile(@"..\..\Resources\male\" + "Walk (" + _walk++ + ")" + ".png");
            else if (_attack < 9)
                this.BackgroundImage = Image.FromFile(@"..\..\Resources\male\" + "Attack (" + _attack++ + ")" + ".png");
            else if (_dead < 13)
                this.BackgroundImage = Image.FromFile(@"..\..\Resources\male\" + "Dead (" + _dead++ + ")" + ".png");
            else
            {
                _ide = 1;
                _walk = 1;
                _attack = 1;
                _dead = 1;
            }
        }
    }
}
