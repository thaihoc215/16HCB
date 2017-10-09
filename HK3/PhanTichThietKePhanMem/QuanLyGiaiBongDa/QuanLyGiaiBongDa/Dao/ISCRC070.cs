/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 26/04/2017 - SCRC070Impl.cs
 */
using QuanLyGiaiBongDa.Models;
using System.Collections.ObjectModel;

namespace QuanLyGiaiBongDa.Dao
{
    interface ISCRC070
    {
        //Lay doi bong
        DoiBongModel GetDoiBong(params object[] paramArr);

        //Lay danh sach Huan luyen vien
        ObservableCollection<HuanLuyenVienModel> GetDanhSachHLV(params object[] paramArr);

        //Lay danh sach San Van dong
        ObservableCollection<SanVanDongModel> GetDanhSachSVD(params object[] paramArr);

        //Lay danh sach cau thu doi bong
        ObservableCollection<CauThuModel> GetDanhSachCauThu(params object[] paramArr);

        //Update thong tin doi bong
        bool UpdateDoiBong(params object[] paramArr);
    }
}
