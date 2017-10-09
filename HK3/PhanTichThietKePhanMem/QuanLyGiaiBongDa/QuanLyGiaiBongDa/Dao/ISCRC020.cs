/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 25/03/2017 - ISCRC020.cs
 */
using QuanLyGiaiBongDa.Models;
using System.Collections.ObjectModel;

namespace QuanLyGiaiBongDa.Dao
{
    interface ISCRC020
    {
        //Lay danh sach trong tai
        ObservableCollection<TrongTaiModel> GetListTrongTai(params object[] paramArr);

        //Lay danh sach san van dong
        ObservableCollection<SanVanDongModel> GetListSanVanDong(params object[] paramArr);

        //Lay danh sach huan luyen vien
        ObservableCollection<HuanLuyenVienModel> GetListHuanLuyenVien(params object[] paramArr);

        //Lay Danh sach the phat
        ObservableCollection<ThePhatModel> GetListThePhat(params object[] paramArr);

        //Lay danh sach ban thang
        ObservableCollection<BanThangModel> GetListBanThang(params object[] paramArr);

        //Lay danh sach doi bong
        ObservableCollection<DoiBongModel> GetDanhSachDoiBong(params object[] paramArr);
    }
}
