/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 29/03/2017 - ISCRC060.cs
 */
using QuanLyGiaiBongDa.Models;
using System.Collections.ObjectModel;

namespace QuanLyGiaiBongDa.Dao
{
    interface ISCRC060
    {
        //Lay danh sach Tran dau trong ngay
        ObservableCollection<TranDauModel> GetLichDauTrongNgay(params object[] paramArr);

        //Lay danh sach doi bong theo xep hang
        ObservableCollection<BangXepHangModel> GetBangXepHang(params object[] paramArr);
    
        //Xoa doi bong
        bool DeleteDoiBong(params object[] paramArr);

        //Get list avafile name cau thu
        ObservableCollection<CauThuModel> GetDsCauThuDoiBong(params object[] paramArr);
    }
}
