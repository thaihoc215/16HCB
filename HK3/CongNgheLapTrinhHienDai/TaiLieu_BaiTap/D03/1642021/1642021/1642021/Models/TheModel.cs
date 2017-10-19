namespace _1642021.Models
{
    public class TheModel
    {
        public int MaThe { get; set; }
        public string TenChuThe { get; set; }
        public System.DateTime NgayHetHan { get; set; }
        public double SoDuKhaDung { get; set; }
        public int NganHang { get; set; }
        public string MatKhau { get; set; }
        public string TenNganHang { get; set; }
        public TheModel()
        {

        }
        public TheModel(The the)
        {
            MaThe = the.MaThe;
            MatKhau = the.MatKhau;
            TenChuThe = the.TenChuThe;
            NgayHetHan = the.NgayHetHan;
            SoDuKhaDung = the.SoDuKhaDung;
            NganHang = (int)the.NganHang;
        }
    }
}