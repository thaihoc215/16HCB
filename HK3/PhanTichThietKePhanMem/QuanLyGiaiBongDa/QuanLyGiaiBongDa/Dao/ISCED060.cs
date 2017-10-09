using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiBongDa.Dao
{
    interface ISCED060
    {
        //them the phat
        bool AddThePhat(params object[] paramArr);
        //Xoa the phe
        bool DeleteThePhat(params object[] paramArr);
        //lay danh sach cau thu
        ObservableCollection<CauThuModel> GetDSCauThu(params object[] paramArr);
        //lay danh sach loai the phat
        Dictionary<string, string> GetDSThePhat(params object[] paramArr);
    }
}
