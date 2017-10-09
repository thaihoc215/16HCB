/*
 * 1642024 - Ung Buu Tri Hung
 * 01/05/2017 - 6:30 PM - SCRC080Impl.cs
 */
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;
using log4net;

namespace QuanLyGiaiBongDa.Dao.Impl
{
    public class SCRC080Impl : ISCRC080
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCRC080Impl));
        #region SQL
        const string LoadQuyDinhSQL = @"
            Select *
            From BangQuyDinh";

        const string LoadLoaiBanThangSQL = @"
            Select *
            From LoaiBanThang";

        const string XoaQuyDinhCuSQL = @"truncate table BangQuyDinh";

        const string ThemQuyDinhMoiSQL = @"
            Insert Into
                BangQuyDinh(MaGT,GiaTri)
            Values
                (@1,@2),
                (@3,@4),
                (@5,@6),
                (@7,@8),
                (@9,@10),
                (@11,@12),
                (@13,@14),
                (@15,@16),
                (@17,@18)";
        const string CountMaxLoaiBTSQL = @"
            Select Max(MaLoai)
			From LoaiBanThang";

        const string DeleteLoaiBanThangSQL = @"
            Update DanhSachBanThang
            Set LoaiBanThang = NULL
            Where LoaiBanThang = @1
            Delete LoaiBanThang
	        Where MaLoai = @1";

        const string ThemLoaiBanThangMoiSQL = @"
            insert Into
                LoaiBanThang(MaLoai,TenLoai)
            Values
                (@1,@2)";
        const string UpdateLoaiBanThangSQL = @"
            Update LoaiBanThang
            Set TenLoai = @2
            Where MaLoai = @1";

        const string UpdateQD1SQL = @"
            Update BangQuyDinh
            Set GiaTri = @1
            Where MaGT = 'SoLuongMin'
            Update BangQuyDinh
            Set GiaTri = @2
            Where MaGT = 'SoLuongMax'
            Update BangQuyDinh
            Set GiaTri = @3
            Where MaGT = 'TuoiMin'
            Update BangQuyDinh
            Set GiaTri = @4
            Where MaGT = 'TuoiMax'
            Update BangQuyDinh
            Set GiaTri = @5
            Where MaGT = 'CTNgoai'";
        const string UpdateQD3SQL = @"
            Update BangQuyDinh
            Set GiaTri = @1
            Where MaGT = 'TDGhiBan'";
        const string UpdateQD4SQL = @"
            Update BangQuyDinh
            Set GiaTri = @1
            Where MaGT = 'Thang'
            Update BangQuyDinh
            Set GiaTri = @2
            Where MaGT = 'Hoa'
            Update BangQuyDinh
            Set GiaTri = @3
            Where MaGT = 'Thua'";
        #endregion

        #region Excute SQL
        /// <summary>
        /// Load quy định
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        /// 
        public QuyDinhModel LoadQuyDinh(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            QuyDinhModel qd = new QuyDinhModel();
            using (var db = new AutoCommitDbAccessor())
            {
                IDataReader reader = db.Query(LoadQuyDinhSQL);
                while (reader.Read())
                {
                    string loaiQD = reader.GetValue(0).ToString();
                    switch (loaiQD.Trim())
                    {
                        case "TuoiMin":
                            qd.TuoiMin = Int32.Parse(reader.GetValue(1).ToString());
                            break;
                        case "TuoiMax":
                            qd.TuoiMax = Int32.Parse(reader.GetValue(1).ToString());
                            break;
                        case "SoLuongMin":
                            qd.SoLuongMin = Int32.Parse(reader.GetValue(1).ToString());
                            break;
                        case "SoLuongMax":
                            qd.SoLuongMax = Int32.Parse(reader.GetValue(1).ToString());
                            break;
                        case "CTNgoai":
                            qd.CTNgoai = Int32.Parse(reader.GetValue(1).ToString());
                            break;
                        case "TDGhiBan":
                            qd.TDGhiBan = Int32.Parse(reader.GetValue(1).ToString());
                            break;
                        case "Thang":
                            qd.Thang = Int32.Parse(reader.GetValue(1).ToString());
                            break;
                        case "Hoa":
                            qd.Hoa = Int32.Parse(reader.GetValue(1).ToString());
                            break;
                        case "Thua":
                            qd.Thua = Int32.Parse(reader.GetValue(1).ToString());
                            break;
                        default:
                            break;
                    }
                }
            }
            return qd;
        }

        /// <summary>
        /// Load loại bàn thắng
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public ObservableCollection<LoaiBanThangModel> LoadLoaiBanThang(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<LoaiBanThangModel> lstLoaiBanThang = new ObservableCollection<LoaiBanThangModel>();
            using (var db = new AutoCommitDbAccessor())
            {
                IDataReader reader = db.Query(LoadLoaiBanThangSQL);
                while (reader.Read())
                {
                    var loaiBanThang = new LoaiBanThangModel();
                    loaiBanThang.DataMap(reader);
                    lstLoaiBanThang.Add(loaiBanThang);
                }
            }
            return lstLoaiBanThang;
        }

        public string CountMaxLoaiBT(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            using (var db = new AutoCommitDbAccessor())
            {
                return db.Scalar<string>(CountMaxLoaiBTSQL);
            }
        }

        /// <summary>
        /// Them loai ban thang
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool AddLoaiBanThang(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            LoaiBanThangModel lbt = (LoaiBanThangModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                        if (db.NonQuery(ThemLoaiBanThangMoiSQL, lbt.MaLoai, lbt.TenLoai) == 0)
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
        /// Xoa loai ban thang
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool DeleteLoaiBanThang(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            LoaiBanThangModel lbt = (LoaiBanThangModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(DeleteLoaiBanThangSQL, lbt.MaLoai) == 0)
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
        /// Update loai ban thang
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool UpdateLoaiBanThang(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            LoaiBanThangModel lbt = (LoaiBanThangModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(UpdateLoaiBanThangSQL, lbt.MaLoai,lbt.TenLoai) == 0)
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
        public bool UpdateQD1(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            QuyDinhModel model = (QuyDinhModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(UpdateQD1SQL, model.SoLuongMin, model.SoLuongMax,
                                                model.TuoiMin, model.TuoiMax,
                                                model.CTNgoai) == 0)
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
                    throw;
                }
            }
            return true;
        }

        public bool UpdateQD3(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            QuyDinhModel model = (QuyDinhModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(UpdateQD3SQL, model.TDGhiBan) == 0)
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
                    throw;
                }
            }
            return true;
        }

        public bool UpdateQD4(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            QuyDinhModel model = (QuyDinhModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(UpdateQD4SQL, model.Thang, model.Hoa, model.Thua) == 0)
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
                    throw;
                }
            }
            return true;
        }

        #endregion
    }
}
