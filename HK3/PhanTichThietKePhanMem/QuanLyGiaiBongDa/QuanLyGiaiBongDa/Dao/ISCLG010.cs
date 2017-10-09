/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 17/03/2017 - ISCLG010.cs
 */
using QuanLyGiaiBongDa.Models;

namespace QuanLyGiaiBongDa.Dao
{
    interface ISCLG010
    {
        NguoiDungModel GetUser(params object[] paramArr);
    }
}
