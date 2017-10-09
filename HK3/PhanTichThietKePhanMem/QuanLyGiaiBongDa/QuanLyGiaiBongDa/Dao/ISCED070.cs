/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 31/03/2017 - ISCED070.cs
 */
using QuanLyGiaiBongDa.Models;
using System.Collections.ObjectModel;

namespace QuanLyGiaiBongDa.Dao
{
    interface ISCED070
    {
        //Lay danh sach bang cap
        ObservableCollection<BangCapModel> GetListBangCap(params object[] paramArr);
        //Update thong tin trong tai
        bool UpdateTrongTai(params object[] paramArr);
        //Update thong tin trong tai
        bool DeleteTrongTai(params object[] paramArr);
        //Them trong tai
        bool AddTrongTai(params object[] paramArr);
        //Dem so luong trong tai
        string CountTrongTai(params object[] paramArr);
    }
}
