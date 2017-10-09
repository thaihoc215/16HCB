/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 17/03/2017 - SCLG010DAO
 */
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Models;
using System;
using System.Data;
using log4net;

namespace QuanLyGiaiBongDa.Dao.Impl
{
    public class SCLG010Impl : ISCLG010
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCLG010Impl));
        #region SQL
        //Lay thong tin dang nhap
        const string UserInfo = @"
            Select *
            From NhanVien nv, LoaiNV lnv
            Where (nv.MaNV = @1 Or nv.Email = @2)
                    And Pass = @3
				    and nv.LoaiNV = lnv.MaLoai";
        #endregion

        #region ExcuteSQL
        public NguoiDungModel GetUser(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            int maNV;
            string email = (string)paramArr[0];
            if (!Int32.TryParse(email, out maNV))
                maNV = -1;
            string pass = (string)paramArr[1];
            using (var db = new AutoCommitDbAccessor())
            {
                NguoiDungModel userModel = new NguoiDungModel();

                IDataReader reader = db.Query(UserInfo, maNV, email, pass);
                if (reader.Read() == false)
                    return null;
                else
                    userModel.DataMap(reader);
                return userModel;
            }
        }
        #endregion
    }
}
