using QuanLyGiaiBongDa.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiBongDa.Models
{
    public class BangCapModel : BaseModel
    {
        string _MaBC;
        public string MaBC
        {
            get { return _MaBC; }
            set { _MaBC = value; }
        }

        string _TenBC;

        public string TenBC
        {
            get { return _TenBC; }
            set { _TenBC = value; }
        }

        public override void DataMap(IDataReader reader)
        {
            if (ColumnExists(reader, "MaBC")) this.MaBC = Convert.ToString(reader["MaBC"]);
            if (ColumnExists(reader, "TenBC")) this.TenBC = Convert.ToString(reader["TenBC"]);
        }
    }
}
