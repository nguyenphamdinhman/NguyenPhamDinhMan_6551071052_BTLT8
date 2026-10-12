using FastReport;
using FastReport.Data;
using Cau3_QLDiemSinhVien.Models;

namespace Cau3_QLDiemSinhVien.Services
{
    public class DiemMonReportItem
    {
        public int STT { get; set; }
        public string TenMon { get; set; } = "";
        public int SoTinChi { get; set; }
        public decimal Diem { get; set; }
    }

    public static class FastReportService
    {
        public const string TenFileFrx = "PhieuDiem.frx";

        public static string ThuMucReport { get; } = TimThuMucReport();

        public static string DuongDanReport => Path.Combine(ThuMucReport, TenFileFrx);

        private static string TimThuMucReport()
        {
            var dir = new DirectoryInfo(AppContext.BaseDirectory);
            while (dir != null)
            {
                if (dir.GetFiles("*.csproj").Length > 0)
                {
                    var p = Path.Combine(dir.FullName, "Reports");
                    Directory.CreateDirectory(p);
                    return p;
                }
                dir = dir.Parent;
            }

            var macDinh = Path.Combine(AppContext.BaseDirectory, "Reports");
            Directory.CreateDirectory(macDinh);
            return macDinh;
        }

        public static Report TaoReport(SinhVien sv, List<DiemMon> dsDiem)
        {
            var report = new Report();
            string path = DuongDanReport;

            if (File.Exists(path))
            {
                report.Load(path);
            }
            else
            {
                var page = new ReportPage();
                report.Pages.Add(page);
                page.CreateUniqueName();
            }

            report.FileName = path;
            report.DoublePass = true;

            // Chuyển đổi dữ liệu môn học
            var dsItem = dsDiem.Select((d, index) => new DiemMonReportItem
            {
                STT = index + 1,
                TenMon = d.TenMon,
                SoTinChi = d.SoTinChi,
                Diem = d.Diem
            }).ToList();

            report.RegisterData(dsItem, "DiemMon");
            var ds = report.GetDataSource("DiemMon");
            if (ds != null)
                ds.Enabled = true;

            // Tính toán tổng kết
            int tongTinChi = dsDiem.Sum(d => d.SoTinChi);
            decimal tongDiem = dsDiem.Sum(d => d.Diem * d.SoTinChi);
            decimal diemTB = tongTinChi > 0 ? Math.Round(tongDiem / tongTinChi, 2, MidpointRounding.AwayFromZero) : 0m;
            string xepLoai = "Chưa có";
            if (dsDiem.Count > 0 && tongTinChi > 0)
            {
                if (diemTB >= 8m) xepLoai = "Giỏi";
                else if (diemTB >= 7m) xepLoai = "Khá";
                else if (diemTB >= 5m) xepLoai = "Trung bình";
                else xepLoai = "Yếu";
            }

            // Đặt các tham số
            DatThamSo(report, "MaSV", sv.MaSv);
            DatThamSo(report, "HoTen", sv.HoTen);
            DatThamSo(report, "NgaySinh", sv.NgaySinh.ToString("dd/MM/yyyy"));
            DatThamSo(report, "GioiTinh", sv.GioiTinh);
            DatThamSo(report, "MaLop", sv.MaLop);
            DatThamSo(report, "TongTinChi", tongTinChi);
            DatThamSo(report, "DiemTB", tongTinChi > 0 ? diemTB.ToString("0.00") : "Chưa có");
            DatThamSo(report, "XepLoai", xepLoai);
            DatThamSo(report, "NgayIn", $"Ngày {DateTime.Now:dd} tháng {DateTime.Now:MM} năm {DateTime.Now:yyyy}");

            return report;
        }

        private static void DatThamSo(Report report, string ten, object? giaTri)
        {
            var p = report.GetParameter(ten);
            if (p == null)
            {
                p = new Parameter { Name = ten };
                report.Dictionary.Parameters.Add(p);
            }
            p.Value = giaTri;
        }

        public static void ThietKeMau(SinhVien sv, List<DiemMon> dsDiem)
        {
            using var report = TaoReport(sv, dsDiem);
            report.Design(true);
        }

        public static void XemTruoc(SinhVien sv, List<DiemMon> dsDiem)
        {
            using var report = TaoReport(sv, dsDiem);
            if (report.Prepare())
            {
                report.ShowPrepared(true);
            }
        }

        public static void InPhieu(SinhVien sv, List<DiemMon> dsDiem)
        {
            using var report = TaoReport(sv, dsDiem);
            report.Prepare();
            report.PrintSettings.ShowDialog = true;
            report.Print();
        }
    }
}
