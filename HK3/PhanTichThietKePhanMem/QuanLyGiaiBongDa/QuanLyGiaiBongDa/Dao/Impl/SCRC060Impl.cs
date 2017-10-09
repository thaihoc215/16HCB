/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 29/03/2017 - SCRC060Impl.cs
 */
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;
using log4net;

namespace QuanLyGiaiBongDa.Dao.Impl
{
    public class SCRC060Impl : ISCRC060
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCRC060Impl));
        #region SQL
        const string LichDauTrongNgaySQL = @"
            Select 
                MaTranDau, 
                db1.MaDoi     MaDoiNha,
				db2.MaDoi     MaDoiKhach,
                db1.TenDoi    TenDoiNha,
                db2.TenDoi    TenDoiKhach,
                Gio, 
                TenSan, 
                ld.Ngay
	        From 
                HoSoDoiBong db1,
                HoSoDoiBong db2,
				LichThiDau ld,
				SanVanDong svd
	        Where 
                db1.MaDoi = ld.DoiNha
                And db2.MaDoi = ld.DoiKhach
				And ld.San = svd.MaSan
                And day(ld.Ngay) = day(getdate()) 
                And month(ld.Ngay) = month(getdate()) 
                And year(ld.Ngay) = year(getdate())";
        const string BangXepHangViTriSQL = @"
            CREATE TABLE #BangXepHang
	        (
		        --Hang			int,
		        MaDoi			char(7)			primary key,
		        TenDoi			nvarchar(50),
		        SoTran			int,
		        Thang			int,
		        Hoa				int,
		        Thua			int,
		        HieuSo			int,
		        BanThang		int,
		        Diem			int
	        )

	        DECLARE 
                @maDoi char(7), 
                @tenDoi nvarchar(50), 
                @soTran int, 
                @thang int, 
                @hoa int, 
                @thua int, 
                @hieuSo int, 
                @diem int, 
                @banThang int
	        DECLARE cur 
            CURSOR FOR 
                    SELECT MaDoi, TenDoi 
                    FROM HoSoDoiBong
	        OPEN cur

	        FETCH NEXT 
                    FROM cur 
                    INTO @maDoi, @tenDoi
	        WHILE @@FETCH_STATUS = 0
	        BEGIN
		        -- Tính số bàn thắng
		        IF (EXISTS (SELECT * FROM LichThiDau LTD, KetQuaTranDau KQTD
					        WHERE LTD.DoiNha=@maDoi and LTD.MaTranDau=KQTD.MaTranDau and KQTD.TinhTrang=1)
			        )
			        SET @banThang = (
								        SELECT SUM(SoBanThangDoiNha)
								        FROM LichThiDau LTD, KetQuaTranDau KQTD
								        WHERE LTD.DoiNha=@maDoi and LTD.MaTranDau=KQTD.MaTranDau and KQTD.TinhTrang=1
							        )
		        ELSE
			        SET @banThang = 0

		        -- Tính bàn thắng sân khách
		        IF (EXISTS (SELECT * 
                            FROM LichThiDau LTD, KetQuaTranDau KQTD
					        WHERE LTD.DoiKhach=@maDoi 
                                  And LTD.MaTranDau=KQTD.MaTranDau 
                                  And KQTD.TinhTrang=1)
			        )
			        SET @banThang = @banThang + 
							        (
								        SELECT SUM(SoBanThangDoiKhach)
								        FROM LichThiDau LTD, KetQuaTranDau KQTD
								        WHERE LTD.DoiKhach=@maDoi 
                                              And LTD.MaTranDau=KQTD.MaTranDau 
                                              And KQTD.TinhTrang=1
							        )

		        -- Tính hiệu số các trận đá trên sân nhà
		        IF (EXISTS (SELECT * 
                            FROM LichThiDau LTD, KetQuaTranDau KQTD
					        WHERE LTD.DoiNha=@maDoi 
                                  And LTD.MaTranDau=KQTD.MaTranDau 
                                  And KQTD.TinhTrang=1))
			        SET @hieuSo = (
							        SELECT SUM(SoBanThangDoiNha-SoBanThangDoiKhach)
							        FROM LichThiDau LTD, KetQuaTranDau KQTD
							        WHERE LTD.DoiNha=@maDoi 
                                          And LTD.MaTranDau=KQTD.MaTranDau 
                                          And KQTD.TinhTrang=1
							        )
		        ELSE
			        SET @hieuSo = 0
		
		        -- Tính hiệu số các trận đá trên sân khách
		        IF (EXISTS (SELECT * 
                            FROM LichThiDau LTD, KetQuaTranDau KQTD
					        WHERE LTD.DoiKhach=@maDoi 
                                  And LTD.MaTranDau=KQTD.MaTranDau 
                                  And KQTD.TinhTrang=1))
		        SET @hieuSo = @hieuSo + (
						        SELECT SUM(SoBanThangDoiKhach-SoBanThangDoiNha)
						        FROM LichThiDau LTD, KetQuaTranDau KQTD
						        WHERE LTD.DoiKhach=@maDoi 
                                      And LTD.MaTranDau=KQTD.MaTranDau and KQTD.TinhTrang=1
						        )
		
		        -- Số trận
		        SET @soTran = (
						        SELECT COUNT(*)
						        FROM LichThiDau LTD, KetQuaTranDau KQTD
						        WHERE LTD.MaTranDau=KQTD.MaTranDau and KQTD.TinhTrang=1 and (DoiNha=@maDoi or DoiKhach=@maDoi)
						        )

		        -- Tính điểm
		        SET @thang = (
						        SELECT COUNT(*)
						        FROM LichThiDau LTD, KetQuaTranDau KQTD
						        WHERE
							        KQTD.TinhTrang = 1 
                                    And LTD.MaTranDau = KQTD.MaTranDau 
                                    And((LTD.DoiNha = @maDoi And KQTD.SoBanThangDoiNha > KQTD.SoBanThangDoiKhach)
								         Or (LTD.DoiKhach=@maDoi And KQTD.SoBanThangDoiKhach>KQTD.SoBanThangDoiNha)))
		        SET @hoa =	(
						        SELECT COUNT(*)
						        FROM LichThiDau LTD, KetQuaTranDau KQTD
						        WHERE
							        KQTD.TinhTrang = 1 
                                    And LTD.MaTranDau = KQTD.MaTranDau 
                                    And
							            (LTD.DoiNha = @maDoi 
                                         Or LTD.DoiKhach = @maDoi)
                                    And KQTD.SoBanThangDoiNha = KQTD.SoBanThangDoiKhach)
		        SET @thua = @soTran - @thang - @hoa

		        DECLARE @diemThang int, @diemHoa int, @diemThua int
		        SET @diemThang = (SELECT GiaTri FROM BangQuyDinh WHERE MaGT = 'Thang')
		        SET @diemHoa = (SELECT GiaTri FROM BangQuyDinh WHERE MaGT = 'Hoa')
		        SET @diemThua = (SELECT GiaTri FROM BangQuyDinh WHERE MaGT = 'Thua')
		
		        SET @diem = @diemThang*@thang + @diemHoa*@hoa + @diemThua*@thua

		        INSERT INTO #BangXepHang(MaDoi, TenDoi, SoTran, Thang, Hoa, Thua, HieuSo, BanThang, Diem)
		        VALUES(@maDoi, @tenDoi, @soTran, @thang, @hoa, @thua, @hieuSo, @banThang, @diem)

		        FETCH NEXT FROM cur INTO @maDoi, @tenDoi
            END

	            CLOSE CUR
	            DEALLOCATE CUR

	            DELETE FROM BangXepHang

	            DECLARE @hang int, @stt int
	            DECLARE cur CURSOR FOR SELECT * FROM #BangXepHang ORDER BY Diem DESC, HieuSo DESC, BanThang DESC
	            OPEN cur
	            SET @stt = 0

	            FETCH NEXT FROM cur INTO @maDoi, @tenDoi, @soTran, @thang, @hoa, @thua, @hieuSo, @banThang, @diem
	            WHILE @@FETCH_STATUS = 0
	            BEGIN
		            SET @stt = @stt + 1

		            IF (NOT EXISTS (SELECT * FROM BangXepHang WHERE Diem=@diem and HieuSo = @hieuSo and BanThang=@banThang) )
			            SET @hang = @stt

		            INSERT INTO BangXepHang(Hang, MaDoi, TenDoi, SoTran, Thang, Hoa, Thua, HieuSo, BanThang, Diem)
		            VALUES(@hang, @maDoi, @tenDoi, @soTran, @thang, @hoa, @thua, @hieuSo, @banThang, @diem)

		            FETCH NEXT FROM cur INTO @maDoi, @tenDoi, @soTran, @thang, @hoa, @thua, @hieuSo, @banThang, @diem
	            END

	            CLOSE CUR
	            DEALLOCATE CUR

	            SELECT * FROM BangXepHang ORDER BY Diem DESC, HieuSo DESC";
        //Delete Doi bong 
        const string DeleteDoiBongSQL = @"
            --update để xóa danh sách
	        UPDATE HoSoDoiBong
	        SET	
                DoiTruong = null, 
                SanVanDong =null, 
                HuanLuyenVien =null
	        Where MaDoi = @1

	        --xóa thẻ
	        DELETE FROM DanhSachThePhat
	        WHERE (TranDau IN(
						        SELECT LTD.MaTranDau 
                                FROM LichThiDau LTD
						        WHERE LTD.DoiKhach=@1 
                                      Or LTD.DoiNha=@1
						        )
			        )

	        --xóa bàn thắng
	        DELETE FROM DanhSachBanThang
	        WHERE (TranDau IN(
						        SELECT LTD.MaTranDau 
                                FROM LichThiDau LTD
						        WHERE LTD.DoiKhach=@1 
                                      Or LTD.DoiNha=@1
						        )
			        )

	        --xóa trận đấu
	        DELETE FROM KetQuaTranDau
	        WHERE (MaTranDau IN (
					        SELECT LTD.MaTranDau 
                            FROM KetQuaTranDau KQ, LichThiDau LTD
					        WHERE KQ.MaTranDau=LTD.MaTranDau 
                                  And (LTD.DoiKhach=@1 Or LTD.DoiNha=@1)
					        )
			        )

	        --update sân vận động
	        UPDATE SanVanDong
	        SET DoiBongSoHuu = null
	        WHERE DoiBongSoHuu = @1

	        --update Huấn luyện viên
	        UPDATE HuanLuyenVien
	        SET DoiBong = null
	        WHERE DoiBong = @1

	        --update cầu thủ
	        UPDATE DanhSachCauThu
	        SET DoiBong = null
	        Where DoiBong = @1

	        --xóa lịch thi đấu
	        DELETE FROM LichThiDau
	        WHERE LichThiDau.DoiKhach=@1 
                  Or LichThiDau.DoiNha=@1

	        --Xóa đội bóng trong BXH
	        Delete BangXepHang
	        Where MaDoi = @1
	        --xóa đội
	        Delete HoSoDoiBong
	        Where MaDoi = @1";
        const string GetListCauThuAvaSQL = @"
            Select 
		        ds.MaCauThu,
		        ds.AnhDaiDien
            From 
		        DanhSachCauThu ds 
            Where
		        ds.DoiBong = @1";
        #endregion

        #region Execute SQL
        /// <summary>
        /// Lay danh sach Tran dau trong ngay
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public ObservableCollection<TranDauModel> GetLichDauTrongNgay(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<TranDauModel> lstTranDau = new ObservableCollection<TranDauModel>();
            using (var db = new AutoCommitDbAccessor())
            {

                IDataReader reader = db.Query(LichDauTrongNgaySQL);
                while (reader.Read())
                {
                    var tranDau = new TranDauModel();
                    tranDau.DataMap(reader);
                    lstTranDau.Add(tranDau);
                }
            }
            return lstTranDau;
        }

        /// <summary>
        /// Lay danh sach doi bong theo bang xep hang
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public ObservableCollection<BangXepHangModel> GetBangXepHang(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<BangXepHangModel> lstBXH = new ObservableCollection<BangXepHangModel>();
            using (var db = new AutoCommitDbAccessor())
            {
                IDataReader reader = db.Query(BangXepHangViTriSQL);
                while (reader.Read())
                {
                    var doiBong = new BangXepHangModel();
                    doiBong.DataMap(reader);
                    lstBXH.Add(doiBong);
                }
            }
            return lstBXH;
        }

        //Tien hanh xoa mot doi bong
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

                IDataReader reader = db.Query(GetListCauThuAvaSQL, paramArr[0].ToString());
                while (reader.Read())
                {
                    var cauThu = new CauThuModel();
                    cauThu.DataMap(reader);
                    lstCauThu.Add(cauThu);
                }
            }
            return lstCauThu;
        }
        #endregion
    }
}
