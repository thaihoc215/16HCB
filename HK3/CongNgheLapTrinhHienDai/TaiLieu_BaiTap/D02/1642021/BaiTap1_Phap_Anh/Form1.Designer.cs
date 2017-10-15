namespace BaiTap1_Phap_Anh
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
            this.btnTrans = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFr = new System.Windows.Forms.TextBox();
            this.txtEn = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnTrans
            // 
            this.btnTrans.Location = new System.Drawing.Point(239, 150);
            this.btnTrans.Name = "btnTrans";
            this.btnTrans.Size = new System.Drawing.Size(75, 23);
            this.btnTrans.TabIndex = 0;
            this.btnTrans.Text = "Translate";
            this.btnTrans.UseVisualStyleBackColor = true;
            this.btnTrans.Click += new System.EventHandler(this.btnTrans_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "French";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "English";
            // 
            // txtFr
            // 
            this.txtFr.Location = new System.Drawing.Point(127, 54);
            this.txtFr.Name = "txtFr";
            this.txtFr.Size = new System.Drawing.Size(187, 20);
            this.txtFr.TabIndex = 3;
            // 
            // txtEn
            // 
            this.txtEn.Location = new System.Drawing.Point(127, 100);
            this.txtEn.Name = "txtEn";
            this.txtEn.ReadOnly = true;
            this.txtEn.Size = new System.Drawing.Size(187, 20);
            this.txtEn.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 261);
            this.Controls.Add(this.txtEn);
            this.Controls.Add(this.txtFr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTrans);
            this.Name = "Form1";
            this.Text = "FEDict";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTrans;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFr;
        private System.Windows.Forms.TextBox txtEn;
    }
}

