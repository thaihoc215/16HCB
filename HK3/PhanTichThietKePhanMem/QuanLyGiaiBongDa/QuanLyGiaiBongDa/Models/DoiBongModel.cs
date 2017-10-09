/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 01/04/2017 - DoiBongModel.cs
 */
using QuanLyGiaiBongDa.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiBongDa.Models
{
    public class DoiBongModel : BaseModel
    {
        private string _MaDoi = "";

        public string MaDoi
        {
            get { return _MaDoi; }
            set { _MaDoi = value; }
        }
        private string _TenDoi = "";

        public string TenDoi
        {
            get { return _TenDoi; }
            set { _TenDoi = value; }
        }
        private DateTime _NamThanhLap = DateTime.Now;

        public DateTime NamThanhLap
        {
            get { return _NamThanhLap; }
            set { _NamThanhLap = value; }
        }
        private string _SanVanDong = "";

        public string SanVanDong
        {
            get { return _SanVanDong; }
            set { _SanVanDong = value; }
        }
        private string _ChuTich = "";

        public string ChuTich
        {
            get { return _ChuTich; }
            set { _ChuTich = value; }
        }
        private string _HuanLuyenVien = "";

        public string HuanLuyenVien
        {
            get { return _HuanLuyenVien; }
            set { _HuanLuyenVien = value; }
        }
        private int _DoiTruong;

        public int DoiTruong
        {
            get { return _DoiTruong; }
            set { _DoiTruong = value; }
        }
        private string _TenCauThu;//Ten doi truong

        public string TenCauThu
        {
            get { return _TenCauThu; }
            set { _TenCauThu = value; }
        }

        string _DiaChi = "";

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }

        string _SoDienThoai = "";

        public string SoDienThoai
        {
            get { return _SoDienThoai; }
            set { _SoDienThoai = value; }
        }

        string _Logo = "";

        public string Logo
        {
            get { return _Logo; }
            set { _Logo = value; }
        }

        public DoiBongModel(string optMaDoi = "")
        {
            MaDoi = optMaDoi;
        }
        public override void DataMap(IDataReader reader)
        {
            if (ColumnExists(reader, "MaDoi")) this.MaDoi = Convert.ToString(reader["MaDoi"]);
            if (ColumnExists(reader, "TenDoi")) this.TenDoi = Convert.ToString(reader["TenDoi"]);
            if (ColumnExists(reader, "NamThanhLap")) this.NamThanhLap =
                    reader["NamThanhLap"] == DBNull.Value ? this.NamThanhLap : Convert.ToDateTime(reader["NamThanhLap"]);
            if (ColumnExists(reader, "SanVanDong")) this.SanVanDong = Convert.ToString(reader["SanVanDong"]);
            if (ColumnExists(reader, "ChuTich")) this.ChuTich = Convert.ToString(reader["ChuTich"]);
            if (ColumnExists(reader, "HuanLuyenVien")) this.HuanLuyenVien = Convert.ToString(reader["HuanLuyenVien"]);
            if (ColumnExists(reader, "DoiTruong")) this.DoiTruong =
                    reader["DoiTruong"] == DBNull.Value ? this.DoiTruong : Convert.ToInt32(reader["DoiTruong"]);
            if (ColumnExists(reader, "TenCauThu")) this.TenCauThu = Convert.ToString(reader["TenCauThu"]);
            if (ColumnExists(reader, "DiaChi")) this.DiaChi = Convert.ToString(reader["DiaChi"]);
            if (ColumnExists(reader, "SoDienThoai")) this.SoDienThoai = Convert.ToString(reader["SoDienThoai"]);
            if (ColumnExists(reader, "Logo")) this.Logo = Convert.ToString(reader["Logo"]);
        }
    }
}
