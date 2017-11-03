using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1642021ApiClient.Model
{
    public class GiaoDichModel
    {
        public int MaGiaoDich { get; set; }
        public int MaThe { get; set; }
        public DateTime ThoiDiemGiaoDich { get; set; }
        public double SoTienGiaoDich { get; set; }
        public int LoaiGiaoDich { get; set; }
        public string TenLoai { get; set; }

        public GiaoDichModel(GiaoDichModel gd)
        {
            //MaGiaoDich = gd.MaGiaoDich;
            //MaThe = gd.MaThe;
            //SoTienGiaoDich = gd.SoTienGiaoDich;
            //ThoiDiemGiaoDich = gd.ThoiDiemGiaoDich;
            //LoaiGiaoDich = gd.LoaiGiaoDich;
        }
    }
}
