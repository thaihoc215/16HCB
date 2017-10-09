/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 14/04/2017 - SCRC050Impl.cs
 */
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;
using log4net;

namespace QuanLyGiaiBongDa.Dao.Impl
{
    public class SCRC050Impl: ISCRC050
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCRC050Impl));
        #region SQL
        const string LichThiDauSQL = @"
            Select 
                MaTranDau,
                VongDau,
				db1.MaDoi     MaDoiNha,
				db2.MaDoi     MaDoiKhach,
                db1.TenDoi    TenDoiNha,
                db2.TenDoi    TenDoiKhach,
                ld.San,
				svd.TenSan,				
                ld.TrongTai,
				tt.TenTrongTai,
                ld.Ngay,
                ld.Gio
            From 
                HoSoDoiBong db1,
                HoSoDoiBong db2,
				LichThiDau ld,
				SanVanDong svd,
				TrongTai tt
            Where 
                db1.MaDoi = ld.DoiNha
                And db2.MaDoi = ld.DoiKhach
				And ld.San = svd.MaSan
				And ld.TrongTai = tt.MaTrongTai
			Order By VongDau";

        const string GetTrongTaiSQL = @"
            Select *
            From TrongTai tt
            Where 
                tt.MaTrongTai = @1 
                Or tt.MaTrongTai 
                Not in(
	                Select ld.TrongTai
	                From LichThiDau ld
	                Where ld.Gio = @2 And ld.VongDau = @3)";

        const string UpdateTranDauSQL = @"
            Update LichThiDau
	        Set 
	            Ngay = @1,
	            Gio = @2,
	            TrongTai = @3
	        Where MaTranDau = @4";

        const string TaoLichDauMoiSQL = @"
            IF OBJECT_ID(N'#LichThiDauMoi', N'U') IS NOT NULL DROP TABLE #LichThiDauMoi
	        CREATE TABLE #LichThiDauMoi
	        (
		        MaTranDau	char(7)		primary key,
		        VongDau		int	,
		        DoiNha		char(7),
		        DoiKhach	char(7),
		        Ngay		date,
		        Gio			time,
		        San			char(7),
		        TrongTai	char(7)
	        )

	        IF OBJECT_ID(N'#randOder', N'U') IS NOT NULL DROP TABLE #randOder
	        CREATE TABLE #randOrder(Id int IDENTITY(1,1), MaDoi char(7))
	
	        INSERT INTO #randOrder(MaDoi)
		        SELECT MaDoi
		        FROM HoSoDoiBong
		        ORDER BY RAND(CHECKSUM(NewID())), MaDoi DESC
	
	        IF ((SELECT COUNT(*) FROM #randOrder) % 2 <> 0)
	        BEGIN
		        INSERT INTO #randOrder(MaDoi) VALUES ('#######')
	        END

	        DECLARE @n int, @dw int
	        SET @n = (SELECT COUNT(*) FROM #randOrder);

	        -- dateweek tinh tu 1 den 7, bat dau tu chu nhat
	        -- ngay bat dau giai thuc te se la thu 7 dau tien sau ngay du kien
	        -- chi da vao cuoi tuan la t7 va chu nhat
	        SET @1 = @1 + (7 - DATEPART(dw, @1))

	        DECLARE @round int, @i int, @cnt int, @cntTran int
	        DECLARE @maDoi1 char(7), @maDoi2 char(7), @maTran char(7)
	        SET @cntTran = 0

	        --SELECT * FROM #randOrder
	        SET @round = 1
	        WHILE (@round < @n)
	        BEGIN
		        SET @i = 1
		        SET @cnt = 0

		        WHILE (@cnt < @n/2)
		        BEGIN
			        SET @maDoi1 = (SELECT Madoi FROM #randOrder WHERE Id = @i)
			        SET @maDoi2 = (SELECT Madoi FROM #randOrder WHERE Id = @n - @i + 1)
			        IF (@madoi1 <> '#######' AND @maDoi2 <> '#######')
			        BEGIN
				        SET @cntTran = @cntTran + 1
				        SET @maTran = 'T' + REPLACE(STR(@cntTran, 6), ' ', '0')
				        INSERT INTO #LichThiDauMoi(MaTranDau, VongDau, DoiNha, DoiKhach, Ngay, Gio, San, TrongTai)
				        VALUES(
					        @maTran,
					        @round,
					        @maDoi1,
					        @maDoi2,
					        @1,
					        '17:00:00',
					        (SELECT SanVanDong FROM HoSoDoiBong WHERE MaDoi = @madoi1),
					        (SELECT TOP 1 MaTrongTai
						        FROM TrongTai
						        --WHERE MaTrongTai NOT IN (SELECT TrongTai FROM #LichThiDauMoi WHERE LEFT(MaTranDau, 3) = LEFT(@maTran, 3))
						        WHERE MaTrongTai NOT IN (SELECT TOP(@n/2) TrongTai FROM #LichThiDauMoi ORDER BY Ngay DESC)
						        ORDER BY NEWID()
					        )
				        )
				        SET @cnt = @cnt + 1
				        IF (@cnt = @n/4)
					        SET @1 = @1 + 1
			        END;
			        SET @i = @i + 1
		        END;
		        SET @1 = @1 + 6
		        SET @maDoi1 = (SELECT MaDoi FROM #randOrder WHERE Id = @n)

		        DECLARE cur CURSOR FOR SELECT Id FROM #randOrder ORDER BY Id DESC
		        OPEN cur
		        FETCH NEXT FROM cur INTO @i
		        WHILE @@FETCH_STATUS = 0
		        BEGIN
			        IF (@i > 1 AND EXISTS (SELECT MaDoi FROM #randOrder WHERE Id = @i-1))
				        UPDATE #randOrder SET MaDoi = (SELECT MaDoi FROM #randOrder WHERE Id = @i-1) WHERE Id = @i
			        FETCH NEXT FROM cur INTO @i
		        END
		        CLOSE cur
		        DEALLOCATE cur

		        UPDATE #randOrder SET MaDoi = @maDoi1 WHERE Id = 2
		        SET @round = @round + 1;
	        END

	    --SELECT * FROM #randOrder

	    SET @round = 1
	    WHILE (@round < @n)
	    BEGIN
		    SET @i = 1
		    SET @cnt = 0

		    WHILE (@cnt < @n/2)
		    BEGIN
			    SET @maDoi1 = (SELECT Madoi FROM #randOrder WHERE Id = @n - @i + 1)
			    SET @maDoi2 = (SELECT Madoi FROM #randOrder WHERE Id = @i)
			    IF (@madoi1 <> '#######' AND @maDoi2 <> '#######')
			    BEGIN
				    SET @cntTran = @cntTran + 1
				    SET @maTran = 'T' + REPLACE(STR(@cntTran, 6), ' ', '0')
				    INSERT INTO #LichThiDauMoi(MaTranDau, VongDau, DoiNha, DoiKhach, Ngay, Gio, San, TrongTai)
				    VALUES(
					    @maTran,
					    @n - 1 + @round,
					    @maDoi1,
					    @maDoi2,
					    @1,
					    '17:00:00',
					    (SELECT SanVanDong FROM HoSoDoiBong WHERE MaDoi = @madoi1),
					    (SELECT TOP 1 MaTrongTai
						    FROM TrongTai
						    WHERE MaTrongTai NOT IN (SELECT TOP(@n/2) TrongTai FROM #LichThiDauMoi ORDER BY Ngay DESC)
						    ORDER BY NEWID()
					    )
				    )
				    SET @cnt = @cnt + 1
				    IF (@cnt = @n/4)
					    SET @1 = @1 + 1
			    END;
			    SET @i = @i + 1
		    END;
		    SET @1 = @1 + 6
		    SET @maDoi1 = (SELECT MaDoi FROM #randOrder WHERE Id = @n)

		    DECLARE cur CURSOR FOR SELECT Id FROM #randOrder ORDER BY Id DESC
		    OPEN cur
		    FETCH NEXT FROM cur INTO @i
		    WHILE @@FETCH_STATUS = 0
		    BEGIN
			    IF (@i > 1 AND EXISTS (SELECT MaDoi FROM #randOrder WHERE Id = @i-1))
				    UPDATE #randOrder SET MaDoi = (SELECT MaDoi FROM #randOrder WHERE Id = @i-1) WHERE Id = @i
			    FETCH NEXT FROM cur INTO @i
		    END
		    CLOSE cur
		    DEALLOCATE cur

		    UPDATE #randOrder SET MaDoi = @maDoi1 WHERE Id = 2
		    SET @round = @round + 1;
	    END

	    DELETE FROM DanhSachBanThang
	    DELETE FROM DanhSachThePhat
	    DELETE FROM KetQuaTranDau
	    DELETE FROM LichThiDau
	    INSERT INTO LichThiDau(MaTranDau, VongDau, DoiNha, DoiKhach, Ngay, Gio, San, TrongTai)
	    SELECT MaTranDau, VongDau, DoiNha, DoiKhach, Ngay, Gio, San, TrongTai
	    FROM #LichThiDauMoi
        --Them vao lai danh sach cac tran dau chua co ket qua
        INSERT INTO KetQuaTranDau(MaTranDau, TinhTrang, SoBanThangDoiNha, SoBanThangDoiKhach)
	    SELECT MaTranDau, 2, -1, -1
	    FROM #LichThiDauMoi";
        #endregion

        #region ExecuteSQL
        #endregion

        /// <summary>
        /// Lay lich thi dau cua mua giai
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public ObservableCollection<TranDauModel> GetLichThiDau(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            ObservableCollection<TranDauModel> lstTranDau = new ObservableCollection<TranDauModel>();
            using (var db = new AutoCommitDbAccessor())
            {

                IDataReader reader = db.Query(LichThiDauSQL);
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
        /// Cap nhat thong tin tran dau
        /// </summary>
        /// <param name="paramArr"></param>
        /// <returns></returns>
        public bool UpdateTranDau(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            TranDauModel tranDau = (TranDauModel)paramArr[0];
            using (var db= new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(UpdateTranDauSQL, tranDau.Ngay,
                        tranDau.Gio, tranDau.TrongTai, tranDau.MaTranDau) == 0)
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


        public ObservableCollection<TrongTaiModel> GetLstTrongTai(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            TranDauModel td = (TranDauModel)paramArr[0];
            ObservableCollection<TrongTaiModel> lstTrongTai = new ObservableCollection<TrongTaiModel>();
            using (var db = new AutoCommitDbAccessor())
            {
                try
                {
                    IDataReader reader = db.Query(GetTrongTaiSQL, td.TrongTai, td.Gio, td.VongDau);
                    while (reader.Read())
                    {
                        var trongTai = new TrongTaiModel();
                        trongTai.DataMap(reader);
                        lstTrongTai.Add(trongTai);
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
                
            }
            return lstTrongTai;
        }

        public bool TaoLichThiDau(params object[] paramArr)
        {
            Log.Info("Execute SQL");
            DateTime beginDay = (DateTime)paramArr[0];
            using (var db = new TransactionDbAccessor())
            {
                try
                {
                    if (db.NonQuery(TaoLichDauMoiSQL,beginDay) == 0)
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
    }
}
