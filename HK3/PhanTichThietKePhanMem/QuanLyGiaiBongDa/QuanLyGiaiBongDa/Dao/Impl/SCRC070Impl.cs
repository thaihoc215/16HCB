/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 26/04/2017 - SCRC070Impl.cs
 */
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;
using log4net;

namespace QuanLyGiaiBongDa.Dao.Impl
{
    public class SCRC070Impl : ISCRC070
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCRC070Impl));
        #region SQL
        const string GetDoiBongSQL = @"
        Select *
        From HoSoDoiBong
        Where MaDoi = @1";

        const string GetListHLVSQL = @"
            Select *
            From HuanLuyenVien";
        const string GetListSVDSQL = @"
            Select *
            From SanVanDong";
        const string GetListCauThuSQL = @"
            Select 
	            dsct.MaCauThu,
	            dsct.HoTen,
	            dsct.ViTri,
	            vt.TenVT,
	            dsct.SoAo,
	            dsct.QuocTich,
	            dsct.DoiBong,
	            hs.TenDoi,
	            dsct.NgaySinh,
	            dsct.ChieuCao,
	            dsct.CanNang,
	            dsct.AnhDaiDien
            From 
	            DanhSachCauThu dsct,
	            HoSoDoiBong hs,
	            ViTri vt
            Where
	            dsct.DoiBong = hs.MaDoi
	            And dsct.ViTri = vt.MaVT
                And DoiBong = @1";
        const string UpdateDoiBongSQL = @"
            Update HoSoDoiBong
            Set 
	            TenDoi = @2,
	            NamThanhLap = @3,
	            ChuTich = @4,
	            HuanLuyenVien = @5,
                SanVanDong = @6,
	            DoiTruong = @7,
	            DiaChi = @8,
	            SoDienThoai = @9,
	            Logo = @10
            Where MaDoi = @1
            --Set Null MaDoiBong cho HLV va SVD bo chon
            Update HuanLuyenVien
            Set DoiBong = NULL
            Where MaHLV = @11

            Update SanVanDong
            Set DoiBongSoHuu = NULL
            Where MaSan = @12

            --Set MaDoiBong cho HLV va SVD duoc chon  
            Update HuanLuyenVien
            Set DoiBong = @1
            Where MaHLV = @5

            Update SanVanDong
            Set DoiBongSoHuu = @1
            Where MaSan = @6";
        #endregion

        #region ExcuteSQL
        /// <summary>
        /// Lay thong tin day du cua doi bong
        /// </summary>
        /// <param name="paramArr[0]">MaDB</param>
        /// <returns></returns>
        public DoiBongModel GetDoiBong(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            string maDB = (string)paramArr[0];
            var doiBong = new DoiBongModel();
            using (var db = new AutoCommitDbAccessor())
            {
                IDataReader reader = db.Query(GetDoiBongSQL, maDB);
                reader.Read();
                doiBong.DataMap(reader);
            }
            return doiBong;
        }

        /// <summary>
        /// Lay danh sach huan luyen vien
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public ObservableCollection<HuanLuyenVienModel> GetDanhSachHLV(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<HuanLuyenVienModel> lstHLV = new ObservableCollection<HuanLuyenVienModel>();
            using (var db = new AutoCommitDbAccessor())
            {

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
        /// Lay danh sach cau thu doi bong
        /// </summary>
        /// <param name="paramArr[0]">MaDoiBong</param>
        /// <returns></returns>
        public ObservableCollection<CauThuModel> GetDanhSachCauThu(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<CauThuModel> lstCauThu = new ObservableCollection<CauThuModel>();
            using (var db = new AutoCommitDbAccessor())
            {
                string maCT = paramArr[0] as string;
                IDataReader reader = db.Query(GetListCauThuSQL, maCT);
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
        /// Update thong tin doi bong
        /// </summary>
        /// <param name="paramArr[0]">DoiBong model</param>
        /// <returns></returns>
        public bool UpdateDoiBong(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            DoiBongModel dbong = paramArr[0] as DoiBongModel;
            string maHLVBefore = paramArr[1] as string;
            string maSVDBefore = paramArr[2] as string;
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(UpdateDoiBongSQL, dbong.MaDoi, dbong.TenDoi, dbong.NamThanhLap, dbong.ChuTich,
                                                        dbong.HuanLuyenVien, dbong.SanVanDong, dbong.DoiTruong, dbong.DiaChi,
                                                        dbong.SoDienThoai, dbong.Logo,maHLVBefore,maSVDBefore) == 0)
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
                return true;
            }
        }
        #endregion


    }
}
