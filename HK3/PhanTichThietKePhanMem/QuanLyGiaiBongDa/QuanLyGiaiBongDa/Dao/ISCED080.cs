/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 04/04/2017 - ISCED080.cs
 */
using QuanLyGiaiBongDa.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace QuanLyGiaiBongDa.Dao
{
    interface ISCED080
    {
        //Lay danh sach vi tri cau thu
        ObservableCollection<ViTriModel> GetDanhSachViTri(params object[] paramArr);

        //Lay danh sach cau thu doi bong
        ObservableCollection<CauThuModel> GetDsCauThuDoiBong(params object[] paramArr);

        //Set doi truong cho doi bong
        bool SetDoiTruong(params object[] paramArr);

        //Them cau thu vao doi bong
        bool AddCauThu(params object[] paramArr);
        //Xoa cau thu
        bool DeleteCauThu(params object[] paramArr);

        //Lay ma so max cua cau thu
        int GetMaxCauThu(params object[] paramArr);

        //Lay danh sach quy dinh
        Dictionary<string, int> GetListQuyDinh(params object[] paramArr);

    }
}
