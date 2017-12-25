using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ThanhVienBUS
    {
        public static List<ThanhVienDTO> LayDanhSach()
        {
            return ThanhVienDAO.GetListThanhVien();
        }

        public static bool DeleteThanhVien(int maTV)
        {
            return ThanhVienDAO.DeleteThanhVien(maTV);
        }

        public static bool AddThanhVien(ThanhVienDTO tv)
        {
            return ThanhVienDAO.AddThanhVien(tv);
        }

        public static bool UpdateThanhVien(ThanhVienDTO tv)
        {
            return ThanhVienDAO.UpdateThanhVien(tv);
        }
    }
}
