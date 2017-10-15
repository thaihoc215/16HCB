namespace BaiTap2_Anh_Viet
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
            this.txtVi = new System.Windows.Forms.TextBox();
            this.txtEng = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTrans = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtVi
            // 
            this.txtVi.Location = new System.Drawing.Point(117, 120);
            this.txtVi.Name = "txtVi";
            this.txtVi.ReadOnly = true;
            this.txtVi.Size = new System.Drawing.Size(187, 20);
            this.txtVi.TabIndex = 9;
            // 
            // txtEng
            // 
            this.txtEng.Location = new System.Drawing.Point(117, 77);
            this.txtEng.Name = "txtEng";
            this.txtEng.Size = new System.Drawing.Size(187, 20);
            this.txtEng.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "English";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Vietnamese";
            // 
            // btnTrans
            // 
            this.btnTrans.Location = new System.Drawing.Point(229, 170);
            this.btnTrans.Name = "btnTrans";
            this.btnTrans.Size = new System.Drawing.Size(75, 23);
            this.btnTrans.TabIndex = 5;
            this.btnTrans.Text = "Translate";
            this.btnTrans.UseVisualStyleBackColor = true;
            this.btnTrans.Click += new System.EventHandler(this.btnTrans_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 261);
            this.Controls.Add(this.txtVi);
            this.Controls.Add(this.txtEng);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTrans);
            this.Name = "Form1";
            this.Text = "EVDict";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVi;
        private System.Windows.Forms.TextBox txtEng;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTrans;
    }
}

