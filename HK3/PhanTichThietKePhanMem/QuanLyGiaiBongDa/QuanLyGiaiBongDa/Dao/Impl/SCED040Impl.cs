/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 01/04/2017 - SCED040Impl.cs
 */
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;
using log4net;
namespace QuanLyGiaiBongDa.Dao.Impl
{
    public class SCED040Impl : ISCED040
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCED040Impl));
        #region SQL
        const string GetListDoiBongSQL = @"
            Select *
            From HoSoDoiBong";
        const string CountHLVSQL = @"
            Select Max(MaHLV)
            From HuanLuyenVien";
        const string AddHLVSQL = @"
            Insert Into 
                HuanLuyenVien(MaHLV,TenHLV,NgaySinh,GioiTinh,DoiBong,TroLy)
	        Values 
                (@1,@2,@3,@4,null,@5)";
        const string UpdateHLVSQL = @"
            Update HuanLuyenVien
	        Set 
                TenHLV = @2,
	            NgaySinh = @3,
	            GioiTinh = @4,
	            TroLy = @5
	        Where MaHLV = @1";
        const string FindHLVSQL = @"
            Select *
            From HuanLuyenVien 
	        Where HuanLuyenVien = @1";
        const string DeleteHLVSQL = @"
            Update HoSoDoiBong 
	        Set HuanLuyenVien = null
	        Where HuanLuyenVien = @1
	        Delete HuanLuyenVien 
            Where MaHLV = @1 ";
        #endregion

        #region ExecuteSQL
        /// <summary>
        /// Lay Danh sach doi bong
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public ObservableCollection<DoiBongModel> GetDanhSachDoiBong(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<DoiBongModel> lstDoiBong = new ObservableCollection<DoiBongModel>();
            using (var db = new AutoCommitDbAccessor())
            {

                IDataReader reader = db.Query(GetListDoiBongSQL);
                while (reader.Read())
                {
                    var doiBong = new DoiBongModel();
                    doiBong.DataMap(reader);
                    lstDoiBong.Add(doiBong);
                }
            }
            return lstDoiBong;
        }
        /// <summary>
        /// Lay chuoi HLV co chi so max
        /// </summary>
        /// <returns></returns>
        public string CountHLV()
        {
            Log.Info("Execute SQL");
            using (var db = new AutoCommitDbAccessor())
            {
                return db.Scalar<string>(CountHLVSQL);
            }
        }

        /// <summary>
        /// Them huan luyen vien
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool AddHLV(params object[] paramArr)
        {
            HuanLuyenVienModel hlv = (HuanLuyenVienModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                Log.Info("Execute SQL");
                try
                {
                    if (db.NonQuery(AddHLVSQL, hlv.MaHLV, hlv.TenHLV, hlv.NgaySinh, hlv.GioiTinh, hlv.TroLy) == 0)
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
        /// Update thong tin huan luyen vien
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool UpdateHuanLuyenVien(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            HuanLuyenVienModel hlv = (HuanLuyenVienModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(UpdateHLVSQL,hlv.MaHLV,hlv.TenHLV,hlv.NgaySinh,hlv.GioiTinh,hlv.TroLy) == 0)
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
        /// Tim luyen vien
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool FindHuanLuyenVien(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            string maHLV = (string)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(FindHLVSQL, maHLV) == 0)
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
        /// Xoa huan luyen vien
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool DeleteHuanLuyenVien(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            string maHLV = (string)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(DeleteHLVSQL, maHLV) == 0)
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
