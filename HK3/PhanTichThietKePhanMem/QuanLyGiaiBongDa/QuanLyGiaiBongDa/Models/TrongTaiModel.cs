/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 25/03/2017 - TrongTaiModel.cs
 */
using QuanLyGiaiBongDa.Common;
using System;
using System.Data;

namespace QuanLyGiaiBongDa.Models
{
    public class TrongTaiModel : BaseModel
    {
        string _MaTrongTai;

        public string MaTrongTai
        {
            get { return _MaTrongTai; }
            set { _MaTrongTai = value; }
        }
        string _TenTrongTai;

        public string TenTrongTai
        {
            get { return _TenTrongTai; }
            set { _TenTrongTai = value; }
        }
        DateTime _NgaySinh = DateTime.Now;

        public DateTime NgaySinh
        {
            get { return _NgaySinh; }
            set { _NgaySinh = value; }
        }
        string _GioiTinh;

        public string GioiTinh
        {
            get { return _GioiTinh; }
            set { _GioiTinh = value; }
        }
        string _BangCap;

        public string BangCap
        {
            get { return _BangCap; }
            set { _BangCap = value; }
        }

        public override void DataMap(IDataReader reader)
        {
            if (ColumnExists(reader, "MaTrongTai")) this.MaTrongTai = Convert.ToString(reader["MaTrongTai"]);
            if (ColumnExists(reader, "TenTrongTai")) this.TenTrongTai = Convert.ToString(reader["TenTrongTai"]);
            if (ColumnExists(reader, "NgaySinh")) this.NgaySinh =
                    reader["NgaySinh"] == DBNull.Value ? this.NgaySinh : Convert.ToDateTime(reader["NgaySinh"]);
            if (ColumnExists(reader, "GioiTinh")) this.GioiTinh = Convert.ToString(reader["GioiTinh"]);
            if (ColumnExists(reader, "BangCap")) this.BangCap = Convert.ToString(reader["BangCap"]);
        }
    }
}
