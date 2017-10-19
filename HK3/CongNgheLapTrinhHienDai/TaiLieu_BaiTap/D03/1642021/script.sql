﻿--DROP Database REST_ATM
--Go
CREATE DATABASE REST_ATM
GO
USE REST_ATM
GO

CREATE TABLE The(
	MaThe int not null,
	MatKhau varchar(50) not null,
	TenChuThe nvarchar(50) not null,
	NgayHetHan datetime not null,
	SoDuKhaDung float not null,
	NganHang int not null
	primary key(MaThe,NganHang)
);

Create table NganHang(
	MaNganHang int primary key not null,
	TenNganHang nvarchar(50) not null
);

Create table GiaoDich(
	MaGiaoDich int not null,
	TaiKhoan int not null,
	NganHangSoHu int not null,
	SoTienGiaoDich float not null,
	ThoiDiemGiaoDich datetime not null,
	LoaiGiaoDich int not null
	Primary Key (MaGiaoDich,TaiKhoan)
);

Create table LoaiGiaoDich(
	MaLoai int  primary key not null,
	TenLoai nvarchar(50) not null
);

Alter table The add foreign key (NganHang) references NganHang(MaNganHang);
Alter table GiaoDich add foreign key (TaiKhoan,NganHangSoHu) references The(MaThe,NganHang);
Alter table GiaoDich add foreign key (LoaiGiaoDich) references LoaiGiaoDich(MaLoai);

--Them ngan hang
Insert into NganHang(MaNganHang,TenNganHang) values (1,N'VietComBank');
Insert into NganHang(MaNganHang,TenNganHang) values (2,N'Agribank');
Insert into NganHang(MaNganHang,TenNganHang) values (3,N'TechComBank');
Insert into NganHang(MaNganHang,TenNganHang) values (4,N'TienPhongBank');
Insert into NganHang(MaNganHang,TenNganHang) values (5,N'KienLongBank');

Insert into The(MaThe,MatKhau,TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (1,'123',N'Hà Nguyễn Thái Học', '12/31/2020',10000000,1);
Insert into The(MaThe,MatKhau,TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (2,'123',N'Trần Văn Phương', '12/31/2020',15000000,1);
Insert into The(MaThe,MatKhau,TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (3,'123',N'Nguyễn Kim Ngân', '12/31/2020',11000000,1);
Insert into The(MaThe,MatKhau,TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (4,'123',N'Lê Vũ Anh', '12/31/2020',12040000,1);
Insert into The(MaThe,MatKhau,TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (5,'123',N'Nguyễn Chí Hiếu', '12/31/2020',14000500,1);
Insert into The(MaThe,MatKhau,TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (1,'123',N'Huỳnh Xuân Phát', '12/31/2020',11040000,2);
Insert into The(MaThe,MatKhau,TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (2,'123',N'Nguyễn Như Ngọc', '12/31/2020',19007000,2);
Insert into The(MaThe,MatKhau,TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (3,'123',N'Trần Quốc Thắng', '12/31/2020',21002000,2);
Insert into The(MaThe,MatKhau,TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (4,'123',N'Nguyễn Hoàng Gia', '12/31/2020',15030000,2);
Insert into The(MaThe,MatKhau,TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (5,'123',N'Vũ Minh Tuấn', '12/31/2020',10000000,2);
Insert into The(MaThe,MatKhau,TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (1,'123',N'Bùi Nhật Trường', '12/31/2020',18500000,3);
Insert into The(MaThe,MatKhau,TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (2,'123',N'Lê Vinh', '12/31/2020',10000000,3);
Insert into The(MaThe,MatKhau,TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (3,'123',N'Nguyễn Hoàng Duy', '12/31/2020',10500000,3);
Insert into The(MaThe,MatKhau,TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (4,'123',N'Vương Kỳ Anh', '12/31/2020',17005000,3);
Insert into The(MaThe,MatKhau,TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (5,'123',N'Phạm Hồng Hạnh', '12/31/2020',11001000,3);

Insert into LoaiGiaoDich(MaLoai,TenLoai) values (1,N'Rút tiền');
Insert into LoaiGiaoDich(MaLoai,TenLoai) values (2,N'Chuyển tiền');