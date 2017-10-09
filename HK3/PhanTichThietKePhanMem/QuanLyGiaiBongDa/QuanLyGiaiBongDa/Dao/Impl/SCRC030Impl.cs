/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 15/04/2017 - SCRC030Impl.cs
 */
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using log4net;

namespace QuanLyGiaiBongDa.Dao.Impl
{
    public class SCRC030Impl : ISCRC030
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCRC030Impl));
        #region SQL
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
	            And dsct.ViTri = vt.MaVT";
        const string GetListDoiBongSQL = @" 
            Select *
            From HoSoDoiBong";
        const string GetListVitriSQL = @"
            Select *
            From ViTri";
        const string SearchCauThuSQL = @"
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
                And (dsct.MaCauThu = @1
						Or dsct.HoTen Like @2)
				And dsct.DoiBong Like @3";

        const string GetMaxCauThuSQL = @"
            Select Max(MaCauThu)
            From DanhSachCauThu";

        const string AddCauThuSQL = @"
            Insert Into DanhSachCauThu(
                        MaCauThu, SoAo, HoTen, 
                        QuocTich, ViTri, NgaySinh, 
                        DoiBong, ChieuCao, CanNang, AnhDaiDien)
            Values (
                        @1, @2, @3, 
                        @4, @5, @6,
                        @7, @8, @9, @10)";
        const string UpdateCauThuSQL = @"
            Update DanhSachCauThu
            Set 
                SoAo = @1,
                HoTen = @2,        
	            QuocTich = @3,
	            ViTri = @4,
	            NgaySinh = @5,
	            DoiBong = @6,
                ChieuCao = @7, 
                CanNang = @8,
                AnhDaiDien = @10
	        Where MaCauThu = @9";
        const string DeleteCauThuSQL = @"
            Update HoSoDoiBong
	        Set DoiTruong = null
	        Where DoiTruong = @1
            
            Delete DanhSachBanThang
	        Where CauThuGhiBan = @1
	        
            Delete DanhSachCauThu 
            Where MaCauThu = @1";
        const string GetQuyDinhSQL = @"
            Select * From BangQuyDinh";
        #endregion

        #region ExecuteSQL
        #endregion
        public ObservableCollection<CauThuModel> GetListCauThu(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<CauThuModel> lstCauThu = new ObservableCollection<CauThuModel>();
            using (var db = new AutoCommitDbAccessor())
            {

                IDataReader reader = db.Query(GetListCauThuSQL);
                while (reader.Read())
                {
                    var cauThu = new CauThuModel();
                    cauThu.DataMap(reader);
                    lstCauThu.Add(cauThu);
                }
            }
            return lstCauThu;
        }
        //lay danh scach doi bong
        public ObservableCollection<DoiBongModel> GetListDoiBong(params object[] paramArr)
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
        //lay danh sach vi tri cua cau thu
        public ObservableCollection<ViTriModel> GetListViTri(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<ViTriModel> lstViTri = new ObservableCollection<ViTriModel>();
            using (var db = new AutoCommitDbAccessor())
            {

                IDataReader reader = db.Query(GetListVitriSQL);
                while (reader.Read())
                {
                    var viTri = new ViTriModel();
                    viTri.DataMap(reader);
                    lstViTri.Add(viTri);
                }
            }
            return lstViTri;
        }

        //Tim kiem cau thu
        public ObservableCollection<CauThuModel> SearchCauThu(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            int maCT = -1;
            if (!Int32.TryParse(paramArr[0].ToString(), out maCT))
            {
                maCT = -1;
            }
            string tenCT = "%" + paramArr[0].ToString().Trim() + "%";
            string maDB = (string)paramArr[1];
            ObservableCollection<CauThuModel> lstCauThu = new ObservableCollection<CauThuModel>();
            using (var db = new AutoCommitDbAccessor())
            {

                IDataReader reader = db.Query(SearchCauThuSQL, maCT, tenCT, maDB);
                while (reader.Read())
                {
                    var cauThu = new CauThuModel();
                    cauThu.DataMap(reader);
                    lstCauThu.Add(cauThu);
                }
            }
            return lstCauThu;
        }

        /// <summary>
        /// Dem so luong cau thu
        /// </summary>
        /// <param name="parArr"></param>
        /// <returns></returns>
        public int GetMaxCauThu(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            using (var db = new AutoCommitDbAccessor())
            {
                return db.Scalar<int>(GetMaxCauThuSQL);
            }
        }

        /// <summary>
        /// Them cau thu vao doi bong hien tai
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool AddCauThu(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            CauThuModel ct = (CauThuModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(AddCauThuSQL, ct.MaCauThu, ct.SoAo, ct.HoTen,
                                                    ct.QuocTich, ct.ViTri, ct.NgaySinh,
                                                    ct.DoiBong, ct.ChieuCao, ct.CanNang,ct.AnhDaiDien) == 0)
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
        /// <summary>
        /// Thay doi thong tin cau thu
        /// </summary>
        /// <param name="paramArr">CauThuItem</param>
        /// <returns>Ket qua thay doi thong tin</returns>
        public bool UpdateCauThu(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            CauThuModel ct = (CauThuModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(UpdateCauThuSQL, ct.SoAo, ct.HoTen,
                                                    ct.QuocTich, ct.ViTri, ct.NgaySinh,
                                                    ct.DoiBong, ct.ChieuCao, ct.CanNang, ct.MaCauThu,ct.AnhDaiDien) == 0)
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
        /// <summary>
        /// Xoa cau thu
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool DeleteCauThu(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            int maCT = (int)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(DeleteCauThuSQL, maCT) == 0)
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

        /// <summary>
        /// Lay danh sach quy dinh cua giai dau
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns>Danh sach quy dinh cua giai dau</returns>
        public Dictionary<string, int> GetListQuyDinh(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            Dictionary<string, int> lstQuyDinh = new Dictionary<string, int>();
            using (var db = new AutoCommitDbAccessor())
            {

                IDataReader reader = db.Query(GetQuyDinhSQL);
                while (reader.Read())
                {
                    string maQD = Convert.ToString(reader["MaGT"]);
                    int giaTriQD = Convert.ToInt32(reader["GiaTri"]);
                    lstQuyDinh.Add(maQD, giaTriQD);
                }
            }
            return lstQuyDinh;
        }
    }
}
