/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 25/03/2017 - CauThuModel.cs
 */
using QuanLyGiaiBongDa.Common;
using System;
using System.Data;

namespace QuanLyGiaiBongDa.Models
{
    public class CauThuModel : BaseModel
    {
        int _MaCauThu;

        public int MaCauThu
        {
            get { return _MaCauThu; }
            set { _MaCauThu = value; }
        }
        int _SoAo = 1;

        public int SoAo
        {
            get { return _SoAo; }
            set { _SoAo = value; }
        }
        string _HoTen = "";

        public string HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; }
        }
        string _QuocTich = "";

        public string QuocTich
        {
            get { return _QuocTich; }
            set { _QuocTich = value; }
        }
        int _ViTri;

        public int ViTri
        {
            get { return _ViTri; }
            set { _ViTri = value; }
        }

        string _TenVT = "";

        public string TenVT
        {
            get { return _TenVT; }
            set { _TenVT = value; }
        }
        DateTime _NgaySinh = new DateTime(1980, 1, 30);

        public DateTime NgaySinh
        {
            get { return _NgaySinh; }
            set { _NgaySinh = value; }
        }
        string _DoiBong = "";

        public string DoiBong
        {
            get { return _DoiBong; }
            set { _DoiBong = value; }
        }

        string _TenDoi = "";

        public string TenDoi
        {
            get { return _TenDoi; }
            set { _TenDoi = value; }
        }

        int _SoBanThang;

        public int SoBanThang
        {
            get { return _SoBanThang; }
            set { _SoBanThang = value; }
        }

        double _ChieuCao = 1;

        public double ChieuCao
        {
            get { return _ChieuCao; }
            set { _ChieuCao = value; }
        }

        double _CanNang = 45;

        public double CanNang
        {
            get { return _CanNang; }
            set { _CanNang = value; }
        }

        string _AnhDaiDien = "";

        public string AnhDaiDien
        {
            get { return _AnhDaiDien; }
            set { _AnhDaiDien = value; }
        }

        public CauThuModel(int optMaCT = -1)
        {
            MaCauThu = optMaCT;
        }
        public override void DataMap(IDataReader reader)
        {
            //12
            if (ColumnExists(reader, "MaCauThu")) this.MaCauThu = Convert.ToInt32(reader["MaCauThu"]);
            if (ColumnExists(reader, "SoAo")) this.SoAo =
                    reader["SoAo"] == DBNull.Value ? this.SoAo : Convert.ToInt32(reader["SoAo"]);//
            if (ColumnExists(reader, "HoTen")) this.HoTen = Convert.ToString(reader["HoTen"]);
            if (ColumnExists(reader, "QuocTich")) this.QuocTich = Convert.ToString(reader["QuocTich"]);
            if (ColumnExists(reader, "TenVT")) this.TenVT = Convert.ToString(reader["TenVT"]);
            if (ColumnExists(reader, "ViTri")) this.ViTri =
                    reader["ViTri"] == DBNull.Value ? this.ViTri : Convert.ToInt32(reader["ViTri"]);//
            if (ColumnExists(reader, "NgaySinh")) this.NgaySinh =
                    reader["NgaySinh"] == DBNull.Value ? this.NgaySinh : Convert.ToDateTime(reader["NgaySinh"]);//
            if (ColumnExists(reader, "DoiBong")) this.DoiBong = Convert.ToString(reader["DoiBong"]);
            if (ColumnExists(reader, "TenDoi")) this.TenDoi = Convert.ToString(reader["TenDoi"]);
            if (ColumnExists(reader, "SoBanThang")) this.SoBanThang =
                    reader["SoBanThang"] == DBNull.Value ? this.SoBanThang : Convert.ToInt32(reader["SoBanThang"]);//
            if (ColumnExists(reader, "ChieuCao")) this.ChieuCao =
                    reader["ChieuCao"] == DBNull.Value ? this.ChieuCao : Convert.ToDouble(reader["ChieuCao"]);//double
            if (ColumnExists(reader, "CanNang")) this.CanNang =
                    reader["CanNang"] == DBNull.Value ? this.CanNang : Convert.ToDouble(reader["CanNang"]);//double
            if (ColumnExists(reader, "AnhDaiDien")) this.AnhDaiDien = Convert.ToString(reader["AnhDaiDien"]);
        }
    }
}
