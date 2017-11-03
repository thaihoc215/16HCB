namespace _1642021ApiClient
{
    partial class frmDangNhap
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
            this.bntXemThongTin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaThe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboNganHang = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bntXemThongTin
            // 
            this.bntXemThongTin.Location = new System.Drawing.Point(45, 245);
            this.bntXemThongTin.Name = "bntXemThongTin";
            this.bntXemThongTin.Size = new System.Drawing.Size(95, 23);
            this.bntXemThongTin.TabIndex = 0;
            this.bntXemThongTin.Text = "Đăng Nhập";
            this.bntXemThongTin.UseVisualStyleBackColor = true;
            this.bntXemThongTin.Click += new System.EventHandler(this.bntXemThongTin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Thẻ";
            // 
            // txtMaThe
            // 
            this.txtMaThe.Location = new System.Drawing.Point(120, 56);
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.Size = new System.Drawing.Size(121, 20);
            this.txtMaThe.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ngân Hàng";
            // 
            // cboNganHang
            // 
            this.cboNganHang.FormattingEnabled = true;
            this.cboNganHang.Location = new System.Drawing.Point(120, 112);
            this.cboNganHang.Name = "cboNganHang";
            this.cboNganHang.Size = new System.Drawing.Size(121, 21);
            this.cboNganHang.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mật Khẩu";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(120, 168);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(121, 20);
            this.txtMatKhau.TabIndex = 6;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(146, 245);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(95, 23);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 303);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboNganHang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaThe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bntXemThongTin);
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntXemThongTin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaThe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboNganHang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnThoat;
    }
}

