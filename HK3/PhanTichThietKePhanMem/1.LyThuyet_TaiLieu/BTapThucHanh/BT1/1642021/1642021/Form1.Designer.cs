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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDshs = new System.Windows.Forms.DataGridView();
            this.CMaHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTenHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTimHS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimHS = new System.Windows.Forms.TextBox();
            this.btnThemHS = new System.Windows.Forms.Button();
            this.btnXoaHS = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDshs)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvDshs);
            this.groupBox1.Location = new System.Drawing.Point(15, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(669, 224);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Học Sinh";
            // 
            // dgvDshs
            // 
            this.dgvDshs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDshs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDshs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CMaHS,
            this.CTenHS,
            this.CNgaySinh,
            this.CSoDienThoai,
            this.CDiaChi});
            this.dgvDshs.Location = new System.Drawing.Point(3, 16);
            this.dgvDshs.MultiSelect = false;
            this.dgvDshs.Name = "dgvDshs";
            this.dgvDshs.ReadOnly = true;
            this.dgvDshs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDshs.Size = new System.Drawing.Size(660, 200);
            this.dgvDshs.TabIndex = 3;
            // 
            // CMaHS
            // 
            this.CMaHS.DataPropertyName = "MaHS";
            this.CMaHS.HeaderText = "Mã Học Sinh";
            this.CMaHS.Name = "CMaHS";
            this.CMaHS.ReadOnly = true;
            // 
            // CTenHS
            // 
            this.CTenHS.DataPropertyName = "TenHS";
            this.CTenHS.HeaderText = "Tên Học Sinh";
            this.CTenHS.Name = "CTenHS";
            this.CTenHS.ReadOnly = true;
            // 
            // CNgaySinh
            // 
            this.CNgaySinh.DataPropertyName = "NgaySinh";
            this.CNgaySinh.HeaderText = "Ngày Sinh";
            this.CNgaySinh.Name = "CNgaySinh";
            this.CNgaySinh.ReadOnly = true;
            // 
            // CSoDienThoai
            // 
            this.CSoDienThoai.DataPropertyName = "SDT";
            this.CSoDienThoai.HeaderText = "Số ĐT";
            this.CSoDienThoai.Name = "CSoDienThoai";
            this.CSoDienThoai.ReadOnly = true;
            // 
            // CDiaChi
            // 
            this.CDiaChi.DataPropertyName = "DiaChi";
            this.CDiaChi.HeaderText = "Địa Chỉ";
            this.CDiaChi.Name = "CDiaChi";
            this.CDiaChi.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTimHS);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtTimHS);
            this.groupBox2.Location = new System.Drawing.Point(15, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 51);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm Kiếm Học Sinh";
            // 
            // btnTimHS
            // 
            this.btnTimHS.Location = new System.Drawing.Point(271, 19);
            this.btnTimHS.Name = "btnTimHS";
            this.btnTimHS.Size = new System.Drawing.Size(75, 23);
            this.btnTimHS.TabIndex = 2;
            this.btnTimHS.Text = "Tìm";
            this.btnTimHS.UseVisualStyleBackColor = true;
            this.btnTimHS.Click += new System.EventHandler(this.btnTimHS_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên Học Sinh";
            // 
            // txtTimHS
            // 
            this.txtTimHS.Location = new System.Drawing.Point(105, 19);
            this.txtTimHS.Name = "txtTimHS";
            this.txtTimHS.Size = new System.Drawing.Size(150, 20);
            this.txtTimHS.TabIndex = 1;
            // 
            // btnThemHS
            // 
            this.btnThemHS.Location = new System.Drawing.Point(15, 311);
            this.btnThemHS.Name = "btnThemHS";
            this.btnThemHS.Size = new System.Drawing.Size(114, 23);
            this.btnThemHS.TabIndex = 4;
            this.btnThemHS.Text = "Thêm Học Sinh";
            this.btnThemHS.UseVisualStyleBackColor = true;
            this.btnThemHS.Click += new System.EventHandler(this.btnThemHS_Click);
            // 
            // btnXoaHS
            // 
            this.btnXoaHS.Location = new System.Drawing.Point(135, 311);
            this.btnXoaHS.Name = "btnXoaHS";
            this.btnXoaHS.Size = new System.Drawing.Size(114, 23);
            this.btnXoaHS.TabIndex = 5;
            this.btnXoaHS.Text = "Xóa Học Sinh";
            this.btnXoaHS.UseVisualStyleBackColor = true;
            this.btnXoaHS.Click += new System.EventHandler(this.btnXoaHS_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(609, 311);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnTimHS;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 346);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnXoaHS);
            this.Controls.Add(this.btnThemHS);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Học Sinh";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDshs)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDshs;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTimHS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimHS;
        private System.Windows.Forms.Button btnThemHS;
        private System.Windows.Forms.Button btnXoaHS;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMaHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTenHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDiaChi;
    }
}

