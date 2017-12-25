using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ThanhVienDAO
    {
        public static List<ThanhVienDTO> GetListThanhVien()
        {
            List<ThanhVienDTO> lstThanhVien = new List<ThanhVienDTO>();
            var db = DataProvider.LoadDataByText("Select * From ThanhVien").Tables[0].Rows;
            foreach (DataRow row in db)
            {
                ThanhVienDTO tv = new ThanhVienDTO();
                tv.MaTV = (int)row["MaTV"];
                tv.TenTV = (String)row["TenTV"];
                tv.NgaySinh = (DateTime)row["NgaySinh"];
                tv.SDT = (String)row["SDT"];
                tv.Email = (String)row["Email"];
                lstThanhVien.Add(tv);
            }
            return lstThanhVien;
        }

        public static bool UpdateThanhVien(ThanhVienDTO tv)
        {
            SqlCommand cmd = new SqlCommand("Update ThanhVien" +
                " set TenTV = '" + tv.TenTV + "',NgaySinh = '" + tv.NgaySinh + "', SDT = '" + tv.SDT + "',Email = '" + tv.Email + "'" +
                " Where MaTV = " + tv.MaTV);
            return DataProvider.ExecuteNonquery(cmd);
        }

        public static bool AddThanhVien(ThanhVienDTO tv)
        {
            SqlCommand cmd = new SqlCommand("Insert into ThanhVien(TenTV,NgaySinh,SDT,Email) " +
                "values ('" + tv.TenTV + "','" + tv.NgaySinh + "','" + tv.SDT + "','" + tv.Email + "')");
            cmd.CommandType = CommandType.Text;
            return DataProvider.ExecuteNonquery(cmd);
        }

        public static bool DeleteThanhVien(int maTV)
        {
            SqlCommand cmd = new SqlCommand("Delete from ThanhVien Where MaTV = " + maTV);
            cmd.CommandType = CommandType.Text;
            return DataProvider.ExecuteNonquery(cmd);
        }
    }
}
