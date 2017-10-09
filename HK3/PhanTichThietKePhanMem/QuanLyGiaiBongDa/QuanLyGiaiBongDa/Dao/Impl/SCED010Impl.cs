/*
 * 1642024 - Ung Buu Tri Hung
 * 04/04/2017 - 2:40 PM - SCED010Impl.cs
 */
using log4net;
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace QuanLyGiaiBongDa.Dao.Impl
{
    public class SCED010Impl : ISCED010
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCED010Impl));
        #region SQL
        const string LstNguoiDungSQL = @"
            Select nv.MaNV,nv.HoTen,nv.NgaySinh,nv.GioiTinh,
		            nv.DienThoai,nv.Email,nv.DiaChi,nv.CMND,nv.Pass,
		            nv.LoaiNV,lnv.TenLoai
            From NhanVien nv, LoaiNV lnv
            Where nv.LoaiNV = lnv.MaLoai";

        const string LstLoaiNVSQL = @"
            Select *
            From LoaiNV";

        const string CountNVSQL = @"
            Select Max(MaNV)
            From NhanVien";

        const string CapTaiKhoanSQL = @"
            Insert Into 
                NhanVien(MaNV,HoTen,NgaySinh,GioiTinh,DienThoai,Email,DiaChi,CMND,Pass,LoaiNV)
	        Values 
                (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10)";

        const string SuaTaiKhoanSQL = @"
            Update NhanVien
            Set
                HoTen = @2,
                NgaySinh = @3,
                GioiTinh = @4,
                DienThoai = @5,
                Email = @6,
                DiaChi = @7,
                CMND = @8,
                Pass = @9,
                LoaiNV = @10
            Where MaNV = @1";

        const string XoaTaiKhoanSQL = @"
            Delete from NhanVien
            Where MaNV = @1";
        #endregion

        #region Excute SQL
        /// <summary>
        /// Lay danh sach nguoi dung
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public ObservableCollection<NguoiDungModel> GetListNguoiDung(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<NguoiDungModel> lstNguoiDung = new ObservableCollection<NguoiDungModel>();
            using (var db = new AutoCommitDbAccessor())
            {
                IDataReader reader = db.Query(LstNguoiDungSQL);
                while (reader.Read())
                {
                    var nguoiDung = new NguoiDungModel();
                    nguoiDung.DataMap(reader);
                    lstNguoiDung.Add(nguoiDung);
                }
            }
            return lstNguoiDung;
        }


        /// <summary>
        /// Lay danh sach loai NV
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public ObservableCollection<LoaiNVModel> GetListLoaiNV(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<LoaiNVModel> lstLoaiNV = new ObservableCollection<LoaiNVModel>();
            using (var db = new AutoCommitDbAccessor())
            {
                IDataReader reader = db.Query(LstLoaiNVSQL);
                while (reader.Read())
                {
                    var loaiNV = new LoaiNVModel();
                    loaiNV.DataMap(reader);
                    lstLoaiNV.Add(loaiNV);
                }
            }
            return lstLoaiNV;
        }

        /// <summary>
        /// Lay chuoi NV co chi so max
        /// </summary>
        /// <returns></returns>
        public int CountNV(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            using (var db = new AutoCommitDbAccessor())
            {
                return db.Scalar<int>(CountNVSQL);
            }
        }

        /// <summary>
        /// Cấp tài khoản mới
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        /// 

        public bool CapTaiKhoan(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            NguoiDungModel model = (NguoiDungModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(CapTaiKhoanSQL,model.MaNV,model.HoTen,model.NgaySinh,
                        model.GioiTinh,model.DienThoai,model.Email,
                        model.DiaChi,model.CMND,model.Pass,model.LoaiNV) == 0)
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
        /// Sửa tài khoản
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        /// 

        public bool SuaTaiKhoan(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            NguoiDungModel model = (NguoiDungModel)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(SuaTaiKhoanSQL, model.MaNV, model.HoTen, model.NgaySinh, 
                                                    model.GioiTinh, model.DienThoai, model.Email, 
                                                    model.DiaChi, model.CMND, model.Pass, model.LoaiNV) == 0)
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
        /// Xóa tài khoản
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        /// 

        public bool XoaTaiKhoan(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            int MaNV = (int)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(XoaTaiKhoanSQL, MaNV) == 0)
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
