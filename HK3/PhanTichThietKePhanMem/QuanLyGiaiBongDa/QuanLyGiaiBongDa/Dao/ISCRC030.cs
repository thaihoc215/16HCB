/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 15/04/2017 - SCRC030Impl.cs
 */
using QuanLyGiaiBongDa.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace QuanLyGiaiBongDa.Dao
{
    interface ISCRC030
    {
        //Lay danh sach cau thu
        ObservableCollection<CauThuModel> GetListCauThu(params object[] paramArr);
        //Lay danh sach doi bong
        ObservableCollection<DoiBongModel> GetListDoiBong(params object[] paramArr);
        //Lay danh sach vi tri
        ObservableCollection<ViTriModel> GetListViTri(params object[] paramArr);

        //tim kiem cau thu
        ObservableCollection<CauThuModel> SearchCauThu(params object[] paramArr);
        //Them Cau Thu
        bool AddCauThu(params object[] paramArr);
        //Chinh sua thong tin cau thu
        bool UpdateCauThu(params object[] paramArr);
        //Xoa cau thu
        bool DeleteCauThu(params object[] paramArr);

        //Lay ma so max cua cau thu
        int GetMaxCauThu(params object[] paramArr);

        //Lay danh sach quy dinh
        Dictionary<string, int> GetListQuyDinh(params object[] paramArr);

    }
}
