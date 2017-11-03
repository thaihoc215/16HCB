namespace _1642021ApiClient
{
    partial class frmThongTin
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
            this.btnThoat = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabThongTin = new System.Windows.Forms.TabPage();
            this.lblNganHang = new System.Windows.Forms.Label();
            this.lblMaThe = new System.Windows.Forms.Label();
            this.lblTenChuThe = new System.Windows.Forms.Label();
            this.lblSoDu = new System.Windows.Forms.Label();
            this.lblNgayHetHan = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblSauRutTien = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRutTien = new System.Windows.Forms.Button();
            this.nmrSoTien = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.rdoSoKhac = new System.Windows.Forms.RadioButton();
            this.rdo5t = new System.Windows.Forms.RadioButton();
            this.rdo2t = new System.Windows.Forms.RadioButton();
            this.rdo1t = new System.Windows.Forms.RadioButton();
            this.tabChuyentien = new System.Windows.Forms.TabPage();
            this.lblSauKhiChuyenTien = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnChuyenTien = new System.Windows.Forms.Button();
            this.cboNganHang = new System.Windows.Forms.ComboBox();
            this.txtMaNguoiNhan = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nmrSoTienChuyen = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.tabLichSu = new System.Windows.Forms.TabPage();
            this.dgvGiaoDich = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnXemTatCa = new System.Windows.Forms.Button();
            this.colMaGD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThoDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMain.SuspendLayout();
            this.tabThongTin.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSoTien)).BeginInit();
            this.tabChuyentien.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSoTienChuyen)).BeginInit();
            this.tabLichSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(12, 336);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabThongTin);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabChuyentien);
            this.tabMain.Controls.Add(this.tabLichSu);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(492, 318);
            this.tabMain.TabIndex = 11;
            // 
            // tabThongTin
            // 
            this.tabThongTin.Controls.Add(this.lblNganHang);
            this.tabThongTin.Controls.Add(this.lblMaThe);
            this.tabThongTin.Controls.Add(this.lblTenChuThe);
            this.tabThongTin.Controls.Add(this.lblSoDu);
            this.tabThongTin.Controls.Add(this.lblNgayHetHan);
            this.tabThongTin.Controls.Add(this.label5);
            this.tabThongTin.Controls.Add(this.label4);
            this.tabThongTin.Controls.Add(this.label3);
            this.tabThongTin.Controls.Add(this.label2);
            this.tabThongTin.Controls.Add(this.label1);
            this.tabThongTin.Location = new System.Drawing.Point(4, 25);
            this.tabThongTin.Name = "tabThongTin";
            this.tabThongTin.Padding = new System.Windows.Forms.Padding(3);
            this.tabThongTin.Size = new System.Drawing.Size(542, 289);
            this.tabThongTin.TabIndex = 0;
            this.tabThongTin.Text = "Thông Tin";
            this.tabThongTin.UseVisualStyleBackColor = true;
            // 
            // lblNganHang
            // 
            this.lblNganHang.AutoSize = true;
            this.lblNganHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNganHang.Location = new System.Drawing.Point(124, 174);
            this.lblNganHang.Name = "lblNganHang";
            this.lblNganHang.Size = new System.Drawing.Size(99, 16);
            this.lblNganHang.TabIndex = 19;
            this.lblNganHang.Text = "lblNganHang";
            // 
            // lblMaThe
            // 
            this.lblMaThe.AutoSize = true;
            this.lblMaThe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaThe.Location = new System.Drawing.Point(124, 26);
            this.lblMaThe.Name = "lblMaThe";
            this.lblMaThe.Size = new System.Drawing.Size(73, 16);
            this.lblMaThe.TabIndex = 18;
            this.lblMaThe.Text = "lblMaThe";
            // 
            // lblTenChuThe
            // 
            this.lblTenChuThe.AutoSize = true;
            this.lblTenChuThe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenChuThe.Location = new System.Drawing.Point(124, 63);
            this.lblTenChuThe.Name = "lblTenChuThe";
            this.lblTenChuThe.Size = new System.Drawing.Size(105, 16);
            this.lblTenChuThe.TabIndex = 17;
            this.lblTenChuThe.Text = "lblTenChuThe";
            // 
            // lblSoDu
            // 
            this.lblSoDu.AutoSize = true;
            this.lblSoDu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoDu.Location = new System.Drawing.Point(124, 98);
            this.lblSoDu.Name = "lblSoDu";
            this.lblSoDu.Size = new System.Drawing.Size(63, 16);
            this.lblSoDu.TabIndex = 16;
            this.lblSoDu.Text = "lblSoDu";
            // 
            // lblNgayHetHan
            // 
            this.lblNgayHetHan.AutoSize = true;
            this.lblNgayHetHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayHetHan.Location = new System.Drawing.Point(124, 136);
            this.lblNgayHetHan.Name = "lblNgayHetHan";
            this.lblNgayHetHan.Size = new System.Drawing.Size(114, 16);
            this.lblNgayHetHan.TabIndex = 15;
            this.lblNgayHetHan.Text = "lblNgayHetHan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Ngân Hàng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Ngày Hết Hạn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Số Dư: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tên Chủ Thẻ: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mã Thẻ: ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblSauRutTien);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(484, 289);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Rút Tiền";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblSauRutTien
            // 
            this.lblSauRutTien.AutoSize = true;
            this.lblSauRutTien.Location = new System.Drawing.Point(54, 243);
            this.lblSauRutTien.Name = "lblSauRutTien";
            this.lblSauRutTien.Size = new System.Drawing.Size(0, 16);
            this.lblSauRutTien.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRutTien);
            this.groupBox1.Controls.Add(this.nmrSoTien);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.rdoSoKhac);
            this.groupBox1.Controls.Add(this.rdo5t);
            this.groupBox1.Controls.Add(this.rdo2t);
            this.groupBox1.Controls.Add(this.rdo1t);
            this.groupBox1.Location = new System.Drawing.Point(57, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 223);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn số tiền";
            // 
            // btnRutTien
            // 
            this.btnRutTien.Location = new System.Drawing.Point(289, 194);
            this.btnRutTien.Name = "btnRutTien";
            this.btnRutTien.Size = new System.Drawing.Size(75, 23);
            this.btnRutTien.TabIndex = 11;
            this.btnRutTien.Text = "Rút Tiền";
            this.btnRutTien.UseVisualStyleBackColor = true;
            this.btnRutTien.Click += new System.EventHandler(this.btnRutTien_Click);
            // 
            // nmrSoTien
            // 
            this.nmrSoTien.Enabled = false;
            this.nmrSoTien.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmrSoTien.Location = new System.Drawing.Point(135, 154);
            this.nmrSoTien.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            this.nmrSoTien.Minimum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nmrSoTien.Name = "nmrSoTien";
            this.nmrSoTien.Size = new System.Drawing.Size(165, 22);
            this.nmrSoTien.TabIndex = 5;
            this.nmrSoTien.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Nhập Số Tiền";
            // 
            // rdoSoKhac
            // 
            this.rdoSoKhac.AutoSize = true;
            this.rdoSoKhac.Location = new System.Drawing.Point(188, 93);
            this.rdoSoKhac.Name = "rdoSoKhac";
            this.rdoSoKhac.Size = new System.Drawing.Size(76, 20);
            this.rdoSoKhac.TabIndex = 3;
            this.rdoSoKhac.Text = "Số Khác";
            this.rdoSoKhac.UseVisualStyleBackColor = true;
            this.rdoSoKhac.CheckedChanged += new System.EventHandler(this.rdoSoKhac_CheckedChanged);
            // 
            // rdo5t
            // 
            this.rdo5t.AutoSize = true;
            this.rdo5t.Location = new System.Drawing.Point(38, 93);
            this.rdo5t.Name = "rdo5t";
            this.rdo5t.Size = new System.Drawing.Size(81, 20);
            this.rdo5t.TabIndex = 2;
            this.rdo5t.Text = "5,000,000";
            this.rdo5t.UseVisualStyleBackColor = true;
            // 
            // rdo2t
            // 
            this.rdo2t.AutoSize = true;
            this.rdo2t.Location = new System.Drawing.Point(188, 40);
            this.rdo2t.Name = "rdo2t";
            this.rdo2t.Size = new System.Drawing.Size(81, 20);
            this.rdo2t.TabIndex = 1;
            this.rdo2t.Text = "2,000,000";
            this.rdo2t.UseVisualStyleBackColor = true;
            // 
            // rdo1t
            // 
            this.rdo1t.AutoSize = true;
            this.rdo1t.Checked = true;
            this.rdo1t.Location = new System.Drawing.Point(38, 40);
            this.rdo1t.Name = "rdo1t";
            this.rdo1t.Size = new System.Drawing.Size(81, 20);
            this.rdo1t.TabIndex = 0;
            this.rdo1t.TabStop = true;
            this.rdo1t.Text = "1,000,000";
            this.rdo1t.UseVisualStyleBackColor = true;
            // 
            // tabChuyentien
            // 
            this.tabChuyentien.Controls.Add(this.lblSauKhiChuyenTien);
            this.tabChuyentien.Controls.Add(this.groupBox2);
            this.tabChuyentien.Location = new System.Drawing.Point(4, 25);
            this.tabChuyentien.Name = "tabChuyentien";
            this.tabChuyentien.Padding = new System.Windows.Forms.Padding(3);
            this.tabChuyentien.Size = new System.Drawing.Size(484, 289);
            this.tabChuyentien.TabIndex = 2;
            this.tabChuyentien.Text = "Chuyển Tiền";
            this.tabChuyentien.UseVisualStyleBackColor = true;
            // 
            // lblSauKhiChuyenTien
            // 
            this.lblSauKhiChuyenTien.AutoSize = true;
            this.lblSauKhiChuyenTien.Location = new System.Drawing.Point(26, 255);
            this.lblSauKhiChuyenTien.Name = "lblSauKhiChuyenTien";
            this.lblSauKhiChuyenTien.Size = new System.Drawing.Size(0, 16);
            this.lblSauKhiChuyenTien.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnChuyenTien);
            this.groupBox2.Controls.Add(this.cboNganHang);
            this.groupBox2.Controls.Add(this.txtMaNguoiNhan);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.nmrSoTienChuyen);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(29, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 231);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin người nhận";
            // 
            // btnChuyenTien
            // 
            this.btnChuyenTien.Location = new System.Drawing.Point(302, 188);
            this.btnChuyenTien.Name = "btnChuyenTien";
            this.btnChuyenTien.Size = new System.Drawing.Size(93, 23);
            this.btnChuyenTien.TabIndex = 11;
            this.btnChuyenTien.Text = "Chuyển Tiền";
            this.btnChuyenTien.UseVisualStyleBackColor = true;
            this.btnChuyenTien.Click += new System.EventHandler(this.btnChuyenTien_Click);
            // 
            // cboNganHang
            // 
            this.cboNganHang.FormattingEnabled = true;
            this.cboNganHang.Location = new System.Drawing.Point(148, 94);
            this.cboNganHang.Name = "cboNganHang";
            this.cboNganHang.Size = new System.Drawing.Size(150, 24);
            this.cboNganHang.TabIndex = 9;
            // 
            // txtMaNguoiNhan
            // 
            this.txtMaNguoiNhan.Location = new System.Drawing.Point(148, 31);
            this.txtMaNguoiNhan.Name = "txtMaNguoiNhan";
            this.txtMaNguoiNhan.Size = new System.Drawing.Size(150, 22);
            this.txtMaNguoiNhan.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "Ngân Hàng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Mã Người Nhận";
            // 
            // nmrSoTienChuyen
            // 
            this.nmrSoTienChuyen.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmrSoTienChuyen.Location = new System.Drawing.Point(148, 157);
            this.nmrSoTienChuyen.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            this.nmrSoTienChuyen.Minimum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nmrSoTienChuyen.Name = "nmrSoTienChuyen";
            this.nmrSoTienChuyen.Size = new System.Drawing.Size(150, 22);
            this.nmrSoTienChuyen.TabIndex = 5;
            this.nmrSoTienChuyen.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Nhập Số Tiền";
            // 
            // tabLichSu
            // 
            this.tabLichSu.Controls.Add(this.btnXemTatCa);
            this.tabLichSu.Controls.Add(this.btnXem);
            this.tabLichSu.Controls.Add(this.dtpTo);
            this.tabLichSu.Controls.Add(this.label11);
            this.tabLichSu.Controls.Add(this.dtpFrom);
            this.tabLichSu.Controls.Add(this.label10);
            this.tabLichSu.Controls.Add(this.dgvGiaoDich);
            this.tabLichSu.Location = new System.Drawing.Point(4, 25);
            this.tabLichSu.Name = "tabLichSu";
            this.tabLichSu.Padding = new System.Windows.Forms.Padding(3);
            this.tabLichSu.Size = new System.Drawing.Size(484, 289);
            this.tabLichSu.TabIndex = 3;
            this.tabLichSu.Text = "Lịch Sử Giao Dịch";
            this.tabLichSu.UseVisualStyleBackColor = true;
            // 
            // dgvGiaoDich
            // 
            this.dgvGiaoDich.AllowUserToDeleteRows = false;
            this.dgvGiaoDich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiaoDich.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaGD,
            this.colSoTien,
            this.colThoDiem,
            this.colLoai});
            this.dgvGiaoDich.Location = new System.Drawing.Point(6, 32);
            this.dgvGiaoDich.Name = "dgvGiaoDich";
            this.dgvGiaoDich.ReadOnly = true;
            this.dgvGiaoDich.Size = new System.Drawing.Size(472, 251);
            this.dgvGiaoDich.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Từ";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(38, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(109, 22);
            this.dtpFrom.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(153, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "Đến";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(191, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(109, 22);
            this.dtpTo.TabIndex = 4;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(307, 4);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 22);
            this.btnXem.TabIndex = 5;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnXemTatCa
            // 
            this.btnXemTatCa.Location = new System.Drawing.Point(389, 4);
            this.btnXemTatCa.Name = "btnXemTatCa";
            this.btnXemTatCa.Size = new System.Drawing.Size(89, 22);
            this.btnXemTatCa.TabIndex = 6;
            this.btnXemTatCa.Text = "Xem Tất Cả";
            this.btnXemTatCa.UseVisualStyleBackColor = true;
            this.btnXemTatCa.Click += new System.EventHandler(this.btnXemTatCa_Click);
            // 
            // colMaGD
            // 
            this.colMaGD.DataPropertyName = "MaGiaoDich";
            this.colMaGD.HeaderText = "Mã GD";
            this.colMaGD.Name = "colMaGD";
            this.colMaGD.ReadOnly = true;
            // 
            // colSoTien
            // 
            this.colSoTien.DataPropertyName = "SoTienGiaoDich";
            this.colSoTien.HeaderText = "Số Tiền";
            this.colSoTien.Name = "colSoTien";
            this.colSoTien.ReadOnly = true;
            // 
            // colThoDiem
            // 
            this.colThoDiem.DataPropertyName = "ThoiDiemGiaoDich";
            this.colThoDiem.HeaderText = "Thời Điểm";
            this.colThoDiem.Name = "colThoDiem";
            this.colThoDiem.ReadOnly = true;
            this.colThoDiem.Width = 120;
            // 
            // colLoai
            // 
            this.colLoai.DataPropertyName = "TenLoai";
            this.colLoai.HeaderText = "Loại GD";
            this.colLoai.Name = "colLoai";
            this.colLoai.ReadOnly = true;
            // 
            // frmThongTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 371);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.btnThoat);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmThongTin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông Tin Người Dùng";
            this.tabMain.ResumeLayout(false);
            this.tabThongTin.ResumeLayout(false);
            this.tabThongTin.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSoTien)).EndInit();
            this.tabChuyentien.ResumeLayout(false);
            this.tabChuyentien.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSoTienChuyen)).EndInit();
            this.tabLichSu.ResumeLayout(false);
            this.tabLichSu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabThongTin;
        private System.Windows.Forms.Label lblNganHang;
        private System.Windows.Forms.Label lblMaThe;
        private System.Windows.Forms.Label lblTenChuThe;
        private System.Windows.Forms.Label lblSoDu;
        private System.Windows.Forms.Label lblNgayHetHan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabChuyentien;
        private System.Windows.Forms.TabPage tabLichSu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdo5t;
        private System.Windows.Forms.RadioButton rdo2t;
        private System.Windows.Forms.RadioButton rdo1t;
        private System.Windows.Forms.RadioButton rdoSoKhac;
        private System.Windows.Forms.NumericUpDown nmrSoTien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRutTien;
        private System.Windows.Forms.Label lblSauRutTien;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnChuyenTien;
        private System.Windows.Forms.NumericUpDown nmrSoTienChuyen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaNguoiNhan;
        private System.Windows.Forms.ComboBox cboNganHang;
        private System.Windows.Forms.Label lblSauKhiChuyenTien;
        private System.Windows.Forms.DataGridView dgvGiaoDich;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnXemTatCa;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaGD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThoDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoai;
    }
}