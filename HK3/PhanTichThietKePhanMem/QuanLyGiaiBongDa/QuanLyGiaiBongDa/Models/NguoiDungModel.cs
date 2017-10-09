/*
 * 1642051 - Nguyen Xuan Phuc
 * NguoiDungModel.cs
 */

using QuanLyGiaiBongDa.Common;
using System;
using System.Data;

namespace QuanLyGiaiBongDa.Models
{
    public class NguoiDungModel : BaseModel
    {
        int _maNV;
        string _gioiTinh = string.Empty;
        string _hoTen = string.Empty;
        string _dienThoai = string.Empty;
        string _email = string.Empty;
        DateTime _ngaySinh = DateTime.Now;
        string _CMND = string.Empty;
        string _diaChi = string.Empty;
        string _pass = string.Empty;
        int _loaiNV;
        string _tenLoai = string.Empty;

        public int MaNV
        {
            get { return _maNV; }
            set { _maNV = value; }
        }

        public string GioiTinh
        {
            get { return _gioiTinh; }
            set { _gioiTinh = value; }
        }

        public string HoTen
        {
            get { return _hoTen; }
            set { _hoTen = value; }
        }

        public string DienThoai
        {
            get { return _dienThoai; }
            set { _dienThoai = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public DateTime NgaySinh
        {
            get { return _ngaySinh; }
            set { _ngaySinh = value; }
        }  

        public string CMND
        {
            get { return _CMND; }
            set { _CMND = value; }
        }

        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }

        public string Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }

        public int LoaiNV
        {
            get { return _loaiNV; }
            set { _loaiNV = value; }
        }

        public string TenLoai
        {
            get { return _tenLoai; }
            set { _tenLoai = value; }
        }

        public NguoiDungModel(int optmaNV = -1)
        {
            MaNV = optmaNV;
        }

        public virtual void ClearValue()
        {
            MaNV = -1;
            HoTen = string.Empty;
            NgaySinh = DateTime.Now;
            GioiTinh = string.Empty;   
            DienThoai = string.Empty;
            Email = string.Empty;
            DiaChi = string.Empty;
            CMND = string.Empty;
            Pass = string.Empty;
            LoaiNV = -1;
        }

        public override void DataMap(IDataReader reader)
        {
            if (ColumnExists(reader, "MaNV"))
                this.MaNV = Convert.ToInt32(reader["MaNV"]);
            if (ColumnExists(reader, "HoTen"))
                this.HoTen = Convert.ToString(reader["HoTen"]);
            if (ColumnExists(reader, "NgaySinh"))
                this.NgaySinh =
                    reader["NgaySinh"] == DBNull.Value ? this.NgaySinh : Convert.ToDateTime(reader["NgaySinh"]);
            if (ColumnExists(reader, "GioiTinh"))
                this.GioiTinh = Convert.ToString(reader["GioiTinh"]);
            if (ColumnExists(reader, "DienThoai"))
                this.DienThoai = Convert.ToString(reader["DienThoai"]);
            if (ColumnExists(reader, "Email"))
                this.Email = Convert.ToString(reader["Email"]);
            if (ColumnExists(reader, "DiaChi"))
                this.DiaChi = Convert.ToString(reader["DiaChi"]);
            if (ColumnExists(reader, "CMND"))
                this.CMND = Convert.ToString(reader["CMND"]);
            if (ColumnExists(reader, "Pass"))
                this.Pass = Convert.ToString(reader["Pass"]);
            if (ColumnExists(reader, "LoaiNV"))
                this.LoaiNV =
                    reader["LoaiNV"] == DBNull.Value ? this.LoaiNV : Convert.ToInt32(reader["LoaiNV"]);
            if (ColumnExists(reader, "TenLoai"))
                this.TenLoai = Convert.ToString(reader["TenLoai"]);
        }
    }
}
