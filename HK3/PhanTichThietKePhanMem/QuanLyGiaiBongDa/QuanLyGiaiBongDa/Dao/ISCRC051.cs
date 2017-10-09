/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 29/03/2017 - ISCRC050.cs
 */
using QuanLyGiaiBongDa.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace QuanLyGiaiBongDa.Dao
{
    interface ISCRC051
    {
        //Lay ket qua tran dau
        KetQuaTranDauModel GetKetQuaTranDau(params object[] paramArr);

        //Lay danh sach tinh trang tran dau
        Dictionary<int, string> GetListTinhTrang(params object[] paramArr);

        //Update ket qua tran dau
        bool UpdateTranDau(params object[] paramArr);

        //Lay danh sach ban thang
        ObservableCollection<BanThangModel> GetListBanThang(params object[] paramArr);

        //Lay ma ban thang max
        string GetMaxMaBT(params object[] paramArr);

        //Them ban thang
        bool AddBanThang(params object[] paramArr);

        //Xoa ban thang
        bool DeleteBanThang(params object[] paramArr);

        //Lay danh sach doi bong trong tran dau
        ObservableCollection<DoiBongModel> GetListDoiBong(params object[] paramArr);
        //Lay danh sach cau thu tu 1 trong 2 doi bong
        ObservableCollection<CauThuModel> GetListCauThu(params object[] paramArr);

        //Lay danh sach loai ban thang tu cau thu
        Dictionary<string, string> GetListLoaiBanThang(params object[] paramArr);

        



    }
}
