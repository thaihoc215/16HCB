/*
 * 1642051 - Nguyen Xuan Phuc
 * LichThiDauModel.cs
 */

using QuanLyGiaiBongDa.Common;
using System;
using System.Data;

namespace QuanLyGiaiBongDa.Models
{
    public class LichThiDauModel : BaseModel
    {
        private string _MaTranDau;
        private int _VongDau;
        private string _DoiNha;
        private string _DoiKhach;
        private string _TenSan;
        private string _TrongTai;
        private DateTime _Ngay;
        private string _Gio;

        public string MaTranDau
        {
            get { return _MaTranDau; }
            set { _MaTranDau = value; }
        }

        public int VongDau
        {
            get { return _VongDau; }
            set { _VongDau = value; }
        }

        public string DoiNha
        {
            get { return _DoiNha; }
            set { _DoiNha = value; }
        }

        public string DoiKhach
        {
            get { return _DoiKhach; }
            set { _DoiKhach = value; }
        }

        public DateTime Ngay
        {
            get { return _Ngay; }
            set { _Ngay = value; }
        }

        public string Gio
        {
            get { return _Gio; }
            set { _Gio = value; }
        }

        public string TenSan
        {
            get { return _TenSan; }
            set { _TenSan = value; }
        }

        public string TrongTai
        {
            get { return _TrongTai; }
            set { _TrongTai = value; }
        }

        public override void DataMap(IDataReader reader)
        {
            if (ColumnExists(reader, "MaTranDau"))
                this.MaTranDau = Convert.ToString(reader["MaTranDau"]);
            if (ColumnExists(reader, "VongDau"))
                this.VongDau = reader["VongDau"] == DBNull.Value ? this.VongDau : Convert.ToInt32(reader["VongDau"]);
            if (ColumnExists(reader, "DoiNha"))
                this.DoiNha = Convert.ToString(reader["DoiNha"]);
            if (ColumnExists(reader, "DoiKhach"))
                this.DoiKhach = Convert.ToString(reader["DoiKhach"]);
            if (ColumnExists(reader, "Ngay"))
                this.Ngay = reader["Ngay"] == DBNull.Value ? this.Ngay : Convert.ToDateTime(reader["Ngay"]);
            if (ColumnExists(reader, "Gio"))
                this.Gio = Convert.ToString(reader["Gio"]);
            if (ColumnExists(reader, "TenSan"))
                this.TenSan = Convert.ToString(reader["TenSan"]);
            if (ColumnExists(reader, "TrongTai"))
                this.TrongTai = Convert.ToString(reader["TrongTai"]);
        }
    }
}
