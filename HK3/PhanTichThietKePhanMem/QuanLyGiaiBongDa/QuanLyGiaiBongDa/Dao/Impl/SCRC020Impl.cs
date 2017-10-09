/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 25/03/2017 - SCRC020Impl.cs
 */
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Models;
using System.Collections.ObjectModel;
using System.Data;
using log4net;

namespace QuanLyGiaiBongDa.Dao.Impl
{
    public class SCRC020Impl : ISCRC020
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCRC020Impl));
        #region SQL
        const string LstTrongTaiSQL = @"
            Select *
            From TrongTai";

        const string LstSVDSQL = @"
            Select *
	        From 
                SanVanDong";

//        const string LstHLVSQL = @"
//            Select 
//                MaHLV,
//                TenHLV,
//                NgaySinh,
//                GioiTinh,
//                DoiBong,
//                TroLy,
//                hs.TenDoi
//            From 
//                HuanLuyenVien, 
//                HoSoDoiBong hs 
//            Where 
//                DoiBong = hs.MaDoi";
        const string LstHLVSQL = @"
            Select *
	        From 
                HuanLuyenVien";

        const string LstThePhatSQL = @"
            Select 
                dst.MaThePhat, 
                dst.TranDau,
                dst.TrongTai,
				tt.TenTrongTai,
				dst.LoaiThe,
                ltp.TenLoai, 
                dst.ThoiDiem, 
				dst.CauThu,
                ds.HoTen     
	        From 
                DanhSachThePhat dst, 
                LoaiThePhat ltp, 
				DanhSachCauThu ds,
				TrongTai tt
	        Where 
                dst.CauThu = ds.MaCauThu 
				and ltp.MaThe = dst.LoaiThe
				and tt.MaTrongTai = dst.TrongTai";

        const string LstBanThangSQL = @"
            Select 
                dsct.MaCauThu, 
                dsct.HoTen, 
                dsct.SoAo, 
                hs.TenDoi, 
                COUNT(dsbt.MaBanThang) as SoBanThang
	        From 
                DanhSachCauThu dsct, 
                DanhSachBanThang dsbt, 
                HoSoDoiBong hs
	        Where 
                dsct.MaCauThu = dsbt.CauThuGhiBan
                and dsct.DoiBong = hs.MaDoi 
                and not (dsbt.LoaiBanThang = 'OG')
	        Group by 
                dsct.MaCauThu,
		        dsct.HoTen,
		        dsct.SoAo,
		        hs.TenDoi
	        order by  
                SoBanThang desc";

        const string GetListDoiBongSQL = @"
            Select *
            From HoSoDoiBong";
        #endregion

        #region Excute SQL
        /// <summary>
        /// Lay danh sach tron tai
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public ObservableCollection<TrongTaiModel> GetListTrongTai(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<TrongTaiModel> lstTrongTai = new ObservableCollection<TrongTaiModel>();
            using (var db = new AutoCommitDbAccessor())
            {


                IDataReader reader = db.Query(LstTrongTaiSQL);
                while (reader.Read())
                {
                    var trongTai = new TrongTaiModel();
                    trongTai.DataMap(reader);
                    lstTrongTai.Add(trongTai);
                }
            }
            return lstTrongTai;
        }

        /// <summary>
        /// Lay danh sach san van dong
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public ObservableCollection<SanVanDongModel> GetListSanVanDong(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<SanVanDongModel> lstSanVanDong = new ObservableCollection<SanVanDongModel>();
            using (var db = new AutoCommitDbAccessor())
            {


                IDataReader reader = db.Query(LstSVDSQL);
                while (reader.Read())
                {
                    var sanVanDong = new SanVanDongModel();
                    sanVanDong.DataMap(reader);
                    lstSanVanDong.Add(sanVanDong);
                }
            }
            return lstSanVanDong;
        }

        /// <summary>
        /// Lay danh sach Huan Luyen Vien
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public ObservableCollection<HuanLuyenVienModel> GetListHuanLuyenVien(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<HuanLuyenVienModel> lstHuanLuyenVien = new ObservableCollection<HuanLuyenVienModel>();
            using (var db = new AutoCommitDbAccessor())
            {
                IDataReader reader = db.Query(LstHLVSQL);
                while (reader.Read())
                {
                    var huanLuyenVien = new HuanLuyenVienModel();
                    huanLuyenVien.DataMap(reader);
                    lstHuanLuyenVien.Add(huanLuyenVien);
                }
            }
            return lstHuanLuyenVien;
        }

        /// <summary>
        /// Lay danh sach the phat
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public ObservableCollection<ThePhatModel> GetListThePhat(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<ThePhatModel> lstThePhat = new ObservableCollection<ThePhatModel>();
            using (var db = new AutoCommitDbAccessor())
            {
                IDataReader reader = db.Query(LstThePhatSQL);
                while (reader.Read())
                {
                    var thePhat = new ThePhatModel();
                    thePhat.DataMap(reader);
                    lstThePhat.Add(thePhat);
                }
            }
            return lstThePhat;
        }


        /// <summary>
        /// Lay danh sach ban thang
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public ObservableCollection<BanThangModel> GetListBanThang(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<BanThangModel> lstBanThang = new ObservableCollection<BanThangModel>();
            using (var db = new AutoCommitDbAccessor())
            {
                IDataReader reader = db.Query(LstBanThangSQL);
                while (reader.Read())
                {
                    var banThang = new BanThangModel();
                    banThang.DataMap(reader);
                    lstBanThang.Add(banThang);
                }
            }
            return lstBanThang;
        }

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
        #endregion
    }
}
