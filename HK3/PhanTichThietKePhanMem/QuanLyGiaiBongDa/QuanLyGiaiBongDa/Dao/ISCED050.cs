/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 03/04/2017 - ISCED050.cs
 */
using QuanLyGiaiBongDa.Models;
using System.Collections.ObjectModel;

namespace QuanLyGiaiBongDa.Dao
{
    interface ISCED050
    {
        //Lay Danh sach doi bong
        ObservableCollection<DoiBongModel> GetDanhSachDoiBong(params object[] paramArr);
        //Update thong tin san van dong
        bool UpdateSanVanDong(params object[] paramArr);
        //Update thong tin san van dong
        bool DeleteSanVanDong(params object[] paramArr);
        //Them san van dong
        bool AddSanVanDong(params object[] paramArr);
        //Lay so san van dong lon nhat
        string CountSan(params object[] paramArr);
    }
}
