/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 03/04/2017 - SCED070Impl.cs
 */
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;
using log4net;

namespace QuanLyGiaiBongDa.Dao.Impl
{
    public class SCED070Impl : ISCED070
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCED070Impl));
        #region SQL
        const string GetListBangCapSQL = @"
            Select * 
            From LoaiBangCap";
        const string FindBangCapSQL = @"
            Select * 
            From LoaiBangCap
            Where BangCap = @1"
            ;
        const string CountTrongTaiSQL = @"
            Select Max(MaTrongTai)
            From TrongTai";
        const string AddTrongTaiSQL = @"
            Insert Into 
                TrongTai(MaTrongTai, TenTrongTai, NgaySinh, GioiTinh, BangCap)	
            Values(@1,@2,@3,@4,@5)";
        const string UpdateTrongTaiSQL = @"
            Update TrongTai
	        Set 
                TenTrongTai = @2,
	            NgaySinh = @3,
	            GioiTinh = @4,
	            BangCap = @5
	        Where MaTrongTai = @1";
        const string DeleteTrongTaiSQL = @"
            Update DanhSachThePhat
	        Set TrongTai = null
	        Where TrongTai = @1
	        
            Update LichThiDau
	        Set LichthiDau.TrongTai = null
	        Where LichThiDau.TrongTai = @1
	        
            Delete TrongTai 
            Where MaTrongTai = @1";
        #endregion

        #region ExecutSQL

        public ObservableCollection<BangCapModel> GetListBangCap(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<BangCapModel> lstBangCap = new ObservableCollection<BangCapModel>();
            using (var db = new AutoCommitDbAccessor())
            {

                IDataReader reader = db.Query(GetListBangCapSQL);
                while (reader.Read())
                {
                    var bangCap = new BangCapModel();
                    bangCap.DataMap(reader);
                    lstBangCap.Add(bangCap);
                }
            }
            return lstBangCap;
        }

        public ObservableCollection<BangCapModel> FindBangCap(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<BangCapModel> lstBangCap = new ObservableCollection<BangCapModel>();
            using (var db = new AutoCommitDbAccessor())
            {

                IDataReader reader = db.Query(FindBangCapSQL);
                while (reader.Read())
                {
                    var bangCap = new BangCapModel();
                    bangCap.DataMap(reader);
                    lstBangCap.Add(bangCap);
                }
            }
            return lstBangCap;
        }
        /// <summary>
        /// Update thong tin trong tai
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool UpdateTrongTai(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            TrongTaiModel trongTai = (TrongTaiModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(UpdateTrongTaiSQL,trongTai.MaTrongTai,trongTai.TenTrongTai,
                                                        trongTai.NgaySinh,trongTai.GioiTinh,trongTai.BangCap) == 0)
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
        /// Update thong tin trong tai
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>

        public bool DeleteTrongTai(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            string maTrongTai = (string)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(DeleteTrongTaiSQL, maTrongTai) == 0)
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
        /// Dem So Luong Trong Tai
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public string CountTrongTai(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            using (var db = new AutoCommitDbAccessor())
            {
                return db.Scalar<string>(CountTrongTaiSQL);
            }
        }
        /// <summary>
        /// Them trong tai
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool AddTrongTai(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            TrongTaiModel trongTai = (TrongTaiModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(AddTrongTaiSQL, trongTai.MaTrongTai, trongTai.TenTrongTai,
                                                        trongTai.NgaySinh, trongTai.GioiTinh, trongTai.BangCap) == 0)
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
        #endregion
    }
}
