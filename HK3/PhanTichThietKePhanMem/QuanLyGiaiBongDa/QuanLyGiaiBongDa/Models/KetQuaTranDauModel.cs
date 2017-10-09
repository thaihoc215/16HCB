/*
 * 1642051 - Nguyen Xuan Phuc
 * KetQuaTranDauModel.cs
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiBongDa.Models
{
    public class KetQuaTranDauModel : TranDauModel
    {
        private int _SoBanThangDoiNha;
        private string _TenTinhTrang;
        private int _SoBanThangDoiKhach;
        private int _MaTinhTrang;

        public int SoBanThangDoiNha
        {
            get { return _SoBanThangDoiNha; }
            set { _SoBanThangDoiNha = value; }
        }
        
        public int SoBanThangDoiKhach
        {
            get { return _SoBanThangDoiKhach; }
            set { _SoBanThangDoiKhach = value; }
        }
        
        public int MaTinhTrang
        {
            get { return _MaTinhTrang; }
            set { _MaTinhTrang = value; }
        }
        
        public string TenTinhTrang
        {
            get { return _TenTinhTrang; }
            set { _TenTinhTrang = value; }
        }

        public override void DataMap(IDataReader reader)
        {
            if (ColumnExists(reader, "MaTranDau"))
                this.MaTranDau = Convert.ToString(reader["MaTranDau"]);
            if (ColumnExists(reader, "SoBanThangDoiNha"))
                this.SoBanThangDoiNha =
                    reader["SoBanThangDoiNha"] == DBNull.Value ? this.SoBanThangDoiNha : Convert.ToInt32(reader["SoBanThangDoiNha"]);
            if (ColumnExists(reader, "SoBanThangDoiKhach"))
                this.SoBanThangDoiKhach =
                    reader["SoBanThangDoiKhach"] == DBNull.Value ? this.SoBanThangDoiKhach : Convert.ToInt32(reader["SoBanThangDoiKhach"]);
            if (ColumnExists(reader, "MaTinhTrang"))
                this.MaTinhTrang =
                    reader["MaTinhTrang"] == DBNull.Value ? this.MaTinhTrang : Convert.ToInt32(reader["MaTinhTrang"]);
            if (ColumnExists(reader, "TenTinhTrang"))
                this.TenTinhTrang = Convert.ToString(reader["TenTinhTrang"]);
        }
    }
}
