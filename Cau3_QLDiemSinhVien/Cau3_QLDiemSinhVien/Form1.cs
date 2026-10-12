using Cau3_QLDiemSinhVien.Models;
using Cau3_QLDiemSinhVien.Printers;
using Cau3_QLDiemSinhVien.Services;
using Microsoft.EntityFrameworkCore;

namespace Cau3_QLDiemSinhVien
{
    public partial class Form1 : Form
    {
        private string maSVDangChon = "";
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            lstLop.SelectedIndexChanged += lstLop_SelectedIndexChanged;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;
            dgvDiem.CellClick += dgvDiem_CellClick;

            btnThemSV.Click += btnThemSV_Click;
            btnSuaSV.Click += btnSuaSV_Click;
            btnXoaSV.Click += btnXoaSV_Click;

            btnThemMon.Click += btnThemMon_Click;
            btnSuaDiem.Click += btnSuaDiem_Click;
            btnXoaMon.Click += btnXoaMon_Click;

            btnXemTruoc.Click += btnXemTruoc_Click;
            btnIn.Click += btnIn_Click;
            btnCaiDatTrang.Click += btnCaiDatTrang_Click;
            btnXuatExcel.Click += btnXuatExcel_Click;
            btnThietKeMau.Click += btnThietKeMau_Click;

            nudSoTinChi.Minimum = 1;
            nudSoTinChi.Maximum = 6;
            nudSoTinChi.Value = 3;

            nudDiem.Minimum = 0;
            nudDiem.Maximum = 10;
            nudDiem.DecimalPlaces = 1;
            nudDiem.Increment = 0.1m;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            using var db = new QuanLyDiemContext();

            var dsLop = db.Lops
                .OrderBy(x => x.MaLop)
                .ToList();

            lstLop.Items.Clear();
            lstLop.Items.Add("Tất cả");

            foreach (var lop in dsLop)
                lstLop.Items.Add(lop.MaLop);

            cboLop.DataSource = dsLop;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";

            lstLop.SelectedIndex = 0;

            CauHinhBang();
            TaiDanhSachSinhVien();
        }

        private void CauHinhBang()
        {
            dgvSinhVien.AutoGenerateColumns = false;
            dgvSinhVien.Columns.Clear();

            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaSV",
                HeaderText = "MSSV",
                DataPropertyName = "MaSv"
            });

            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colHoTen",
                HeaderText = "Họ tên",
                DataPropertyName = "HoTen"
            });

            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNgaySinh",
                HeaderText = "Ngày sinh",
                DataPropertyName = "NgaySinh",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy"
                }
            });

            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGioiTinh",
                HeaderText = "Giới tính",
                DataPropertyName = "GioiTinh"
            });

            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLop",
                HeaderText = "Mã lớp",
                DataPropertyName = "MaLop"
            });

            dgvDiem.AutoGenerateColumns = false;
            dgvDiem.Columns.Clear();

            dgvDiem.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaDiem",
                HeaderText = "Mã điểm",
                DataPropertyName = "MaDiem",
                Visible = false
            });

            dgvDiem.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTenMon",
                HeaderText = "Môn học",
                DataPropertyName = "TenMon"
            });

            dgvDiem.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSoTinChi",
                HeaderText = "Số TC",
                DataPropertyName = "SoTinChi"
            });

            dgvDiem.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDiem",
                HeaderText = "Điểm",
                DataPropertyName = "Diem"
            });

            dgvDiem.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSTT",
                HeaderText = "STT"
            });

            dgvSinhVien.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvDiem.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvDiem.MultiSelect = false;
            dgvDiem.ReadOnly = true;
            dgvDiem.AllowUserToAddRows = false;
            dgvDiem.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }






        private void TaiDanhSachSinhVien()
        {
            using var db = new QuanLyDiemContext();

            var query = db.SinhViens.AsNoTracking().AsQueryable();

            // Lọc theo lớp
            if (lstLop.SelectedItem != null &&
                lstLop.SelectedItem.ToString() != "Tất cả")
            {
                string maLop = lstLop.SelectedItem.ToString()!;
                query = query.Where(s => s.MaLop == maLop);
            }

            // Tìm theo MSSV hoặc họ tên
            string tuKhoa = txtTimKiem.Text.Trim();

            if (tuKhoa.Length > 0)
            {
                query = query.Where(s =>
                    s.MaSv.Contains(tuKhoa) ||
                    s.HoTen.Contains(tuKhoa));
            }

            var ds = query
                .OrderBy(s => s.MaSv)
                .Select(s => new
                {
                    s.MaSv,
                    s.HoTen,
                    s.NgaySinh,
                    s.GioiTinh,
                    s.MaLop
                })
                .ToList();

            dgvSinhVien.DataSource = ds;
        }

        private void lstLop_SelectedIndexChanged(
            object? sender, EventArgs e)
        {
            TaiDanhSachSinhVien();
        }

        private void txtTimKiem_TextChanged(
            object? sender, EventArgs e)
        {
            TaiDanhSachSinhVien();
        }

        private void dgvSinhVien_CellClick(
            object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string maSV = dgvSinhVien.Rows[e.RowIndex]
                .Cells["colMaSV"].Value?.ToString() ?? "";

            using var db = new QuanLyDiemContext();

            var sv = db.SinhViens
                .FirstOrDefault(s => s.MaSv == maSV);

            if (sv == null)
                return;

            maSVDangChon = sv.MaSv;

            txtMaSV.Text = sv.MaSv;
            txtHoTen.Text = sv.HoTen;
            dtpNgaySinh.Value = sv.NgaySinh;

            rdoNam.Checked = sv.GioiTinh == "Nam";
            rdoNu.Checked = sv.GioiTinh == "Nữ";

            cboLop.SelectedValue = sv.MaLop;

            TaiDiemSinhVien();
        }

        private void TaiDiemSinhVien()
        {
            dgvDiem.DataSource = null;

            if (string.IsNullOrWhiteSpace(maSVDangChon))
            {
                CapNhatThongKe(new List<DiemMon>());
                return;
            }

            using var db = new QuanLyDiemContext();

            var ds = db.DiemMons
                .AsNoTracking()
                .Where(d => d.MaSv == maSVDangChon)
                .OrderBy(d => d.MaDiem)
                .ToList();

            dgvDiem.DataSource = ds;

            for (int i = 0; i < dgvDiem.Rows.Count; i++)
            {
                dgvDiem.Rows[i].Cells["colSTT"].Value = i + 1;
            }

            CapNhatThongKe(ds);
        }

        private void CapNhatThongKe(List<DiemMon> ds)
        {
            int tongTinChi = ds.Sum(d => d.SoTinChi);

            lblTongTinChi.Text = $"Tổng tín chỉ: {tongTinChi}";

            if (ds.Count == 0 || tongTinChi == 0)
            {
                lblDiemTB.Text = "Điểm TB: Chưa có điểm";
                lblXepLoai.Text = "Xếp loại: Chưa có điểm";
                return;
            }

            decimal tongDiem = ds.Sum(
                d => d.Diem * d.SoTinChi);

            decimal diemTB = Math.Round(
                tongDiem / tongTinChi,
                2,
                MidpointRounding.AwayFromZero);

            string xepLoai;

            if (diemTB >= 8m)
                xepLoai = "Giỏi";
            else if (diemTB >= 7m)
                xepLoai = "Khá";
            else if (diemTB >= 5m)
                xepLoai = "Trung bình";
            else
                xepLoai = "Yếu";

            lblDiemTB.Text = $"Điểm TB: {diemTB:F2}";
            lblXepLoai.Text = $"Xếp loại: {xepLoai}";
        }

        private void dgvDiem_CellClick(
            object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dgvDiem.Rows[e.RowIndex];

            txtTenMon.Text =
                row.Cells["colTenMon"].Value?.ToString() ?? "";

            nudSoTinChi.Value = Convert.ToDecimal(
                row.Cells["colSoTinChi"].Value);

            nudDiem.Value = Convert.ToDecimal(
                row.Cells["colDiem"].Value);
        }

        private void btnThemSV_Click(object? sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim().ToUpper();
            string hoTen = txtHoTen.Text.Trim();

            if (maSV == "" || hoTen == "")
            {
                MessageBox.Show("Vui lòng nhập MSSV và họ tên!");
                return;
            }

            if (cboLop.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp!");
                return;
            }

            using var db = new QuanLyDiemContext();

            if (db.SinhViens.Any(s => s.MaSv == maSV))
            {
                MessageBox.Show("MSSV đã tồn tại!");
                return;
            }

            var sv = new SinhVien
            {
                MaSv = maSV,
                HoTen = hoTen,
                NgaySinh = dtpNgaySinh.Value,
                GioiTinh = rdoNam.Checked ? "Nam" : "Nữ",
                MaLop = cboLop.SelectedValue.ToString()!
            };

            db.SinhViens.Add(sv);
            db.SaveChanges();

            MessageBox.Show("Thêm sinh viên thành công!");

            TaiDanhSachSinhVien();
        }

        private void btnSuaSV_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maSVDangChon))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!");
                return;
            }

            string hoTen = txtHoTen.Text.Trim();

            if (hoTen == "" || cboLop.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }

            using var db = new QuanLyDiemContext();

            var sv = db.SinhViens
                .FirstOrDefault(s => s.MaSv == maSVDangChon);

            if (sv == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên!");
                return;
            }

            // Không cho thay đổi MSSV của bản ghi đã chọn
            txtMaSV.Text = sv.MaSv;

            sv.HoTen = hoTen;
            sv.NgaySinh = dtpNgaySinh.Value;
            sv.GioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
            sv.MaLop = cboLop.SelectedValue.ToString()!;

            db.SaveChanges();

            MessageBox.Show("Cập nhật sinh viên thành công!");
            TaiDanhSachSinhVien();
        }

        private void btnXoaSV_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maSVDangChon))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!");
                return;
            }

            var result = MessageBox.Show(
                "Bạn có chắc muốn xóa sinh viên và toàn bộ điểm của sinh viên này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            using var db = new QuanLyDiemContext();

            var sv = db.SinhViens
                .FirstOrDefault(s => s.MaSv == maSVDangChon);

            if (sv == null)
                return;

            var dsDiem = db.DiemMons
                .Where(d => d.MaSv == maSVDangChon)
                .ToList();

            db.DiemMons.RemoveRange(dsDiem);
            db.SinhViens.Remove(sv);

            db.SaveChanges();

            maSVDangChon = "";
            txtMaSV.Clear();
            txtHoTen.Clear();
            dgvDiem.DataSource = null;

            CapNhatThongKe(new List<DiemMon>());
            TaiDanhSachSinhVien();

            MessageBox.Show("Đã xóa sinh viên!");
        }

        private void btnThemMon_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maSVDangChon))
            {
                MessageBox.Show("Vui lòng chọn sinh viên trước!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenMon.Text))
            {
                MessageBox.Show("Vui lòng nhập tên môn học!");
                return;
            }

            using var db = new QuanLyDiemContext();

            var diem = new DiemMon
            {
                MaSv = maSVDangChon,
                TenMon = txtTenMon.Text.Trim(),
                SoTinChi = (int)nudSoTinChi.Value,
                Diem = nudDiem.Value
            };

            db.DiemMons.Add(diem);
            db.SaveChanges();

            TaiDiemSinhVien();
            MessageBox.Show("Thêm môn thành công!");
        }

        private void btnSuaDiem_Click(object? sender, EventArgs e)
        {
            if (dgvDiem.CurrentRow == null ||
                dgvDiem.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn môn cần sửa!");
                return;
            }

            int maDiem = Convert.ToInt32(
                dgvDiem.CurrentRow.Cells["colMaDiem"].Value);

            using var db = new QuanLyDiemContext();

            var diem = db.DiemMons
                .FirstOrDefault(d =>
                    d.MaDiem == maDiem &&
                    d.MaSv == maSVDangChon);

            if (diem == null)
                return;

            if (string.IsNullOrWhiteSpace(txtTenMon.Text))
            {
                MessageBox.Show("Vui lòng nhập tên môn!");
                return;
            }

            diem.TenMon = txtTenMon.Text.Trim();
            diem.SoTinChi = (int)nudSoTinChi.Value;
            diem.Diem = nudDiem.Value;

            db.SaveChanges();

            TaiDiemSinhVien();
            MessageBox.Show("Cập nhật điểm thành công!");
        }

        private void btnXoaMon_Click(object? sender, EventArgs e)
        {
            if (dgvDiem.CurrentRow == null ||
                dgvDiem.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn môn cần xóa!");
                return;
            }

            var result = MessageBox.Show(
                "Bạn có chắc muốn xóa môn học này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            int maDiem = Convert.ToInt32(
                dgvDiem.CurrentRow.Cells["colMaDiem"].Value);

            using var db = new QuanLyDiemContext();

            var diem = db.DiemMons
                .FirstOrDefault(d =>
                    d.MaDiem == maDiem &&
                    d.MaSv == maSVDangChon);

            if (diem == null)
                return;

            db.DiemMons.Remove(diem);
            db.SaveChanges();

            TaiDiemSinhVien();
            MessageBox.Show("Đã xóa môn học!");
        }

        private void btnThietKeMau_Click(object? sender, EventArgs e)
        {
            using var db = new QuanLyDiemContext();
            SinhVien? sv = null;
            List<DiemMon> dsDiem = new();

            if (!string.IsNullOrWhiteSpace(maSVDangChon))
            {
                sv = db.SinhViens.FirstOrDefault(s => s.MaSv == maSVDangChon);
                if (sv != null)
                {
                    dsDiem = db.DiemMons
                        .Where(d => d.MaSv == maSVDangChon)
                        .OrderBy(d => d.MaDiem)
                        .ToList();
                }
            }

            // Nếu chưa chọn sinh viên, dùng dữ liệu mẫu để người dùng có thể căn chỉnh trực quan trên Designer
            if (sv == null)
            {
                sv = db.SinhViens.FirstOrDefault() ?? new SinhVien
                {
                    MaSv = "SV01",
                    HoTen = "Nguyễn Văn A",
                    NgaySinh = new DateTime(2004, 1, 1),
                    GioiTinh = "Nam",
                    MaLop = "CNTT1"
                };

                if (sv != null && !string.IsNullOrEmpty(sv.MaSv))
                {
                    dsDiem = db.DiemMons.Where(d => d.MaSv == sv.MaSv).ToList();
                }

                if (dsDiem.Count == 0)
                {
                    dsDiem = new List<DiemMon>
                    {
                        new DiemMon { TenMon = "Lập trình trực quan", SoTinChi = 3, Diem = 8.5m },
                        new DiemMon { TenMon = "Cơ sở dữ liệu", SoTinChi = 3, Diem = 9.0m },
                        new DiemMon { TenMon = "Cấu trúc dữ liệu và giải thuật", SoTinChi = 4, Diem = 7.5m }
                    };
                }
            }

            FastReportService.ThietKeMau(sv!, dsDiem);
        }

        private void btnXemTruoc_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maSVDangChon))
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xem trước phiếu điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var db = new QuanLyDiemContext();
            var sv = db.SinhViens.FirstOrDefault(s => s.MaSv == maSVDangChon);
            if (sv == null)
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dsDiem = db.DiemMons
                .Where(d => d.MaSv == maSVDangChon)
                .OrderBy(d => d.MaDiem)
                .ToList();

            FastReportService.XemTruoc(sv, dsDiem);
        }

        private void btnIn_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maSVDangChon))
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để in phiếu điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var db = new QuanLyDiemContext();
            var sv = db.SinhViens.FirstOrDefault(s => s.MaSv == maSVDangChon);
            if (sv == null)
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dsDiem = db.DiemMons
                .Where(d => d.MaSv == maSVDangChon)
                .OrderBy(d => d.MaDiem)
                .ToList();

            FastReportService.InPhieu(sv, dsDiem);
        }

        private void btnCaiDatTrang_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maSVDangChon))
            {
                MessageBox.Show("Vui lòng chọn một sinh viên trước khi cài đặt trang in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var db = new QuanLyDiemContext();
            var sv = db.SinhViens.FirstOrDefault(s => s.MaSv == maSVDangChon);
            if (sv == null)
                return;

            var dsDiem = db.DiemMons
                .Where(d => d.MaSv == maSVDangChon)
                .OrderBy(d => d.MaDiem)
                .ToList();

            using var printer = new PhieuDiemPrinter(sv, dsDiem);
            printer.CaiDatTrang(this);
        }

        private void btnXuatExcel_Click(object? sender, EventArgs e)
        {
            string? lopChon = lstLop.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(lopChon))
            {
                MessageBox.Show("Vui lòng chọn một lớp trong danh sách lớp để xuất Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var db = new QuanLyDiemContext();
            var query = db.SinhViens.Include(s => s.DiemMons).AsQueryable();

            if (lopChon != "Tất cả")
            {
                query = query.Where(s => s.MaLop == lopChon);
            }

            var dsSV = query.OrderBy(s => s.MaSv).ToList();

            if (dsSV.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu sinh viên để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                FileName = lopChon == "Tất cả"
                    ? $"BangDiem_TatCaLop_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
                    : $"BangDiem_Lop_{lopChon}_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using var wb = new ClosedXML.Excel.XLWorkbook();
                var ws = wb.Worksheets.Add("DiemLop");

                // Tiêu đề bảng tính
                string tieuDeText = lopChon == "Tất cả"
                    ? "BẢNG ĐIỂM TỔNG HỢP TOÀN TRƯỜNG"
                    : $"BẢNG ĐIỂM TỔNG HỢP LỚP {lopChon}";

                ws.Cell(1, 1).Value = tieuDeText;
                ws.Range(1, 1, 1, 9).Merge();
                ws.Cell(1, 1).Style.Font.Bold = true;
                ws.Cell(1, 1).Style.Font.FontSize = 16;
                ws.Cell(1, 1).Style.Font.FontColor = ClosedXML.Excel.XLColor.DarkBlue;
                ws.Cell(1, 1).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;

                ws.Cell(2, 1).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
                ws.Range(2, 1, 2, 9).Merge();
                ws.Cell(2, 1).Style.Font.Italic = true;
                ws.Cell(2, 1).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;

                // Tiêu đề cột
                string[] headers = { "STT", "MSSV", "Họ và tên", "Ngày sinh", "Giới tính", "Lớp", "Tổng số TC", "Điểm TB", "Xếp loại" };
                int headerRow = 4;
                for (int i = 0; i < headers.Length; i++)
                {
                    var cell = ws.Cell(headerRow, i + 1);
                    cell.Value = headers[i];
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.FromHtml("#4F81BD");
                    cell.Style.Font.FontColor = ClosedXML.Excel.XLColor.White;
                    cell.Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
                    cell.Style.Alignment.Vertical = ClosedXML.Excel.XLAlignmentVerticalValues.Center;
                }

                int r = headerRow + 1;
                for (int i = 0; i < dsSV.Count; i++)
                {
                    var sv = dsSV[i];
                    int tongTC = sv.DiemMons.Sum(d => d.SoTinChi);
                    decimal tongDiem = sv.DiemMons.Sum(d => d.Diem * d.SoTinChi);
                    decimal diemTB = tongTC > 0 ? Math.Round(tongDiem / tongTC, 2, MidpointRounding.AwayFromZero) : 0m;
                    string xepLoai = "Chưa có";
                    if (sv.DiemMons.Count > 0 && tongTC > 0)
                    {
                        if (diemTB >= 8m) xepLoai = "Giỏi";
                        else if (diemTB >= 7m) xepLoai = "Khá";
                        else if (diemTB >= 5m) xepLoai = "Trung bình";
                        else xepLoai = "Yếu";
                    }

                    ws.Cell(r, 1).Value = i + 1;
                    ws.Cell(r, 2).Value = sv.MaSv;
                    ws.Cell(r, 3).Value = sv.HoTen;
                    ws.Cell(r, 4).Value = sv.NgaySinh.ToString("dd/MM/yyyy");
                    ws.Cell(r, 5).Value = sv.GioiTinh;
                    ws.Cell(r, 6).Value = sv.MaLop;
                    ws.Cell(r, 7).Value = tongTC;
                    ws.Cell(r, 8).Value = tongTC > 0 ? (double)diemTB : 0;
                    ws.Cell(r, 9).Value = xepLoai;

                    ws.Cell(r, 1).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
                    ws.Cell(r, 2).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
                    ws.Cell(r, 4).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
                    ws.Cell(r, 5).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
                    ws.Cell(r, 6).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
                    ws.Cell(r, 7).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
                    ws.Cell(r, 8).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Right;
                    ws.Cell(r, 8).Style.NumberFormat.Format = "0.00";
                    ws.Cell(r, 9).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;

                    r++;
                }

                // Định dạng viền bảng
                var dataRange = ws.Range(headerRow, 1, r - 1, headers.Length);
                dataRange.Style.Border.OutsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
                dataRange.Style.Border.InsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;

                ws.Columns().AdjustToContents();

                wb.SaveAs(sfd.FileName);

                var dr = MessageBox.Show(
                    "Xuất dữ liệu Excel thành công!\nBạn có muốn mở file vừa xuất không?",
                    "Thành công",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(sfd.FileName)
                    {
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
