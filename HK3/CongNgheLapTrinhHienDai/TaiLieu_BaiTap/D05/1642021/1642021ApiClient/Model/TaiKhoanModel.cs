using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1642021ApiClient.Model
{
    public class TaiKhoanModel
    {
        public int MaThe { get; set; }
        public string TenChuThe { get; set; }
        public System.DateTime NgayHetHan { get; set; }
        public double SoDuKhaDung { get; set; }
        public int NganHang { get; set; }
        public string MatKhau { get; set; }
        public string TenNganHang { get; set; }
        public TaiKhoanModel()
        {

        }
        public TaiKhoanModel(TaiKhoanModel the)
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
