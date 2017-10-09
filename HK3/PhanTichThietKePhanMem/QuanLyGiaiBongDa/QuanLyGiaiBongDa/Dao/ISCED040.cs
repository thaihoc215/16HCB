/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 01/04/2017 - ISCED040.cs
 */
using QuanLyGiaiBongDa.Models;
using System.Collections.ObjectModel;

namespace QuanLyGiaiBongDa.Dao
{
    interface ISCED040
    {
        //Lay danh sach doi bong
        ObservableCollection<DoiBongModel> GetDanhSachDoiBong(params object[] paramArr);
        //Lay chuoi HLV co chi so max
        string CountHLV();
        //Them huan luyen vien
        bool AddHLV(params object[] paramArr);
        //Cap nhat thong tin huan luyen vien
        bool UpdateHuanLuyenVien(params object[] paramArr);
        //Tim huan luyen vien
        bool FindHuanLuyenVien(params object[] paramArr);
        //Xoa huan luyen vien
        bool DeleteHuanLuyenVien(params object[] paramArr);
        
    }
}
