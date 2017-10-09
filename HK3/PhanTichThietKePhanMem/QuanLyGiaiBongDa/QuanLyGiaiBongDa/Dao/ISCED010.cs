/*
 * 1642024 - Ung Buu Tri Hung
 * 04/04/2017 - 2:40 PM - ISCED010.cs
 */
using QuanLyGiaiBongDa.Models;
using System.Collections.ObjectModel;

namespace QuanLyGiaiBongDa.Dao
{
    interface ISCED010
    {
        //Lay danh sach nguoi dung
        ObservableCollection<NguoiDungModel> GetListNguoiDung(params object[] paramArr);

        //Lay danh sach loai NV
        ObservableCollection<LoaiNVModel> GetListLoaiNV(params object[] paramArr);

        //Lấy mã NV lớn nhất
        int CountNV(params object[] paramArr);

        //Cấp tài khoản mới
        bool CapTaiKhoan(params object[] paramArr);

        //Sửa tài khoản
        bool SuaTaiKhoan(params object[] paramArr);

        //Xóa tài khoản
        bool XoaTaiKhoan(params object[] paramArr);
    }
}
