use master
Go
--drop database QUANLYGIAIBONGDA
--go

create database QUANLYGIAIBONGDA
go

use [QUANLYGIAIBONGDA]
go
/*
---28/12 Update Nhân Viên, xóa table BXH
--29/12: Update vị trí
*/
create table HoSoDoiBong
(

	MaDoi			char(7)			primary key,
	TenDoi			nvarchar(50),
	NamThanhLap		date,
	SanVanDong		char(7),
	ChuTich			nvarchar(50),
	HuanLuyenVien	char(7),
	DoiTruong		int,
	DiaChi			nvarchar(100),
	SoDienThoai    	char(50),
	Logo			nvarchar(1000)
)

create table SanVanDong
(
	MaSan			char(7)			primary key,
	TenSan			nvarchar(50),
	DoiBongSoHuu	char(7),
	NgayKhanhThanh	date,
	SucChua			int,
	KichThuoc		float
)

create table HuanLuyenVien
(
	MaHLV		char(7)		primary key,
	TenHLV		nvarchar(50),
	NgaySinh	date,
	GioiTinh	nvarchar(3),
	DoiBong		char(7),
	TroLy		nvarchar(50)
)

create table LichThiDau
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

create table TrongTai
(
	MaTrongTai	char(7)		primary key,
	TenTrongTai nvarchar(50),
	NgaySinh	date,
	GioiTinh	nvarchar(3),
	BangCap		char(7)
)

create table LoaiBangCap
(
	MaBC	char(7)		primary key,
	TenBC	nvarchar(30),
)

create table KetQuaTranDau
(
	MaTranDau			char(7)		primary key,
	TinhTrang			int,
	SoBanThangDoiKhach	int,
	SoBanThangDoiNha	int	
)

create table TinhTrangTranDau
(
	MaTinhTrang		int		primary key,
	TenTinhTrang	nvarchar(20)
)

--Có thêm thời gian ghi bàn
create table DanhSachBanThang
(
	MaBanThang		char(7)		primary key,
	CauThuGhiBan	int,
	LoaiBanThang	char(7),
	DoiBong			char(7),
	TranDau			char(7),
	ThoiDiem	int
)

create table LoaiBanThang
(
	MaLoai	char(7)		primary key,
	TenLoai	nvarchar(20)
)

create table DanhSachThePhat
(
	MaThePhat	int		primary key,
	LoaiThe		char(7),
	CauThu		int,
	TrongTai	char(7),
	ThoiDiem	int,
	TranDau		char(7)
)

create table LoaiThePhat
(
	MaThe	char(7)		primary key,
	TenLoai	nvarchar(5)
)
--29/12: Update vị trí
create table ViTri
(
	MaVT int primary key,
	TenVT nvarchar(20),
)

create table DanhSachCauThu
(
	MaCauThu	int		primary key,
	SoAo		int,
	HoTen		nvarchar(50),
	QuocTich	nvarchar(50),
	ViTri		int,
	NgaySinh	date,
	DoiBong		char(7),
	ChieuCao	float,
	CanNang		float,
	AnhDaiDien		nvarchar(1000)
)


---28/12 Update Nhân Viên, xóa table BXH
create table NhanVien
(
	MaNV int primary key,
	HoTen nvarchar(50),
	NgaySinh date,
	GioiTinh nvarchar(3),
	DienThoai char(11),
	Email char(20),
	DiaChi nvarchar(100),
	CMND char(9),
	Pass char(10),
	LoaiNV	int
)
Create Table LoaiNV
(
	MaLoai int primary key,
	TenLoai nvarchar(20)
)
-- Tạo bảng update 29/12

create table BangQuyDinh
(
	MaGT char(10) primary key,
	GiaTri int
)
CREATE TABLE BangXepHang
	(
		Hang			int,
		MaDoi			char(7)	primary key,
		TenDoi			nvarchar(50),
		SoTran			int,
		Thang			int,
		Hoa				int,
		Thua			int,
		HieuSo			int,
		BanThang		int,
		Diem			int
	)

-- Nhập liệu update 29/12
-- Bảng quy định (dùng cho quy định các ràng buộc)
INSERT INTO BangQuyDinh(MaGT, GiaTri)
	VALUES
		('TuoiMin', 16),
		('TuoiMax', 40),
		('SoLuongMin', 15),
		('SoLuongMax', 22),
		('CTNgoai', 3),
		('TDGhiBan', 96),
		('Thang',3),
		('Hoa',1),
		('Thua',0)
ALTER TABLE HoSoDoiBong ADD CONSTRAINT FK_HoSoDoiBong_SanVanDong		FOREIGN KEY (SanVanDong)	REFERENCES SanVanDong (MaSan)
ALTER TABLE HoSoDoiBong ADD CONSTRAINT FK_HoSoDoiBong_HuanLuyenVien		FOREIGN KEY (HuanLuyenVien) REFERENCES HuanLuyenVien(MaHLV)
ALTER TABLE HoSoDoiBong ADD CONSTRAINT FK_HoSoDoiBong_DanhSachCauThu	FOREIGN KEY (DoiTruong)		REFERENCES DanhSachCauThu(MaCauThu)
ALTER TABLE HuanLuyenVien ADD CONSTRAINT FK_HLV_HoSoDoiBong	FOREIGN KEY (DoiBong)		REFERENCES HoSoDoiBong(MaDoi)

ALTER TABLE SanVanDong ADD CONSTRAINT FK_SanVanDong_HoSoDoiBong		FOREIGN KEY (DoiBongSoHuu)	REFERENCES HoSoDoiBong(MaDoi)

ALTER TABLE LichThiDau ADD CONSTRAINT FK_LichThiDau_HoSoDoiBong_DoiNha		FOREIGN KEY (DoiNha)	REFERENCES HoSoDoiBong(MaDoi)
ALTER TABLE LichThiDau ADD CONSTRAINT FK_LichThiDau_HoSoDoiBong_DoiKhach	FOREIGN KEY (DoiKhach)	REFERENCES HoSoDoiBong(MaDoi)
ALTER TABLE LichThiDau ADD CONSTRAINT FK_LichThiDau_SanVanDong				FOREIGN KEY (San)		REFERENCES SanVanDong(MaSan)
ALTER TABLE LichThiDau ADD CONSTRAINT FK_LichThiDau_TrongTai				FOREIGN KEY (TrongTai)	REFERENCES TrongTai(MaTrongTai)


ALTER TABLE TrongTai ADD CONSTRAINT FK_TrongTai_BangCap	FOREIGN KEY (BangCap)	REFERENCES LoaiBangCap(MaBC)

ALTER TABLE KetQuaTranDau ADD CONSTRAINT FK_KetQuaTranDau_MaTranDau			FOREIGN KEY (MaTranDau)	REFERENCES	LichThiDau(MaTranDau)
ALTER TABLE	KetQuaTranDau ADD CONSTRAINT FK_KetQuaTranDau_TinhTrangTranDau	FOREIGN KEY (TinhTrang)	REFERENCES	TinhTrangTranDau(MaTinhTrang)

ALTER TABLE DanhSachBanThang ADD CONSTRAINT FK_DanhSachBanThang_DanhSachCauThu	FOREIGN KEY (CauThuGhiBan)	REFERENCES DanhSachCauThu(MaCauThu)
ALTER TABLE DanhSachBanThang ADD CONSTRAINT FK_DanhSachBanThang_HoSoDoiBong		FOREIGN KEY (DoiBong)		REFERENCES HoSoDoiBong(MaDoi)
ALTER TABLE DanhSachBanThang ADD CONSTRAINT FK_DanhSachBanThang_LichThiDau		FOREIGN KEY (TranDau)		REFERENCES LichThiDau(MaTranDau)
ALTER TABLE DanhSachBanThang ADD CONSTRAINT FK_DanhSachBanThang_LoaiBanThang	FOREIGN KEY (LoaiBanThang)	REFERENCES LoaiBanThang(MaLoai)

ALTER TABLE DanhSachThePhat ADD CONSTRAINT FK_DanhSachThePhat_DanhSachCauThu	FOREIGN KEY (CauThu)	REFERENCES DanhSachCauThu(MaCauThu)
ALTER TABLE DanhSachThePhat ADD CONSTRAINT FK_DanhSachThePhat_TrongTai			FOREIGN KEY (TrongTai)	REFERENCES TrongTai(MaTrongTai)
ALTER TABLE DanhSachThePhat ADD CONSTRAINT FK_DanhSachThePhat_LichThiDau		FOREIGN KEY (TranDau)	REFERENCES LichThiDau(MaTranDau)
ALTER TABLE DanhSachThePhat ADD CONSTRAINT FK_DanhSachThePhat_LoaiThePhat		FOREIGN KEY (LoaiThe)	REFERENCES LoaiThePhat(MaThe)

ALTER TABLE DanhSachCauThu ADD CONSTRAINT FK_DanhSachCauThu_HoSoDoiBong	FOREIGN KEY (DoiBong)	REFERENCES HoSoDoiBong(MaDoi)
ALTER TABLE DanhSachCauThu ADD CONSTRAINT FK_DanhSachCauThu_ViTri		FOREIGN KEY (ViTri)		REFERENCES ViTri(MaVT)
--HLV có khóa ngoại Đội Bóng tới Hồ sơ đội bóng ???

ALTER TABLE NhanVien  ADD CONSTRAINT FK_NhanVien_LoaiNV	FOREIGN KEY (LoaiNV)	REFERENCES LoaiNV(MaLoai)
ALTER TABLE BangXepHang ADD CONSTRAINT FK_BXH_HoSoDoiBong		FOREIGN KEY (MaDoi)	REFERENCES HoSoDoiBong(MaDoi)

