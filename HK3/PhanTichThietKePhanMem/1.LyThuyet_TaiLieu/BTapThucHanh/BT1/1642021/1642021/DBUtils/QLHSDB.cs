using _1642021.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1642021.DBUtils
{
    public class QLHSDB
    {
        public static DataTable LayDSHocSinh()
        {
            //List<HocSinhModel> lstHs = new List<HocSinhModel>();
            SqlCommand cmd = new SqlCommand("Select * from HocSinh");
            cmd.CommandType = CommandType.Text;
            return DataProvider.ExecuteQuery(cmd).Tables[0];
        }

        public static DataTable TimHocSinh(string tenHs)
        {
            SqlCommand cmd = new SqlCommand(
                @"Select * 
                  From HocSinh 
                  Where TenHs Like @TenHs"
                );
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@TenHs", "%" + tenHs + "%");
            return DataProvider.ExecuteQuery(cmd).Tables[0];
        }

        public static bool ThemHocSinh(HocSinhModel hs)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Insert Into HocSinh(TenHS,NgaySinh,SDT,DiaChi) Values (@TenHS,@NgaySinh,@SDT,@DiaChi)");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@TenHS", hs.TenHS);
                cmd.Parameters.AddWithValue("@NgaySinh", hs.NgaySinh);
                cmd.Parameters.AddWithValue("@SDT", hs.SDT);
                cmd.Parameters.AddWithValue("@DiaChi", hs.DiaChi);
                return DataProvider.ExecuteNonquery(cmd);
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static bool XoaHocSinh(int maHs)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete From HocSinh Where MaHS =@MaHS");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@MaHS", maHs);
                return DataProvider.ExecuteNonquery(cmd);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}


