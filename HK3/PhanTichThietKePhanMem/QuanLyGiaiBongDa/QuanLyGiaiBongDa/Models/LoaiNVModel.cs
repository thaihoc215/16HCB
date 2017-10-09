/*
 * 1642051 - Nguyen Xuan Phuc
 * LoaiNVModel.cs
 */

using QuanLyGiaiBongDa.Common;
using System;
using System.Data;

namespace QuanLyGiaiBongDa.Models
{
    public class LoaiNVModel : BaseModel
    {
        int _maLoai;
        string _tenLoai;

        public int MaLoai
        {
            get { return _maLoai; }
            set { _maLoai = value; }
        }
        
        public string TenLoai
        {
            get { return _tenLoai; }
            set { _tenLoai = value; }
        }

        public virtual void ClearValue()
        {
            MaLoai = -1;
            TenLoai = string.Empty;
        }

        public override void DataMap(IDataReader reader)
        {
            if (ColumnExists(reader, "MaLoai"))
                this.MaLoai = Convert.ToInt32(reader["MaLoai"]);
            if (ColumnExists(reader, "TenLoai"))
                this.TenLoai = Convert.ToString(reader["TenLoai"]);
        }
    }
}
