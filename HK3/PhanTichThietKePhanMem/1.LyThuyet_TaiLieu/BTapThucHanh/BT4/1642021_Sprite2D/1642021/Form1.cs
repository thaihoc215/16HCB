using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1642021
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
            //this.BackColor = Color.Magenta;
            //this.TransparencyKey = Color.Magenta;
            this.KeyDown += FrmSprite_KeyDown;
            this.KeyUp += FrmSprite_KeyUp;
            this.Load += FrmSprite_Load;
            picMain.MouseDown += PicMain_MouseDown;
            picMain.MouseMove += PicMain_MouseMove;

            popupMenu = new ContextMenuStrip();
            popupMenu.Items.Add("+ : Up speed", null, ItemUpspeedClick);
            popupMenu.Items.Add("- : Down speed", null, ItemDownSpeedClick);
            popupMenu.Items.Add("[ : Zoom out", null, ItemZoomoutClick);
            popupMenu.Items.Add("] : Zoom in", null, ItemZoominClick);
            popupMenu.Items.Add("S : Pause", null, ItemPauseClick);
            popupMenu.Items.Add("P : Continue", null, ItemContinueClick);
            popupMenu.Items.Add("B : Edit Sprite", null, ItemChangeSpriteClick);
            popupMenu.Items.Add("ESC - Close", null, ItemCloseClick );
        }

        private void FrmSprite_Load(object sender, EventArgs e)
        {
            timeMove.Start();
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
                    _moveDistance++;
                    break;
                case (int)Keys.OemMinus:
                case (int)Keys.Subtract:
                    if (_moveDistance > 0)
                        _moveDistance--;
                    break;
                case (int)Keys.OemOpenBrackets:
                    picMain.Size = new Size(picMain.Width - 10, picMain.Height - 10);
                    break;
                case (int)Keys.OemCloseBrackets:
                    picMain.Size = new Size(picMain.Width + 10, picMain.Height + 10);
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

        private void timeMove_Tick(object sender, EventArgs e)
        {
            if (_isPause)
                return;
            if (_moveRight)
                picMain.Location = new Point(picMain.Left + _moveDistance, picMain.Top);
            if (_moveLeft)
                picMain.Location = new Point(picMain.Left - _moveDistance, picMain.Top);
            if (_moveUp)
                picMain.Location = new Point(picMain.Left, picMain.Top - _moveDistance);
            if (_moveDown)
                picMain.Location = new Point(picMain.Left, picMain.Top + _moveDistance);
            
        }

        private void PicMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseLocation = e.Location;
            }
            if(e.Button == MouseButtons.Right)
            {
                popupMenu.Show(Cursor.Position);
            }
        }

        private void PicMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                picMain.Left = e.X + picMain.Left - mouseLocation.X;
                picMain.Top = e.Y + picMain.Top - mouseLocation.Y;
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
            picMain.Size = new Size(picMain.Width - 10, picMain.Height - 10);
        }

        private void ItemZoominClick(object sender, EventArgs e)
        {
            picMain.Size = new Size(picMain.Width + 10, picMain.Height + 10);
        }

        private void ItemDownSpeedClick(object sender, EventArgs e)
        {
            if (_moveDistance > 0)
                _moveDistance -= 1;
        }

        private void ItemUpspeedClick(object sender, EventArgs e)
        {
            _moveDistance += 1;
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
    }
}
