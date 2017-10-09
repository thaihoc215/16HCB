using QuanLyGiaiBongDa.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiBongDa.Models
{
    public class ViTriModel: BaseModel
    {
        int _MaVT;
        public int MaVT
        {
            get { return _MaVT; }
            set { _MaVT = value; }
        }

        string _TenVT = "";

        public string TenVT
        {
            get { return _TenVT; }
            set { _TenVT = value; }
        }

        public override void DataMap(IDataReader reader)
        {
            if (ColumnExists(reader, "MaVT")) this.MaVT = Convert.ToInt32(reader["MaVT"]);
            if (ColumnExists(reader, "TenVT")) this.TenVT = Convert.ToString(reader["TenVT"]);
        }
    }
}
