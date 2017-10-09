/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 29/03/2017 - BangXepHangModel.cs
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
    public class BangXepHangModel : BaseModel
    {
        int _Hang;

        public int Hang
        {
            get { return _Hang; }
            set { _Hang = value; }
        }
        string _MaDoi;

        public string MaDoi
        {
            get { return _MaDoi; }
            set { _MaDoi = value; }
        }
        string _TenDoi;

        public string TenDoi
        {
            get { return _TenDoi; }
            set { _TenDoi = value; }
        }
        int _SoTran;

        public int SoTran
        {
            get { return _SoTran; }
            set { _SoTran = value; }
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
        int _HieuSo;

        public int HieuSo
        {
            get { return _HieuSo; }
            set { _HieuSo = value; }
        }
        int _BanThang;

        public int BanThang
        {
            get { return _BanThang; }
            set { _BanThang = value; }
        }
        int _Diem;

        public int Diem
        {
            get { return _Diem; }
            set { _Diem = value; }
        }

        public override void DataMap(IDataReader reader)
        {
            //10
            if (ColumnExists(reader, "Hang")) this.Hang =
                    reader["Hang"] == DBNull.Value ? this.Hang : Convert.ToInt32(reader["Hang"]);
            if (ColumnExists(reader, "MaDoi")) this.MaDoi = Convert.ToString(reader["MaDoi"]);
            if (ColumnExists(reader, "TenDoi")) this.TenDoi = Convert.ToString(reader["TenDoi"]);
            if (ColumnExists(reader, "SoTran")) this.SoTran =
                    reader["SoTran"] == DBNull.Value ? this.SoTran : Convert.ToInt32(reader["SoTran"]);
            if (ColumnExists(reader, "Thang")) this.Thang =
                    reader["Thang"] == DBNull.Value ? this.Thang : Convert.ToInt32(reader["Thang"]);
            if (ColumnExists(reader, "Hoa")) this.Hoa =
                    reader["Hoa"] == DBNull.Value ? this.Hoa : Convert.ToInt32(reader["Hoa"]);
            if (ColumnExists(reader, "Thua")) this.Thua =
                    reader["Thua"] == DBNull.Value ? this.Thua : Convert.ToInt32(reader["Thua"]);
            if (ColumnExists(reader, "HieuSo")) this.HieuSo =
                    reader["HieuSo"] == DBNull.Value ? this.HieuSo : Convert.ToInt32(reader["HieuSo"]);
            if (ColumnExists(reader, "BanThang")) this.BanThang =
                    reader["BanThang"] == DBNull.Value ? this.BanThang : Convert.ToInt32(reader["BanThang"]);
            if (ColumnExists(reader, "Diem")) this.Diem =
                    reader["Diem"] == DBNull.Value ? this.Diem : Convert.ToInt32(reader["Diem"]);
        }
    }
}
