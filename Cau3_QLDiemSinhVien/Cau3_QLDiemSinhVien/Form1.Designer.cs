namespace Cau3_QLDiemSinhVien
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            lstLop = new ListBox();
            txtTimKiem = new TextBox();
            dgvSinhVien = new DataGridView();
            groupBox2 = new GroupBox();
            btnXoaSV = new Button();
            btnSuaSV = new Button();
            btnThemSV = new Button();
            label3 = new Label();
            cboLop = new ComboBox();
            rdoNu = new RadioButton();
            rdoNam = new RadioButton();
            dtpNgaySinh = new DateTimePicker();
            txtHoTen = new TextBox();
            label2 = new Label();
            txtMaSV = new TextBox();
            label1 = new Label();
            groupBox3 = new GroupBox();
            lblXepLoai = new Label();
            lblDiemTB = new Label();
            lblTongTinChi = new Label();
            btnXoaMon = new Button();
            btnSuaDiem = new Button();
            btnThemMon = new Button();
            nudDiem = new NumericUpDown();
            label6 = new Label();
            nudSoTinChi = new NumericUpDown();
            label5 = new Label();
            txtTenMon = new TextBox();
            label4 = new Label();
            dgvDiem = new DataGridView();
            btnXemTruoc = new Button();
            btnIn = new Button();
            btnXuatExcel = new Button();
            btnThietKeMau = new Button();
            btnCaiDatTrang = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSoTinChi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDiem).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lstLop);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(236, 260);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lớp";
            // 
            // lstLop
            // 
            lstLop.FormattingEnabled = true;
            lstLop.Location = new Point(6, 26);
            lstLop.Name = "lstLop";
            lstLop.Size = new Size(220, 224);
            lstLop.TabIndex = 0;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(254, 12);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(535, 27);
            txtTimKiem.TabIndex = 1;
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Location = new Point(254, 45);
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.RowHeadersWidth = 51;
            dgvSinhVien.Size = new Size(535, 227);
            dgvSinhVien.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnXoaSV);
            groupBox2.Controls.Add(btnSuaSV);
            groupBox2.Controls.Add(btnThemSV);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(cboLop);
            groupBox2.Controls.Add(rdoNu);
            groupBox2.Controls.Add(rdoNam);
            groupBox2.Controls.Add(dtpNgaySinh);
            groupBox2.Controls.Add(txtHoTen);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtMaSV);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(795, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(318, 260);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin sinh viên";
            // 
            // btnXoaSV
            // 
            btnXoaSV.Location = new Point(206, 221);
            btnXoaSV.Name = "btnXoaSV";
            btnXoaSV.Size = new Size(94, 29);
            btnXoaSV.TabIndex = 11;
            btnXoaSV.Text = "Xóa";
            btnXoaSV.UseVisualStyleBackColor = true;
            // 
            // btnSuaSV
            // 
            btnSuaSV.Location = new Point(106, 221);
            btnSuaSV.Name = "btnSuaSV";
            btnSuaSV.Size = new Size(94, 29);
            btnSuaSV.TabIndex = 10;
            btnSuaSV.Text = "Sửa";
            btnSuaSV.UseVisualStyleBackColor = true;
            // 
            // btnThemSV
            // 
            btnThemSV.Location = new Point(6, 221);
            btnThemSV.Name = "btnThemSV";
            btnThemSV.Size = new Size(94, 29);
            btnThemSV.TabIndex = 9;
            btnThemSV.Text = "Thêm";
            btnThemSV.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 188);
            label3.Name = "label3";
            label3.Size = new Size(34, 20);
            label3.TabIndex = 8;
            label3.Text = "Lớp";
            // 
            // cboLop
            // 
            cboLop.FormattingEnabled = true;
            cboLop.Location = new Point(85, 185);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(151, 28);
            cboLop.TabIndex = 7;
            // 
            // rdoNu
            // 
            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(121, 147);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(50, 24);
            rdoNu.TabIndex = 6;
            rdoNu.TabStop = true;
            rdoNu.Text = "Nữ";
            rdoNu.UseVisualStyleBackColor = true;
            // 
            // rdoNam
            // 
            rdoNam.AutoSize = true;
            rdoNam.Location = new Point(53, 147);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(62, 24);
            rdoNam.TabIndex = 5;
            rdoNam.TabStop = true;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Location = new Point(85, 105);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(215, 27);
            dtpNgaySinh.TabIndex = 4;
            dtpNgaySinh.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(85, 72);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(215, 27);
            txtHoTen.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 70);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 2;
            label2.Text = "Họ tên";
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(82, 26);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(218, 27);
            txtMaSV.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 33);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 0;
            label1.Text = "MSSV";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblXepLoai);
            groupBox3.Controls.Add(lblDiemTB);
            groupBox3.Controls.Add(lblTongTinChi);
            groupBox3.Controls.Add(btnXoaMon);
            groupBox3.Controls.Add(btnSuaDiem);
            groupBox3.Controls.Add(btnThemMon);
            groupBox3.Controls.Add(nudDiem);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(nudSoTinChi);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(txtTenMon);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(dgvDiem);
            groupBox3.Location = new Point(12, 278);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1101, 221);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Điểm của sinh viên";
            // 
            // lblXepLoai
            // 
            lblXepLoai.AutoSize = true;
            lblXepLoai.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            lblXepLoai.Location = new Point(876, 162);
            lblXepLoai.Name = "lblXepLoai";
            lblXepLoai.Size = new Size(207, 25);
            lblXepLoai.TabIndex = 12;
            lblXepLoai.Text = "Xếp loại: Chưa có điểm";
            // 
            // lblDiemTB
            // 
            lblDiemTB.AutoSize = true;
            lblDiemTB.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            lblDiemTB.Location = new Point(673, 189);
            lblDiemTB.Name = "lblDiemTB";
            lblDiemTB.Size = new Size(210, 25);
            lblDiemTB.TabIndex = 11;
            lblDiemTB.Text = "Điểm TB: Chưa có điểm";
            // 
            // lblTongTinChi
            // 
            lblTongTinChi.AutoSize = true;
            lblTongTinChi.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            lblTongTinChi.Location = new Point(538, 162);
            lblTongTinChi.Name = "lblTongTinChi";
            lblTongTinChi.Size = new Size(134, 25);
            lblTongTinChi.TabIndex = 10;
            lblTongTinChi.Text = "Tổng tín chỉ: 0";
            // 
            // btnXoaMon
            // 
            btnXoaMon.Location = new Point(836, 100);
            btnXoaMon.Name = "btnXoaMon";
            btnXoaMon.Size = new Size(94, 29);
            btnXoaMon.TabIndex = 9;
            btnXoaMon.Text = "Xóa môn";
            btnXoaMon.UseVisualStyleBackColor = true;
            // 
            // btnSuaDiem
            // 
            btnSuaDiem.Location = new Point(692, 100);
            btnSuaDiem.Name = "btnSuaDiem";
            btnSuaDiem.Size = new Size(94, 29);
            btnSuaDiem.TabIndex = 8;
            btnSuaDiem.Text = "Sửa điểm";
            btnSuaDiem.UseVisualStyleBackColor = true;
            // 
            // btnThemMon
            // 
            btnThemMon.Location = new Point(563, 100);
            btnThemMon.Name = "btnThemMon";
            btnThemMon.Size = new Size(94, 29);
            btnThemMon.TabIndex = 7;
            btnThemMon.Text = "Thêm môn";
            btnThemMon.UseVisualStyleBackColor = true;
            // 
            // nudDiem
            // 
            nudDiem.Location = new Point(975, 48);
            nudDiem.Name = "nudDiem";
            nudDiem.Size = new Size(108, 27);
            nudDiem.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(975, 20);
            label6.Name = "label6";
            label6.Size = new Size(45, 20);
            label6.TabIndex = 5;
            label6.Text = "Điểm";
            // 
            // nudSoTinChi
            // 
            nudSoTinChi.Location = new Point(848, 49);
            nudSoTinChi.Name = "nudSoTinChi";
            nudSoTinChi.Size = new Size(106, 27);
            nudSoTinChi.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(848, 23);
            label5.Name = "label5";
            label5.Size = new Size(46, 20);
            label5.TabIndex = 3;
            label5.Text = "Số TC";
            // 
            // txtTenMon
            // 
            txtTenMon.Location = new Point(549, 48);
            txtTenMon.Name = "txtTenMon";
            txtTenMon.Size = new Size(287, 27);
            txtTenMon.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(549, 25);
            label4.Name = "label4";
            label4.Size = new Size(66, 20);
            label4.TabIndex = 1;
            label4.Text = "Tên môn";
            // 
            // dgvDiem
            // 
            dgvDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiem.Location = new Point(6, 26);
            dgvDiem.Name = "dgvDiem";
            dgvDiem.RowHeadersWidth = 51;
            dgvDiem.Size = new Size(526, 188);
            dgvDiem.TabIndex = 0;
            // 
            // btnXemTruoc
            // 
            btnXemTruoc.Location = new Point(29, 510);
            btnXemTruoc.Name = "btnXemTruoc";
            btnXemTruoc.Size = new Size(131, 29);
            btnXemTruoc.TabIndex = 5;
            btnXemTruoc.Text = "Xem trước phiếu";
            btnXemTruoc.UseVisualStyleBackColor = true;
            // 
            // btnIn
            // 
            btnIn.Location = new Point(188, 510);
            btnIn.Name = "btnIn";
            btnIn.Size = new Size(94, 29);
            btnIn.TabIndex = 6;
            btnIn.Text = "In...";
            btnIn.UseVisualStyleBackColor = true;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.Location = new Point(467, 510);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(160, 29);
            btnXuatExcel.TabIndex = 8;
            btnXuatExcel.Text = "Xuất Excel điểm lớp";
            btnXuatExcel.UseVisualStyleBackColor = true;
            // 
            // btnThietKeMau
            // 
            btnThietKeMau.Location = new Point(642, 510);
            btnThietKeMau.Name = "btnThietKeMau";
            btnThietKeMau.Size = new Size(200, 29);
            btnThietKeMau.TabIndex = 9;
            btnThietKeMau.Text = "Chỉnh form phiếu (FastReport)";
            btnThietKeMau.UseVisualStyleBackColor = true;
            // 
            // btnCaiDatTrang
            // 
            btnCaiDatTrang.Location = new Point(312, 510);
            btnCaiDatTrang.Name = "btnCaiDatTrang";
            btnCaiDatTrang.Size = new Size(127, 29);
            btnCaiDatTrang.TabIndex = 7;
            btnCaiDatTrang.Text = "Cài đặt trang...";
            btnCaiDatTrang.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 546);
            Controls.Add(btnThietKeMau);
            Controls.Add(btnXuatExcel);
            Controls.Add(btnCaiDatTrang);
            Controls.Add(btnIn);
            Controls.Add(btnXemTruoc);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(dgvSinhVien);
            Controls.Add(txtTimKiem);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Quản lý sinh viên và điểm";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiem).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSoTinChi).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDiem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private ListBox lstLop;
        private TextBox txtTimKiem;
        private DataGridView dgvSinhVien;
        private GroupBox groupBox2;
        private DateTimePicker dtpNgaySinh;
        private TextBox txtHoTen;
        private Label label2;
        private TextBox txtMaSV;
        private Label label1;
        private ComboBox cboLop;
        private RadioButton rdoNu;
        private RadioButton rdoNam;
        private Button btnXoaSV;
        private Button btnSuaSV;
        private Button btnThemSV;
        private Label label3;
        private GroupBox groupBox3;
        private DataGridView dgvDiem;
        private Label lblXepLoai;
        private Label lblDiemTB;
        private Label lblTongTinChi;
        private Button btnXoaMon;
        private Button btnSuaDiem;
        private Button btnThemMon;
        private NumericUpDown nudDiem;
        private Label label6;
        private NumericUpDown nudSoTinChi;
        private Label label5;
        private TextBox txtTenMon;
        private Label label4;
        private Button btnXemTruoc;
        private Button btnIn;
        private Button btnXuatExcel;
        private Button btnThietKeMau;
        private Button btnCaiDatTrang;
    }
}
