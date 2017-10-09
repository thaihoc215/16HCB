/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 25/03/2017 - BanThangModel.cs
 */
using QuanLyGiaiBongDa.Common;
using System;
using System.Data;

namespace QuanLyGiaiBongDa.Models
{
    public class BanThangModel : BaseModel
    {
        //9
        string _MaBanThang;

        public string MaBanThang
        {
            get { return _MaBanThang; }
            set { _MaBanThang = value; }
        }
        int _MaCauThu;

        public int MaCauThu
        {
            get { return _MaCauThu; }
            set { _MaCauThu = value; }
        }
        string _HoTen;

        public string HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; }
        }
        int _SoAo;

        public int SoAo
        {
            get { return _SoAo; }
            set { _SoAo = value; }
        }
        string _LoaiBanThang = "";

        public string LoaiBanThang
        {
            get { return _LoaiBanThang; }
            set { _LoaiBanThang = value; }
        }

        string _TenLoai = "";
        public string TenLoai
        {
            get { return _TenLoai; }
            set { _TenLoai = value; }
        }

        string _DoiBong = "";//Ma doi bong
        public string DoiBong
        {
            get { return _DoiBong; }
            set { _DoiBong = value; }
        }

        string _TenDoi ="";
        public string TenDoi
        {
            get { return _TenDoi; }
            set { _TenDoi = value; }
        }
        string _TranDau = "";
        public string TranDau
        {
            get { return _TranDau; }
            set { _TranDau = value; }
        }

        int _ThoiDiem;
        public int ThoiDiem
        {
            get { return _ThoiDiem; }
            set { _ThoiDiem = value; }
        }

        int _SoBanThang;
        public int SoBanThang
        {
            get { return _SoBanThang; }
            set { _SoBanThang = value; }
        }
        public override void DataMap(IDataReader reader)
        {
            //9
            if (ColumnExists(reader, "MaBanThang")) this.MaBanThang = Convert.ToString(reader["MaBanThang"]);
            if (ColumnExists(reader, "MaCauThu")) this.MaCauThu =
                    reader["MaCauThu"] == DBNull.Value ? this.MaCauThu : Convert.ToInt32(reader["MaCauThu"]);
            if (ColumnExists(reader, "HoTen")) this.HoTen = Convert.ToString(reader["HoTen"]);
            if (ColumnExists(reader, "SoAo")) this.SoAo =
                    reader["SoAo"] == DBNull.Value ? this.SoAo : Convert.ToInt32(reader["SoAo"]);
            if (ColumnExists(reader, "LoaiBanThang")) this.LoaiBanThang = Convert.ToString(reader["LoaiBanThang"]);
            if (ColumnExists(reader, "TenLoai")) this.TenLoai = Convert.ToString(reader["TenLoai"]);
            if (ColumnExists(reader, "MaDoi")) this.DoiBong = Convert.ToString(reader["MaDoi"]);
            if (ColumnExists(reader, "TenDoi")) this.TenDoi = Convert.ToString(reader["TenDoi"]);
            if (ColumnExists(reader, "TranDau")) this.TranDau = Convert.ToString(reader["TranDau"]);
            if (ColumnExists(reader, "ThoiDiem")) this.ThoiDiem =
                    reader["ThoiDiem"] == DBNull.Value ? this.ThoiDiem : Convert.ToInt32(reader["ThoiDiem"]);
            if (ColumnExists(reader, "SoBanThang")) this.SoBanThang =
                    reader["SoBanThang"] == DBNull.Value ? this.SoBanThang : Convert.ToInt32(reader["SoBanThang"]);
        }
    }
}
