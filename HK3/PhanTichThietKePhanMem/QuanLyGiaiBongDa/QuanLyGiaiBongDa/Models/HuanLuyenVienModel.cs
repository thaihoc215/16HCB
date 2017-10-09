/*
 * 1642051 - Nguyen Xuan Phuc
 * HuanLuyenVienModel.cs
 */

using QuanLyGiaiBongDa.Common;
using System;
using System.Data;

namespace QuanLyGiaiBongDa.Models
{
    public class HuanLuyenVienModel : BaseModel
    {
        string _MaHLV = string.Empty;
        string _TenHLV = string.Empty;
        DateTime _NgaySinh = DateTime.Now;
        string _GioiTinh = string.Empty;
        string _DoiBong = string.Empty;
        string _TenDoi = string.Empty;
        string _TroLy = string.Empty;

        public string MaHLV
        {
            get { return _MaHLV; }
            set { _MaHLV = value; }
        }

        public string TenHLV
        {
            get { return _TenHLV; }
            set { _TenHLV = value; }
        }

        public DateTime NgaySinh
        {
            get { return _NgaySinh; }
            set { _NgaySinh = value; }
        }

        public string GioiTinh
        {
            get { return _GioiTinh; }
            set { _GioiTinh = value; }
        }

        public string DoiBong
        {
            get { return _DoiBong; }
            set { _DoiBong = value; }
        }

        public string TenDoi
        {
            get { return _TenDoi; }
            set { _TenDoi = value; }
        }

        public string TroLy
        {
            get { return _TroLy; }
            set { _TroLy = value; }
        }

        public override void DataMap(IDataReader reader)
        {
            if (ColumnExists(reader, "MaHLV"))
                this.MaHLV = Convert.ToString(reader["MaHLV"]);
            if (ColumnExists(reader, "TenHLV"))
                this.TenHLV = Convert.ToString(reader["TenHLV"]);
            if (ColumnExists(reader, "NgaySinh"))
                this.NgaySinh = reader["NgaySinh"] == DBNull.Value ? this.NgaySinh : Convert.ToDateTime(reader["NgaySinh"]);//
            if (ColumnExists(reader, "GioiTinh"))
                this.GioiTinh = Convert.ToString(reader["GioiTinh"]);
            if (ColumnExists(reader, "DoiBong"))
                this.DoiBong = Convert.ToString(reader["DoiBong"]);
            if (ColumnExists(reader, "TenDoi"))
                this.TenDoi = Convert.ToString(reader["TenDoi"]);
            if (ColumnExists(reader, "TroLy"))
                this.TroLy = Convert.ToString(reader["TroLy"]);
        }
    }
}
