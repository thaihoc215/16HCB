/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 15/04/2017 - SCRC051Impl.cs
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
    public class SCRC051Impl : ISCRC051
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCRC051Impl));
        #region SQL
        const string GetKetQuaTranDauSQL = @"
            Select 
                kqtd.MaTranDau, 
                kqtd.SoBanThangDoiNha, 
                kqtd.SoBanThangDoiKhach, 
                tt.MaTinhTrang, 
                tt.TenTinhTrang
            From 
                KetQuaTranDau kqtd,
				TinhTrangTranDau tt
            Where 
                MaTranDau = @1
				And tt.MaTinhTrang = kqtd.TinhTrang";
        const string GetTinhTrangSQL = @"
            Select *
            From TinhTrangTranDau";
        const string GetBanThangTranDauSQL = @"
            Select 
                dsbt.MaBanThang, 
                dsct.HoTen, 
                hs.TenDoi, 
                lbt.TenLoai, 
                dsbt.ThoiDiem
	        From 
                DanhSachBanThang dsbt, 
                DanhSachCauThu dsct, 
                LoaiBanThang lbt, 
                HoSoDoiBong hs
	        Where 
                TranDau = @1
                and dsbt.CauThuGhiBan = dsct.MaCauThu 
                and dsbt.DoiBong = hs.MaDoi 
                and dsbt.LoaiBanThang = lbt.MaLoai";
        const string UpdateKetQuaSQL = @"
                Update KetQuaTranDau
	            Set TinhTrang = @1,
	            SoBanThangDoiNha  = @2,
	            SoBanThangDoiKhach = @3
	            Where MaTranDau = @4";
        //Them ban thang
        const string DeleteBanThangSQL = @"
            Delete DanhSachBanThang Where MaBanThang = @1";
        const string GetMaBanThangMaxSQL = @"
            Select Max(MaBanThang)
            From DanhSachBanThang";
        const string AddBanThangSQL = @"
            Insert Into DanhSachBanThang(
                MaBanThang, 
                CauThuGhiBan, 
                LoaiBanThang, 
                DoiBong, 
                TranDau, 
                ThoiDiem)
	        Values(@1,@2,@3,
                    @4,@5,@6)";
        const string GetDoiBongTranDauSQL = @"
            Select MaDoi,TenDoi
	        From HoSoDoiBong
	        Where MaDoi = @1 or MaDoi = @2";
        const string GetListCauThuDoiBongSQL = @"
            Select *
            From DanhSachCauThu
            Where DoiBong = @1";
        const string GetListLoaiBanThangSQL = @"
            Select *
		    From LoaiBanThang";

        #endregion

        #region ExecuteSQL

        #region Ket Qua Tran Dau
        //Lay ket qua cua trang dau
        public KetQuaTranDauModel GetKetQuaTranDau(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            string maTran = (string)paramArr[0];
            KetQuaTranDauModel ketQua = new KetQuaTranDauModel();
            using (var db = new AutoCommitDbAccessor())
            {

                IDataReader reader = db.Query(GetKetQuaTranDauSQL, maTran);
                reader.Read();
                ketQua.DataMap(reader);

            }
            return ketQua;
        }

        //Lay danh sach tinh trang tran dau
        public Dictionary<int, string> GetListTinhTrang(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            Dictionary<int, string> lstTinhTrang = new Dictionary<int, string>();
            using (var db = new AutoCommitDbAccessor())
            {

                IDataReader reader = db.Query(GetTinhTrangSQL);
                while (reader.Read())
                {
                    int maTinhTrang = Convert.ToInt32(reader["MaTinhTrang"]);
                    string tenTinhTrang = Convert.ToString(reader["TenTinhTrang"]);
                    lstTinhTrang.Add(maTinhTrang, tenTinhTrang);
                }
            }
            return lstTinhTrang;
        }

        public bool UpdateTranDau(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            KetQuaTranDauModel ketQua = (KetQuaTranDauModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(UpdateKetQuaSQL, ketQua.MaTinhTrang,ketQua.SoBanThangDoiNha,ketQua.SoBanThangDoiKhach,ketQua.MaTranDau) == 0)
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

        public ObservableCollection<BanThangModel> GetListBanThang(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            string maTran = (string)paramArr[0];
            ObservableCollection<BanThangModel> lstBanThang = new ObservableCollection<BanThangModel>();
            using (var db = new AutoCommitDbAccessor())
            {

                IDataReader reader = db.Query(GetBanThangTranDauSQL, maTran);
                while (reader.Read())
                {
                    var banThang = new BanThangModel();
                    banThang.DataMap(reader);
                    lstBanThang.Add(banThang);
                }
            }
            return lstBanThang;
        }
        #endregion

        #region Them Xoa Ban Thang
        
        //Xoa ban thang trong dang sach ban thang
        public bool DeleteBanThang(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            string maBanThang = (string)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(DeleteBanThangSQL, maBanThang) == 0)
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

        //Lay danh sach doi bong trong tran dau
        public ObservableCollection<DoiBongModel> GetListDoiBong(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            string db1 = (string)paramArr[0];
            string db2 = (string)paramArr[1];
            ObservableCollection<DoiBongModel> lstDoiBong = new ObservableCollection<DoiBongModel>();
            using (var db = new AutoCommitDbAccessor())
            {

                IDataReader reader = db.Query(GetDoiBongTranDauSQL, db1, db2);
                while (reader.Read())
                {
                    var doiBong = new DoiBongModel();
                    doiBong.DataMap(reader);
                    lstDoiBong.Add(doiBong);
                }
            }
            return lstDoiBong;
        }

        //lay danh sach cau thu trong tran dau
        public ObservableCollection<CauThuModel> GetListCauThu(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            string doiBong = (string)paramArr[0];
            ObservableCollection<CauThuModel> lstCauThu = new ObservableCollection<CauThuModel>();
            using (var db = new AutoCommitDbAccessor())
            {

                IDataReader reader = db.Query(GetListCauThuDoiBongSQL, doiBong);
                while (reader.Read())
                {
                    var cauThu = new CauThuModel();
                    cauThu.DataMap(reader);
                    lstCauThu.Add(cauThu);
                }
            }
            return lstCauThu;
        }

        //Lay loai ban thang
        public Dictionary<string, string> GetListLoaiBanThang(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            Dictionary<string, string> lstLoaiBan = new Dictionary<string, string>();
            using (var db = new AutoCommitDbAccessor())
            {

                IDataReader reader = db.Query(GetListLoaiBanThangSQL);
                while (reader.Read())
                {
                    string maLoai = Convert.ToString(reader["MaLoai"]);
                    string tenLoai = Convert.ToString(reader["TenLoai"]);
                    lstLoaiBan.Add(maLoai, tenLoai);
                }
            }
            return lstLoaiBan;
        }

        //Lay ma ban thang max
        public string GetMaxMaBT(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            using (var db = new AutoCommitDbAccessor())
            {
                try
                {
                    return db.Scalar<string>(GetMaBanThangMaxSQL);
                }
                catch
                {
                    return "BT00000";
                }
            }
        }
        //Them ban thang
        public bool AddBanThang(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            BanThangModel banThang = (BanThangModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(AddBanThangSQL, banThang.MaBanThang,banThang.MaCauThu,banThang.LoaiBanThang,
                                                    banThang.DoiBong,banThang.TranDau,banThang.ThoiDiem) == 0)
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
        #endregion
    }
}
