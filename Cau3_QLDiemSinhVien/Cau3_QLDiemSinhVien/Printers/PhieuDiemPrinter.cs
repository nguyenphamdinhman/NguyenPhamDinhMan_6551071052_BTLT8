using System.Drawing.Printing;
using Cau3_QLDiemSinhVien.Models;

namespace Cau3_QLDiemSinhVien.Printers
{
    public sealed class PhieuDiemPrinter : IDisposable
    {
        private readonly SinhVien _sv;
        private readonly List<DiemMon> _dsDiem;
        private readonly PrintDocument _doc = new();

        private readonly Font _fTieuDe = new("Segoe UI", 16, FontStyle.Bold);
        private readonly Font _fTieuDePhu = new("Segoe UI", 10, FontStyle.Bold);
        private readonly Font _fDam = new("Segoe UI", 10, FontStyle.Bold);
        private readonly Font _fThuong = new("Segoe UI", 10, FontStyle.Regular);
        private readonly Font _fNho = new("Segoe UI", 9, FontStyle.Italic);

        private static readonly StringFormat FormatTrai = new()
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center,
            Trimming = StringTrimming.EllipsisCharacter
        };
        private static readonly StringFormat FormatGiua = new()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center,
            Trimming = StringTrimming.EllipsisCharacter
        };
        private static readonly StringFormat FormatPhai = new()
        {
            Alignment = StringAlignment.Far,
            LineAlignment = StringAlignment.Center,
            Trimming = StringTrimming.EllipsisCharacter
        };

        private int _dongHienTai = 0;

        public PhieuDiemPrinter(SinhVien sv, List<DiemMon> dsDiem)
        {
            _sv = sv;
            _dsDiem = dsDiem;

            _doc.DocumentName = $"PhieuDiem_{sv.MaSv}";
            _doc.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);

            _doc.BeginPrint += (s, e) => _dongHienTai = 0;
            _doc.PrintPage += OnPrintPage;
        }

        public void XemTruoc(IWin32Window owner)
        {
            using var dlg = new PrintPreviewDialog
            {
                Document = _doc,
                UseAntiAlias = true,
                StartPosition = FormStartPosition.CenterParent,
                Size = new Size(950, 750)
            };
            dlg.ShowDialog(owner);
        }

        public void InCoHopThoai(IWin32Window owner)
        {
            using var dlg = new PrintDialog
            {
                Document = _doc,
                UseEXDialog = true
            };
            if (dlg.ShowDialog(owner) == DialogResult.OK)
            {
                _doc.Print();
            }
        }

        public void CaiDatTrang(IWin32Window owner)
        {
            using var dlg = new PageSetupDialog
            {
                Document = _doc,
                AllowPrinter = true
            };
            dlg.ShowDialog(owner);
        }

        private void OnPrintPage(object? sender, PrintPageEventArgs e)
        {
            var g = e.Graphics!;
            var m = e.MarginBounds;
            float x = m.Left;
            float y = m.Top;
            float w = m.Width;

            // 1. Tiêu đề trường / đơn vị
            g.DrawString("KHOA CÔNG NGHỆ THÔNG TIN", _fTieuDePhu, Brushes.Black, new RectangleF(x, y, w / 2, 22), FormatTrai);
            y += 30;

            // 2. Tiêu đề chính
            g.DrawString("PHIẾU BÁO ĐIỂM", _fTieuDe, Brushes.Black, new RectangleF(x, y, w, 32), FormatGiua);
            y += 40;

            // 3. Thông tin sinh viên
            float nuaW = w / 2;
            g.DrawString($"Mã sinh viên: {_sv.MaSv}", _fDam, Brushes.Black, new RectangleF(x, y, nuaW, 24), FormatTrai);
            y += 24;
            g.DrawString($"Họ và tên: {_sv.HoTen}", _fDam, Brushes.Black, new RectangleF(x , y, nuaW, 24), FormatTrai);
            y += 24;

            g.DrawString($"Ngày sinh: {_sv.NgaySinh:dd/MM/yyyy}", _fThuong, Brushes.Black, new RectangleF(x, y, nuaW, 24), FormatTrai);
            
            y += 24;

            g.DrawString($"Lớp: {_sv.MaLop}", _fThuong, Brushes.Black, new RectangleF(x, y, nuaW, 24), FormatTrai);
            y += 35;

            // 4. Bảng điểm môn học
            float colSTT = 50;
            float colTC = 90;
            float colDiem = 100;
            float colTen = w - (colSTT + colTC + colDiem);
            float rowHeight = 28;

            // Header bảng
            using var brushHeaderBg = new SolidBrush(Color.FromArgb(235, 240, 250));
            using var penBorder = new Pen(Color.Black, 1);

            g.FillRectangle(brushHeaderBg, x, y, w, rowHeight);
            g.DrawRectangle(penBorder, x, y, w, rowHeight);

            float cx = x;
            g.DrawRectangle(penBorder, cx, y, colSTT, rowHeight);
            g.DrawString("STT", _fDam, Brushes.Black, new RectangleF(cx, y, colSTT, rowHeight), FormatGiua);
            cx += colSTT;

            g.DrawRectangle(penBorder, cx, y, colTen, rowHeight);
            g.DrawString("Tên môn học", _fDam, Brushes.Black, new RectangleF(cx + 8, y, colTen - 8, rowHeight), FormatTrai);
            cx += colTen;

            g.DrawRectangle(penBorder, cx, y, colTC, rowHeight);
            g.DrawString("Số TC", _fDam, Brushes.Black, new RectangleF(cx, y, colTC, rowHeight), FormatGiua);
            cx += colTC;

            g.DrawRectangle(penBorder, cx, y, colDiem, rowHeight);
            g.DrawString("Điểm", _fDam, Brushes.Black, new RectangleF(cx, y, colDiem, rowHeight), FormatGiua);

            y += rowHeight;

            // Dòng dữ liệu
            int stt = 1;
            while (_dongHienTai < _dsDiem.Count)
            {
                if (y + rowHeight > m.Bottom - 120)
                {
                    e.HasMorePages = true;
                    return;
                }

                var d = _dsDiem[_dongHienTai];
                cx = x;

                g.DrawRectangle(penBorder, cx, y, colSTT, rowHeight);
                g.DrawString(stt.ToString(), _fThuong, Brushes.Black, new RectangleF(cx, y, colSTT, rowHeight), FormatGiua);
                cx += colSTT;

                g.DrawRectangle(penBorder, cx, y, colTen, rowHeight);
                g.DrawString(d.TenMon, _fThuong, Brushes.Black, new RectangleF(cx + 8, y, colTen - 8, rowHeight), FormatTrai);
                cx += colTen;

                g.DrawRectangle(penBorder, cx, y, colTC, rowHeight);
                g.DrawString(d.SoTinChi.ToString(), _fThuong, Brushes.Black, new RectangleF(cx, y, colTC, rowHeight), FormatGiua);
                cx += colTC;

                g.DrawRectangle(penBorder, cx, y, colDiem, rowHeight);
                g.DrawString(d.Diem.ToString("F1"), _fThuong, Brushes.Black, new RectangleF(cx, y, colDiem, rowHeight), FormatGiua);

                y += rowHeight;
                stt++;
                _dongHienTai++;
            }

            e.HasMorePages = false;

            // 5. Tổng kết
            y += 15;
            int tongTinChi = _dsDiem.Sum(d => d.SoTinChi);
            decimal tongDiem = _dsDiem.Sum(d => d.Diem * d.SoTinChi);
            decimal diemTB = tongTinChi > 0 ? Math.Round(tongDiem / tongTinChi, 2, MidpointRounding.AwayFromZero) : 0m;
            string xepLoai = "Chưa có";
            if (_dsDiem.Count > 0 && tongTinChi > 0)
            {
                if (diemTB >= 8m) xepLoai = "Giỏi";
                else if (diemTB >= 7m) xepLoai = "Khá";
                else if (diemTB >= 5m) xepLoai = "Trung bình";
                else xepLoai = "Yếu";
            }

            g.DrawString($"Tổng số tín chỉ: {tongTinChi}", _fDam, Brushes.Black, x, y);
            y += 24;
            g.DrawString($"Điểm trung bình tích lũy: {(tongTinChi > 0 ? diemTB.ToString("F2") : "Chưa có")}", _fDam, Brushes.Black, x, y);
            y += 24;
            g.DrawString($"Xếp loại học lực: {xepLoai}", _fDam, Brushes.Black, x, y);
            y += 30;

            // 6. Chữ ký
            float cotKyW = 250;
            float xKy = m.Right - cotKyW;
            g.DrawString("Giáo vụ Khoa", _fDam, Brushes.Black, new RectangleF(x, y, nuaW, 24), FormatTrai);
            y += 18;
            g.DrawString("(Ký, ghi rõ họ tên)", _fNho, Brushes.Black, new RectangleF(x, y, nuaW, 24), FormatTrai);

            g.DrawString("Sinh Viên", _fDam, Brushes.Black, new RectangleF(xKy, y, cotKyW, 20), FormatGiua);
            y += 18;
            g.DrawString("(Ký, ghi rõ họ tên)", _fNho, Brushes.Black, new RectangleF(xKy, y, cotKyW, 20), FormatGiua);
        }

        public void Dispose()
        {
            _doc.Dispose();
            _fTieuDe.Dispose();
            _fTieuDePhu.Dispose();
            _fDam.Dispose();
            _fThuong.Dispose();
            _fNho.Dispose();
        }
    }
}
