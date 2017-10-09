/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 03/04/2017 - SCED040Impl.cs
 */
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;
using log4net;
namespace QuanLyGiaiBongDa.Dao.Impl
{
    public class SCED050Impl : ISCED050
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCED050Impl));
        #region SQL
        const string GetListDoiBongSQL = @"
            Select *
            From HoSoDoiBong";
        const string CountSanVanDongSQL = @"
            Select Max(MaSan)
            From SanVanDong";
        const string AddSVDSQL = @"
            Insert Into 
                SanVanDong(MaSan,TenSan,DoiBongSoHuu,NgayKhanhThanh,SucChua,KichThuoc)
	        Values(@1,@2,null,@3,@4,@5)";

        const string UpdateSVDSQL = @"
            Update SanVanDong
	        Set 
                TenSan = @2,
	            NgayKhanhThanh = @3,
	            SucChua = @4,
	            KichThuoc = @5
	        Where MaSan = @1";

        const string DeleteSVDSQL = @"
            Update HoSoDoiBong 
	        Set SanVanDong = null
	        Where SanVanDong = @1
	        
            Update LichThiDau
	        Set San = null
	        Where San = @1
	        
            Delete SanVanDong 
            Where MaSan = @1";
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
        /// Update thong tin san van dong
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool UpdateSanVanDong(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            SanVanDongModel svd = (SanVanDongModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(UpdateSVDSQL, svd.MaSan, svd.TenSan, svd.NgayKhanhThanh,
                                                    svd.SucChua, svd.KichThuoc) == 0)
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
        /// Xoa thong tin san van dong
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool DeleteSanVanDong(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            string maSan = (string)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(DeleteSVDSQL, maSan) == 0)
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
        /// Them san van dong
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool AddSanVanDong(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            SanVanDongModel svd = (SanVanDongModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(AddSVDSQL, svd.MaSan, svd.TenSan, svd.NgayKhanhThanh,
                                                    svd.SucChua, svd.KichThuoc) == 0)
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
        /// Lay ten san max
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public string CountSan(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            using (var db = new AutoCommitDbAccessor())
            {
                return db.Scalar<string>(CountSanVanDongSQL);
            }
        }
        #endregion
    }
}
