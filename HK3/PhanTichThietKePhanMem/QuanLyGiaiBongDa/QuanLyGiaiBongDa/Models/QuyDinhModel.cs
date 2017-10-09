using QuanLyGiaiBongDa.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiBongDa.Models
{
    public class QuyDinhModel :BaseModel
    {
        int _TuoiMin;
        public int TuoiMin
        {
            get { return _TuoiMin; }
            set { _TuoiMin = value; }
        }

        int _TuoiMax;
        public int TuoiMax
        {
            get { return _TuoiMax; }
            set { _TuoiMax = value; }
        }

        int _SoLuongMin;
        public int SoLuongMin
        {
            get { return _SoLuongMin; }
            set { _SoLuongMin = value; }
        }

        int _SoLuongMax;
        public int SoLuongMax
        {
            get { return _SoLuongMax; }
            set { _SoLuongMax = value; }
        }

        int _CTNgoai;
        public int CTNgoai
        {
            get { return _CTNgoai; }
            set { _CTNgoai = value; }
        }

        int _TDGhiBan;
        public int TDGhiBan
        {
            get { return _TDGhiBan; }
            set { _TDGhiBan = value; }
        }

        int _Thang;
        public int Thang
        {
            get { return _Thang; }
            set { _Thang = value; }
        }

        int _Hoa;
        public int Hoa
        {
            get { return _Hoa; }
            set { _Hoa = value; }
        }

        int _Thua;
        public int Thua
        {
            get { return _Thua; }
            set { _Thua = value; }
        }
    }
}
