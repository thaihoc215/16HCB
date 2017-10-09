/*
 * 1642024 - Ung Buu Tri Hung
 * 01/05/2017 - 6:30 AM - ISCRC080.cs
 */
using QuanLyGiaiBongDa.Models;
using System.Collections.ObjectModel;

namespace QuanLyGiaiBongDa.Dao
{
    interface ISCRC080
    {
        //Load quy định
        QuyDinhModel LoadQuyDinh(params object[] paramArr);
        //Load loại bàn thắng
        ObservableCollection<LoaiBanThangModel> LoadLoaiBanThang(params object[] paramArr);
        string CountMaxLoaiBT(params object[] paramArr);
        bool AddLoaiBanThang(params object[] paramArr);
        bool UpdateLoaiBanThang(params object[] paramArr);
        bool DeleteLoaiBanThang(params object[] paramArr);
        bool UpdateQD1(params object[] paramArr);
        bool UpdateQD3(params object[] paramArr);
        bool UpdateQD4(params object[] paramArr);
    }
}
