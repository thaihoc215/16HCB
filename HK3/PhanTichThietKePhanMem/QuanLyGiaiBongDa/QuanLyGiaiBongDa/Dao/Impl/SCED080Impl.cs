/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 04/04/2017 - SCED080Impl.cs
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
    public class SCED080Impl : ISCED080
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCED080Impl));
        #region SQL
        const string GetListViTriSQL = @"
            Select * 
            From ViTri";

        const string GetListCauThuSQL = @"
            Select 
		        ds.MaCauThu,
		        ds.SoAo, 
		        ds.HoTen,
		        ds.QuocTich, 
		        ds.ViTri,
		        vt.TenVT,
		        ds.NgaySinh,
		        ds.DoiBong, 
		        hs.TenDoi, 
		        ds.ChieuCao,
		        ds.CanNang,
		        ds.AnhDaiDien
            From 
		        DanhSachCauThu ds, 
		        ViTri vt, 
		        HoSoDoiBong hs
            Where
		        ds.DoiBong = @1 And
		        hs.MaDoi = ds.DoiBong And
		        ds.ViTri = vt.MaVT";

        const string GetMaxCauThuSQL = @"
            Select Max(MaCauThu)
            From DanhSachCauThu";

        const string SetDoiTruongSQL = @"
            Update HoSoDoiBong
            Set DoiTruong = @1
            Where MaDoi = @2";

        const string AddCauThuSQL = @"
            Insert Into DanhSachCauThu(
                        MaCauThu, SoAo, HoTen, 
                        QuocTich, ViTri, NgaySinh, 
                        DoiBong, ChieuCao, CanNang, AnhDaiDien)
            Values (
                        @1, @2, @3, 
                        @4, @5, @6,
                        @7, @8, @9, @10)";

        const string DeleteCauThuSQL = @"
            Update HoSoDoiBong
	        Set DoiTruong = null
	        Where DoiTruong = @1

	        Delete DanhSachCauThu 
            Where MaCauThu = @1";

        const string GetQuyDinhSQL = @"
            Select * From BangQuyDinh";
        #endregion

        #region ExecuteSQL
        /// <summary>
        /// Lay danh sach vi tri cua cau thu
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public ObservableCollection<ViTriModel> GetDanhSachViTri(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<ViTriModel> lstViTri = new ObservableCollection<ViTriModel>();
            using (var db = new AutoCommitDbAccessor())
            {

                IDataReader reader = db.Query(GetListViTriSQL);
                while (reader.Read())
                {
                    var viTri = new ViTriModel();
                    viTri.DataMap(reader);
                    lstViTri.Add(viTri);
                }
            }
            return lstViTri;
        }
        /// <summary>
        /// Lay danh sach cau thu trong mot doi bong
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public ObservableCollection<CauThuModel> GetDsCauThuDoiBong(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<CauThuModel> lstCauThu = new ObservableCollection<CauThuModel>();
            using (var db = new AutoCommitDbAccessor())
            {

                IDataReader reader = db.Query(GetListCauThuSQL,paramArr[0].ToString());
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
        /// Set doi truong cho doi bong
        /// </summary>
        /// <param name="parArr"></param>
        /// <returns></returns>
        public bool SetDoiTruong(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            CauThuModel ct = (CauThuModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(SetDoiTruongSQL, ct.MaCauThu,ct.DoiBong) == 0)
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
        /// Xoa cau thu them gan day
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
        #endregion
    }
}
