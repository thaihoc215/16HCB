/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 25/03/2017 - SanVanDongModel.cs
 */
using QuanLyGiaiBongDa.Common;
using System;
using System.Data;

namespace QuanLyGiaiBongDa.Models
{
    public class SanVanDongModel : BaseModel
    {
        string _MaSan;

        public string MaSan
        {
            get { return _MaSan; }
            set { _MaSan = value; }
        }
        string _TenSan;

        public string TenSan
        {
            get { return _TenSan; }
            set { _TenSan = value; }
        }
        string _DoiBongSoHuu;

        public string DoiBongSoHuu
        {
            get { return _DoiBongSoHuu; }
            set { _DoiBongSoHuu = value; }
        }

        string _TenDoi;

        public string TenDoi
        {
            get { return _TenDoi; }
            set { _TenDoi = value; }
        }
        DateTime _NgayKhanhThanh = DateTime.Now;

        public DateTime NgayKhanhThanh
        {
            get { return _NgayKhanhThanh; }
            set { _NgayKhanhThanh = value; }
        }
        int _SucChua;

        public int SucChua
        {
            get { return _SucChua; }
            set { _SucChua = value; }
        }
        double _KichThuoc;

        public double KichThuoc
        {
            get { return _KichThuoc; }
            set { _KichThuoc = value; }
        }

        public override void DataMap(IDataReader reader)
        {
            if (ColumnExists(reader, "MaSan")) this.MaSan = Convert.ToString(reader["MaSan"]);
            if (ColumnExists(reader, "TenSan")) this.TenSan = Convert.ToString(reader["TenSan"]);
            if (ColumnExists(reader, "DoiBongSoHuu")) this.DoiBongSoHuu = Convert.ToString(reader["DoiBongSoHuu"]);
            if (ColumnExists(reader, "TenDoi")) this.TenDoi = Convert.ToString(reader["TenDoi"]);
            if (ColumnExists(reader, "NgayKhanhThanh")) this.NgayKhanhThanh =
                    reader["NgayKhanhThanh"] == DBNull.Value ? this.NgayKhanhThanh : Convert.ToDateTime(reader["NgayKhanhThanh"]);
            if (ColumnExists(reader, "SucChua")) this.SucChua =
                    reader["SucChua"] == DBNull.Value ? this.SucChua : Convert.ToInt32(reader["SucChua"]);
            if (ColumnExists(reader, "KichThuoc")) this._KichThuoc =
                    reader["KichThuoc"] == DBNull.Value ? this.KichThuoc : Convert.ToDouble(reader["KichThuoc"]);
        }
    }
}
