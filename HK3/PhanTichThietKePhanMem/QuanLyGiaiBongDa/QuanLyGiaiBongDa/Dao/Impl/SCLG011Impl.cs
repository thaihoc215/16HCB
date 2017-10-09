using log4net;
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Models;
using System;

namespace QuanLyGiaiBongDa.Dao.Impl
{
    public class SCLG011Impl : ISCLG011
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCLG011Impl));
        #region SQL
        const string UpdatePassSQL = @"
        Update NhanVien
        Set Pass = @2
        Where Email = @1";
        #endregion

        #region ExecuteSQL
        public bool DoiMatKhau(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            NguoiDungModel ct = (NguoiDungModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(UpdatePassSQL, ct.Email, ct.Pass) == 0)
                    {
                        Log.Error("Execute SQL Fail");
                        ((TransactionDbAccessor)db).Rollback();
                        return false;
                    }
                }
                catch (Exception)
                {
                    Log.Error("Execute SQL Fail");
                    ((TransactionDbAccessor)db).Rollback();
                    return false;
                }
            }
            return true;
        }
        #endregion

    }
}
