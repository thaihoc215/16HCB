using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using log4net;

namespace QuanLyGiaiBongDa.Dao.Impl
{
    public class SCED060Impl : ISCED060
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCED060Impl));
        #region SQL
        const string AddThePhatSQL = @"
            Insert Into DanhSachThePhat(MaThePhat,LoaiThe,CauThu,TrongTai,ThoiDiem,TranDau)
	        Values (@1, @2, @3, @4, @5, @6)
        ";
        const string DeleteThePhatSQL = @"
            Delete DanhSachThePhat
	        Where MaThePhat = @1
        
        ";
        const string GetDSCauThuSQL = @"
            Select *
            From DanhSachCauThu";

        const string GetDSThePhatSQL = @"
            Select * From LoaiThePhat";

        const string CountTrongTaiSQL = @"
            Select Max(MaTrongTai)
            From TrongTai";
        const string FindThePhatSQL = @"
            Select * From LoaiThePhat
	        Where MaThePhat = @1
        
        ";
        #endregion

        #region Execute SQL
        /// <summary>
        /// The the phat
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool AddThePhat(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ThePhatModel tp = (ThePhatModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(AddThePhatSQL,tp.MaThePhat,tp.LoaiThe,tp.CauThu,
                                                tp.TrongTai,tp.ThoiDiem,tp.TranDau) == 0)
                    {
                        Log.Error("Excute SQl Fail");
                        ((TransactionDbAccessor)db).Rollback();
                        return false;
                    }
                }
                catch (Exception)
                {
                    Log.Error("Excute SQl Fail");
                    ((TransactionDbAccessor)db).Rollback();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// The the phat
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool DeleteThePhat(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            int maTP = (int)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(DeleteThePhatSQL,maTP) == 0)
                    {
                        Log.Error("Excute SQl Fail");
                        ((TransactionDbAccessor)db).Rollback();
                        return false;
                    }
                }
                catch (Exception)
                {
                    Log.Error("Excute SQl Fail");
                    ((TransactionDbAccessor)db).Rollback();
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        ///  the phat
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool FindThePhat(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            int maTP = (int)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(FindThePhatSQL, maTP) == 0)
                    {
                        Log.Error("Excute SQl Fail");
                        ((TransactionDbAccessor)db).Rollback();
                        return false;
                    }
                }
                catch (Exception)
                {
                    Log.Error("Excute SQl Fail");
                    ((TransactionDbAccessor)db).Rollback();
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Lay danh sach cau thu cua hai doi bong
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public ObservableCollection<CauThuModel> GetDSCauThu(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<CauThuModel> lstCauThu = new ObservableCollection<CauThuModel>();
            using (var db = new AutoCommitDbAccessor())
            {
                IDataReader reader = db.Query(GetDSCauThuSQL);
                while (reader.Read())
                {
                    var ct = new CauThuModel();
                    ct.DataMap(reader);
                    lstCauThu.Add(ct);
                }
            }
            return lstCauThu;
        }

        /// <summary>
        /// Lay danh sach loai the phat
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetDSThePhat(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            Dictionary<string, string> lstThePhat = new Dictionary<string, string>();
            using (var db = new AutoCommitDbAccessor())
            {
                IDataReader reader = db.Query(GetDSThePhatSQL);
                while (reader.Read())
                {
                    string maThe = Convert.ToString(reader["MaThe"]);
                    string tenLoai = Convert.ToString(reader["TenLoai"]);
                    lstThePhat.Add(maThe, tenLoai);
                }
            }
            return lstThePhat;
        }
        #endregion
    }
}
