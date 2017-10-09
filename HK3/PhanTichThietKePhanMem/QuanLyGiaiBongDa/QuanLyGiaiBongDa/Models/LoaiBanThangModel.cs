/*
 * 1642051 - Nguyen Xuan Phuc
 * LoaiBanThangModel.cs
 */

using QuanLyGiaiBongDa.Common;
using System;
using System.Data;

namespace QuanLyGiaiBongDa.Models
{
    public class LoaiBanThangModel : BaseModel
    {
        string _maLoai;
        public string MaLoai
        {
            get { return _maLoai; }
            set { _maLoai = value; }
        }
        string _tenLoai;
        public string TenLoai
        {
            get { return _tenLoai; }
            set { _tenLoai = value; }
        }
        public virtual void ClearValue()
        {
            MaLoai = string.Empty;
            TenLoai = string.Empty;
        }
        public LoaiBanThangModel(string optMaLoai = "")
        {
            MaLoai = optMaLoai;
        }
        public override void DataMap(IDataReader reader)
        {
            if (ColumnExists(reader, "MaLoai"))
                this.MaLoai = Convert.ToString(reader["MaLoai"]);
            if (ColumnExists(reader, "TenLoai"))
                this.TenLoai = Convert.ToString(reader["TenLoai"]);
        }
    }
}
