namespace _1642021
{
    partial class DongHoDienTu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DongHoDienTu));
            this.tmClock = new System.Windows.Forms.Timer(this.components);
            this.ptDigitSep = new System.Windows.Forms.PictureBox();
            this.ptMinute2 = new System.Windows.Forms.PictureBox();
            this.ptMinute1 = new System.Windows.Forms.PictureBox();
            this.ptSecond1 = new System.Windows.Forms.PictureBox();
            this.ptSecond2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptDigitSep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptMinute2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptMinute1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptSecond1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptSecond2)).BeginInit();
            this.SuspendLayout();
            // 
            // tmClock
            // 
            this.tmClock.Tick += new System.EventHandler(this.tmClock_Tick);
            // 
            // ptDigitSep
            // 
            this.ptDigitSep.Image = ((System.Drawing.Image)(resources.GetObject("ptDigitSep.Image")));
            this.ptDigitSep.Location = new System.Drawing.Point(164, 50);
            this.ptDigitSep.Name = "ptDigitSep";
            this.ptDigitSep.Size = new System.Drawing.Size(40, 59);
            this.ptDigitSep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptDigitSep.TabIndex = 0;
            this.ptDigitSep.TabStop = false;
            // 
            // ptMinute2
            // 
            this.ptMinute2.Image = ((System.Drawing.Image)(resources.GetObject("ptMinute2.Image")));
            this.ptMinute2.Location = new System.Drawing.Point(118, 50);
            this.ptMinute2.Name = "ptMinute2";
            this.ptMinute2.Size = new System.Drawing.Size(40, 59);
            this.ptMinute2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptMinute2.TabIndex = 1;
            this.ptMinute2.TabStop = false;
            // 
            // ptMinute1
            // 
            this.ptMinute1.Image = ((System.Drawing.Image)(resources.GetObject("ptMinute1.Image")));
            this.ptMinute1.ImageLocation = "";
            this.ptMinute1.Location = new System.Drawing.Point(70, 50);
            this.ptMinute1.Name = "ptMinute1";
            this.ptMinute1.Size = new System.Drawing.Size(40, 59);
            this.ptMinute1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptMinute1.TabIndex = 2;
            this.ptMinute1.TabStop = false;
            // 
            // ptSecond1
            // 
            this.ptSecond1.Image = ((System.Drawing.Image)(resources.GetObject("ptSecond1.Image")));
            this.ptSecond1.Location = new System.Drawing.Point(210, 50);
            this.ptSecond1.Name = "ptSecond1";
            this.ptSecond1.Size = new System.Drawing.Size(40, 59);
            this.ptSecond1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptSecond1.TabIndex = 3;
            this.ptSecond1.TabStop = false;
            // 
            // ptSecond2
            // 
            this.ptSecond2.Image = ((System.Drawing.Image)(resources.GetObject("ptSecond2.Image")));
            this.ptSecond2.Location = new System.Drawing.Point(256, 50);
            this.ptSecond2.Name = "ptSecond2";
            this.ptSecond2.Size = new System.Drawing.Size(40, 59);
            this.ptSecond2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptSecond2.TabIndex = 4;
            this.ptSecond2.TabStop = false;
            // 
            // DongHoDienTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ptSecond2);
            this.Controls.Add(this.ptSecond1);
            this.Controls.Add(this.ptMinute1);
            this.Controls.Add(this.ptMinute2);
            this.Controls.Add(this.ptDigitSep);
            this.Name = "DongHoDienTu";
            this.Size = new System.Drawing.Size(370, 159);
            this.Load += new System.EventHandler(this.DongHoDienTu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptDigitSep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptMinute2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptMinute1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptSecond1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptSecond2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmClock;
        private System.Windows.Forms.PictureBox ptDigitSep;
        private System.Windows.Forms.PictureBox ptMinute2;
        private System.Windows.Forms.PictureBox ptMinute1;
        private System.Windows.Forms.PictureBox ptSecond1;
        private System.Windows.Forms.PictureBox ptSecond2;
    }
}
