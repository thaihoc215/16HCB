using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1642021.Models
{
    public class GiaoDichModel
    {
        public int MaGiaoDich { get; set; }
        public int MaThe { get; set; }
        public string TenChuThe { get; set; }
        public DateTime ThoiDiemGiaoDich { get; set; }
        public double SoTienGiaoDich { get; set; }
        public int LoaiGiaoDich { get; set; }
        public string TenGiaoDich { get; set; }

        public GiaoDichModel(GiaoDich gd)
        {
            MaGiaoDich = gd.MaGiaoDich;
            MaThe = gd.TaiKhoan;
            SoTienGiaoDich = gd.SoTienGiaoDich;
            ThoiDiemGiaoDich = gd.ThoiDiemGiaoDich;
            LoaiGiaoDich = gd.LoaiGiaoDich;
        }
    }
}