namespace _1642021
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnResume = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblStop = new System.Windows.Forms.Label();
            this.lstListTime = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStopCount = new System.Windows.Forms.Button();
            this.btnCountDown = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dongHoDienTu1 = new _1642021.DongHoDienTu();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnResume
            // 
            this.btnResume.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnResume.Font = new System.Drawing.Font("Modern No. 20", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResume.Location = new System.Drawing.Point(257, 19);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(80, 32);
            this.btnResume.TabIndex = 8;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = false;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.Tomato;
            this.btnPause.Font = new System.Drawing.Font("Modern No. 20", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(145, 19);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(80, 32);
            this.btnPause.TabIndex = 7;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStop.Font = new System.Drawing.Font("Modern No. 20", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(368, 19);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(88, 32);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnStart.Font = new System.Drawing.Font("Modern No. 20", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(22, 19);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(88, 32);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblStop
            // 
            this.lblStop.AutoSize = true;
            this.lblStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblStop.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblStop.Location = new System.Drawing.Point(147, 244);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(0, 20);
            this.lblStop.TabIndex = 10;
            // 
            // lstListTime
            // 
            this.lstListTime.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lstListTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lstListTime.ForeColor = System.Drawing.Color.Red;
            this.lstListTime.FormattingEnabled = true;
            this.lstListTime.ItemHeight = 24;
            this.lstListTime.Location = new System.Drawing.Point(425, 47);
            this.lstListTime.Name = "lstListTime";
            this.lstListTime.Size = new System.Drawing.Size(96, 124);
            this.lstListTime.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStopCount);
            this.groupBox1.Controls.Add(this.btnCountDown);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(31, 304);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 114);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Count Down";
            // 
            // btnStopCount
            // 
            this.btnStopCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStopCount.Font = new System.Drawing.Font("Modern No. 20", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopCount.Location = new System.Drawing.Point(257, 72);
            this.btnStopCount.Name = "btnStopCount";
            this.btnStopCount.Size = new System.Drawing.Size(100, 32);
            this.btnStopCount.TabIndex = 7;
            this.btnStopCount.Text = "Stop";
            this.btnStopCount.UseVisualStyleBackColor = false;
            this.btnStopCount.Click += new System.EventHandler(this.btnStopCount_Click);
            // 
            // btnCountDown
            // 
            this.btnCountDown.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCountDown.Font = new System.Drawing.Font("Modern No. 20", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCountDown.Location = new System.Drawing.Point(145, 72);
            this.btnCountDown.Name = "btnCountDown";
            this.btnCountDown.Size = new System.Drawing.Size(106, 32);
            this.btnCountDown.TabIndex = 6;
            this.btnCountDown.Text = "Count Down";
            this.btnCountDown.UseVisualStyleBackColor = false;
            this.btnCountDown.Click += new System.EventHandler(this.btnCountDown_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "mm:ss";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(145, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(212, 47);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Value = new System.DateTime(2017, 10, 21, 0, 0, 0, 0);
            // 
            // dongHoDienTu1
            // 
            this.dongHoDienTu1.Location = new System.Drawing.Point(12, 12);
            this.dongHoDienTu1.Name = "dongHoDienTu1";
            this.dongHoDienTu1.Size = new System.Drawing.Size(390, 159);
            this.dongHoDienTu1.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnStart);
            this.groupBox2.Controls.Add(this.btnPause);
            this.groupBox2.Controls.Add(this.btnResume);
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Location = new System.Drawing.Point(31, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(490, 72);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clocking";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 430);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dongHoDienTu1);
            this.Controls.Add(this.lstListTime);
            this.Controls.Add(this.lblStop);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Stopwatch Application";
            this.Text = "Stopwatch Application";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnResume;
        internal System.Windows.Forms.Button btnPause;
        internal System.Windows.Forms.Button btnStop;
        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.Label lblStop;
        internal System.Windows.Forms.ListBox lstListTime;
        private DongHoDienTu dongHoDienTu1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        internal System.Windows.Forms.Button btnStopCount;
        internal System.Windows.Forms.Button btnCountDown;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

