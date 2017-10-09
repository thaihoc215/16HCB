/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 01/04/2017 - SCED030Impl.cs
 */
using log4net;
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace QuanLyGiaiBongDa.Dao.Impl
{
    public class SCED030Impl : ISCED030
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCED030Impl));
        #region SQL
        const string CountMaxDoiBongSQL = @"
            Select Max(MaDoi)
            From HoSoDoiBong";
        const string GetListHLVSQL = @"
            Select *
            From HuanLuyenVien";
        const string GetListSVDSQL = @"
            Select *
            From SanVanDong";
        const string AddDoiBongSQL = @"
            Insert Into HoSoDoiBong(
                MaDoi, TenDoi, NamThanhLap,
                SanVanDong, ChuTich, HuanLuyenVien,
                DoiTruong, DiaChi, SoDienThoai, Logo)
            Values	(@1, @2, @3,
                     @4, @5, @6,
                     null, @7, @8, @9)";
        const string UpdateAfterAddDoibong = @"
            --Set Null MaDoiBong cho HLV va SVD bo chon
            Update HuanLuyenVien
            Set DoiBong = NULL
            Where MaHLV = @4

            Update SanVanDong
            Set DoiBongSoHuu = NULL
            Where MaSan = @5

            --Set MaDoiBong cho HLV va SVD duoc chon  
            Update SanVanDong
            Set DoiBongSoHuu = @1
            Where MaSan = @2

            Update HuanLuyenVien
            Set DoiBong = @1
            Where MaHLV = @3";
        //Delete Doi bong 
        const string DeleteDoiBongSQL = @"
            --update để xóa danh sách
	        UPDATE HoSoDoiBong
	        SET	
                DoiTruong = null, 
                SanVanDong =null, 
                HuanLuyenVien =null
	        Where MaDoi = @1

	        --update sân vận động
	        UPDATE SanVanDong
	        SET DoiBongSoHuu = null
	        WHERE DoiBongSoHuu = @1

	        --update Huấn luyện viên
	        UPDATE HuanLuyenVien
	        SET DoiBong = null
	        WHERE DoiBong = @1

	        --update cầu thủ
	        Delete DanhSachCauThu
	        Where DoiBong = @1
	        --Xóa đội bóng trong BXH
	        Delete BangXepHang
	        Where MaDoi = @1
	        --xóa đội
	        Delete HoSoDoiBong
	        Where MaDoi = @1";
        
        #endregion

        #region ExecuteSQL
        /// <summary>
        /// Lay ten doi bong maximum
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public string CountMaxDoiBong(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            using (var db = new AutoCommitDbAccessor())
            {
                return db.Scalar<string>(CountMaxDoiBongSQL);
            }
        }
        /// <summary>
        /// Lay danh sach huan luyen vien
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public ObservableCollection<HuanLuyenVienModel> GetDanhSachHLV(params object[] paramArr)
        {
            ObservableCollection<HuanLuyenVienModel> lstHLV = new ObservableCollection<HuanLuyenVienModel>();
            using (var db = new AutoCommitDbAccessor())
            {
                Log.Info("Execute SQL");
                IDataReader reader = db.Query(GetListHLVSQL);
                while (reader.Read())
                {
                    var hlv = new HuanLuyenVienModel();
                    hlv.DataMap(reader);
                    lstHLV.Add(hlv);
                }
            }
            return lstHLV;
        }

        /// <summary>
        /// Lay danh sach san van dong
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public ObservableCollection<SanVanDongModel> GetDanhSachSVD(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<SanVanDongModel> lstSVD = new ObservableCollection<SanVanDongModel>();
            using (var db = new AutoCommitDbAccessor())
            {

                IDataReader reader = db.Query(GetListSVDSQL);
                while (reader.Read())
                {
                    var svd = new SanVanDongModel();
                    svd.DataMap(reader);
                    lstSVD.Add(svd);
                }
            }
            return lstSVD;
        }

        /// <summary>
        /// Them doi bong nhung chua co cau thu
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool AddDoibongChuaCauThu(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            DoiBongModel doiBong = (DoiBongModel)paramArr[0];
            string maHLVBefore = paramArr[1] as string;
            string maSVDBefore = paramArr[2] as string;
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(AddDoiBongSQL, doiBong.MaDoi, doiBong.TenDoi, doiBong.NamThanhLap
                                                , doiBong.SanVanDong, doiBong.ChuTich, doiBong.HuanLuyenVien
                                                , doiBong.DiaChi, doiBong.SoDienThoai, doiBong.Logo) == 0)
                    {
                        Log.Error("Excute SQl Fail");
                        ((TransactionDbAccessor)db).Rollback();
                        return false;
                    }
                    if (db.NonQuery(UpdateAfterAddDoibong, doiBong.MaDoi, doiBong.SanVanDong, doiBong.HuanLuyenVien,
                                                            maHLVBefore, maSVDBefore) == 0)
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
        /// Xoa doi bong
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool DeleteDoiBong(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            string maDoibong = paramArr[0].ToString();
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(DeleteDoiBongSQL, maDoibong) == 0)
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
                return true;
            }
        }
        #endregion
    }
}
