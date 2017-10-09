/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 29/03/2017 - ISCRC050.cs
 */
using QuanLyGiaiBongDa.Models;
using System.Collections.ObjectModel;

namespace QuanLyGiaiBongDa.Dao
{
    interface ISCRC050
    {
        //Lay danh sach lich thi dau
        ObservableCollection<TranDauModel> GetLichThiDau(params object[] paramArr);

        //Update thong tin tran dau
        bool UpdateTranDau(params object[] paramArr);

        //Lay trong tai bat tran dau
        ObservableCollection<TrongTaiModel> GetLstTrongTai(params object[] paramArr);

        //Tao lich thi dau
        bool TaoLichThiDau(params object[] paramArr);
    }
}
