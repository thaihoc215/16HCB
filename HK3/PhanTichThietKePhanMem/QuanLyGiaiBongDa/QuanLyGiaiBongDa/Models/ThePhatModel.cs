/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 26/03/2017 - ThePhatModel.cs
 */
using QuanLyGiaiBongDa.Common;
using System;
using System.Data;

namespace QuanLyGiaiBongDa.Models
{
    public class ThePhatModel : BaseModel
    {
        private int _MaThePhat;

        public int MaThePhat
        {
            get { return _MaThePhat; }
            set { _MaThePhat = value; }
        }
        private string _LoaiThe = string.Empty;

        public string LoaiThe
        {
            get { return _LoaiThe; }
            set { _LoaiThe = value; }
        }

        private string _TenLoai = string.Empty;

        public string TenLoai
        {
            get { return _TenLoai; }
            set { _TenLoai = value; }
        }
        private int _CauThu;
        //
        public int CauThu
        {
            get { return _CauThu; }
            set { _CauThu = value; }
        }

        string _HoTen = string.Empty;
        public string HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; }
        }
        private string _TrongTai = string.Empty;

        public string TrongTai
        {
            get { return _TrongTai; }
            set { _TrongTai = value; }
        }

        private string _tenTrongTai = string.Empty;
        public string TenTrongTai
        {
            get
            {
                return _tenTrongTai;
            }

            set
            {
                _tenTrongTai = value;
            }
        }

        private int _ThoiDiem;

        public int ThoiDiem
        {
            get { return _ThoiDiem; }
            set { _ThoiDiem = value; }
        }
        private string _TranDau = string.Empty;
        public string TranDau
        {
            get { return _TranDau; }
            set { _TranDau = value; }
        }



        public override void DataMap(IDataReader reader)
        {
            if (ColumnExists(reader, "MaThePhat")) this.MaThePhat = Convert.ToInt32(reader["MaThePhat"]);
            if (ColumnExists(reader, "LoaiThe")) this.LoaiThe = Convert.ToString(reader["LoaiThe"]);
            if (ColumnExists(reader, "TenLoai")) this.TenLoai = Convert.ToString(reader["TenLoai"]);
            if (ColumnExists(reader, "CauThu")) this.CauThu =
                    reader["CauThu"] == DBNull.Value ? this.CauThu : Convert.ToInt32(reader["CauThu"]);
            if (ColumnExists(reader, "HoTen")) this.HoTen = Convert.ToString(reader["HoTen"]);
            if (ColumnExists(reader, "TrongTai")) this.TrongTai = Convert.ToString(reader["TrongTai"]);
            if (ColumnExists(reader, "TenTrongTai")) this.TenTrongTai = Convert.ToString(reader["TenTrongTai"]);
            if (ColumnExists(reader, "ThoiDiem")) this.ThoiDiem =
                    reader["ThoiDiem"] == DBNull.Value ? this.ThoiDiem : Convert.ToInt32(reader["ThoiDiem"]);
            if (ColumnExists(reader, "TranDau")) this.TranDau = Convert.ToString(reader["TranDau"]);
        }
    }
}
