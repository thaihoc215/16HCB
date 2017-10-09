/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 12/04/2017 - TranDauModel.cs
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
    public class TranDauModel : BaseModel
    {
        private string _MaTranDau = "";
        public string MaTranDau
        {
            get { return _MaTranDau; }
            set { _MaTranDau = value; }
        }

        private int _VongDau;
        public int VongDau
        {
            get { return _VongDau; }
            set { _VongDau = value; }
        }

        private string _MaDoiNha = "";
        public string MaDoiNha
        {
            get { return _MaDoiNha; }
            set { _MaDoiNha = value; }
        }

        private string _TenDoiNha = "";
        public string TenDoiNha
        {
            get { return _TenDoiNha; }
            set { _TenDoiNha = value; }
        }

        private string _MaDoiKhach = "";
        public string MaDoiKhach
        {
            get { return _MaDoiKhach; }
            set { _MaDoiKhach = value; }
        }

        private string _TenDoiKhach = "";
        public string TenDoiKhach
        {
            get { return _TenDoiKhach; }
            set { _TenDoiKhach = value; }
        }

        private string _San = "";
        public string San
        {
            get { return _San; }
            set { _San = value; }
        }

        private string _TenSan = "";
        public string TenSan
        {
            get { return _TenSan; }
            set { _TenSan = value; }
        }

        private string _TrongTai = "";
        public string TrongTai
        {
            get { return _TrongTai; }
            set { _TrongTai = value; }
        }

        private string _TenTrongTai = "";
        public string TenTrongTai
        {
            get { return _TenTrongTai; }
            set { _TenTrongTai = value; }
        }
        private DateTime _Ngay = DateTime.Now;
        public DateTime Ngay
        {
            get { return _Ngay; }
            set { _Ngay = value; }
        }

        private string _Gio = DateTime.Now.ToShortTimeString();
        public string Gio
        {
            get { return _Gio; }
            set { _Gio = value; }
        }
        public override void DataMap(IDataReader reader)
        {
            if (ColumnExists(reader, "MaTranDau")) this.MaTranDau = Convert.ToString(reader["MaTranDau"]);
            if (ColumnExists(reader, "VongDau")) this.VongDau =
                    reader["VongDau"] == DBNull.Value ? this.VongDau : Convert.ToInt32(reader["VongDau"]);
            if (ColumnExists(reader, "MaDoiNha")) this.MaDoiNha = Convert.ToString(reader["MaDoiNha"]);
            if (ColumnExists(reader, "TenDoiNha")) this.TenDoiNha = Convert.ToString(reader["TenDoiNha"]);
            if (ColumnExists(reader, "MaDoiKhach")) this.MaDoiKhach = Convert.ToString(reader["MaDoiKhach"]);
            if (ColumnExists(reader, "TenDoiKhach")) this.TenDoiKhach = Convert.ToString(reader["TenDoiKhach"]);
            if (ColumnExists(reader, "San")) this.San = Convert.ToString(reader["San"]);
            if (ColumnExists(reader, "TenSan")) this.TenSan = Convert.ToString(reader["TenSan"]);
            if (ColumnExists(reader, "TrongTai")) this.TrongTai = Convert.ToString(reader["TrongTai"]);
            if (ColumnExists(reader, "TenTrongTai")) this.TenTrongTai = Convert.ToString(reader["TenTrongTai"]);
            if (ColumnExists(reader, "Ngay")) this.Ngay =
                    reader["Ngay"] == DBNull.Value ? this.Ngay : Convert.ToDateTime(reader["Ngay"]);
            if (ColumnExists(reader, "Gio")) this.Gio = Convert.ToString(reader["Gio"]);
        }
    }
}
