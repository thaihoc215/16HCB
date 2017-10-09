/*
 * 1642024 - Ung Buu Tri Hung
 * 01/05/2017 - 2:45 PM - BangQuyDinhModel.cs
 */
using QuanLyGiaiBongDa.Common;
using System;
using System.Data;

namespace QuanLyGiaiBongDa.Models
{
    public class BangQuyDinhModel : BaseModel
    {
        string _MaGT;
        public string MaGT
        {
            get { return _MaGT; }
            set { _MaGT = value; }
        }

        int _GiaTri;
        public int GiaTri
        {
            get { return _GiaTri; }
            set { _GiaTri = value; }
        }
        
        public override void DataMap(IDataReader reader)
        {
            if (ColumnExists(reader, "MaGT")) this.MaGT = Convert.ToString(reader["MaGT"]);
            if (ColumnExists(reader, "GiaTri")) this.GiaTri =
                    reader["GiaTri"] == DBNull.Value ? this.GiaTri : Convert.ToInt32(reader["GiaTri"]);
        }
    }
}
