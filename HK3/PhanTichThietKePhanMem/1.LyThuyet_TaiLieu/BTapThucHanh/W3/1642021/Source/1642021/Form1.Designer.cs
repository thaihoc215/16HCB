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
            this.Label1 = new System.Windows.Forms.Label();
            this.lstListTime = new System.Windows.Forms.ListBox();
            this.dongHoDienTu1 = new _1642021.DongHoDienTu();
            this.SuspendLayout();
            // 
            // btnResume
            // 
            this.btnResume.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnResume.Font = new System.Drawing.Font("Modern No. 20", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResume.Location = new System.Drawing.Point(263, 199);
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
            this.btnPause.Location = new System.Drawing.Point(151, 199);
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
            this.btnStop.Location = new System.Drawing.Point(367, 199);
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
            this.btnStart.Location = new System.Drawing.Point(31, 199);
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
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Label1.Location = new System.Drawing.Point(105, 275);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(263, 17);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "The Application Will Close After 1 Minute";
            // 
            // lstListTime
            // 
            this.lstListTime.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lstListTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lstListTime.ForeColor = System.Drawing.Color.Red;
            this.lstListTime.FormattingEnabled = true;
            this.lstListTime.ItemHeight = 24;
            this.lstListTime.Location = new System.Drawing.Point(359, 37);
            this.lstListTime.Name = "lstListTime";
            this.lstListTime.Size = new System.Drawing.Size(96, 124);
            this.lstListTime.TabIndex = 11;
            // 
            // dongHoDienTu1
            // 
            this.dongHoDienTu1.Location = new System.Drawing.Point(12, 12);
            this.dongHoDienTu1.Name = "dongHoDienTu1";
            this.dongHoDienTu1.Size = new System.Drawing.Size(331, 159);
            this.dongHoDienTu1.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 311);
            this.Controls.Add(this.dongHoDienTu1);
            this.Controls.Add(this.lstListTime);
            this.Controls.Add(this.lblStop);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stopwatch Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnResume;
        internal System.Windows.Forms.Button btnPause;
        internal System.Windows.Forms.Button btnStop;
        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.Label lblStop;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ListBox lstListTime;
        private DongHoDienTu dongHoDienTu1;
    }
}

