/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 01/04/2017 - ISCED030.cs
 */
using QuanLyGiaiBongDa.Models;
using System.Collections.ObjectModel;

namespace QuanLyGiaiBongDa.Dao
{
    interface ISCED030
    {
        //Lay danh sach Huan luyen vien
        ObservableCollection<HuanLuyenVienModel> GetDanhSachHLV(params object[] paramArr);

        //Lay danh sach San Van dong
        ObservableCollection<SanVanDongModel> GetDanhSachSVD(params object[] paramArr);

        //Lay ten doi bong maximum(string)
        string CountMaxDoiBong(params object[] paramArr);

        //Dang ky doi bong chua co cau thu
        bool AddDoibongChuaCauThu(params object[] paramArr);

        //Xoa doi bong vua dang ky
        bool DeleteDoiBong(params object[] paramArr);
    }
}
