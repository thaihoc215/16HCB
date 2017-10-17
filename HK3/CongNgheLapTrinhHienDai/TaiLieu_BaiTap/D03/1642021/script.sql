CREATE DATABASE REST_ATM
GO
USE REST_ATM
GO

CREATE TABLE The(
	MaThe int primary key identity(1,1) not null,
	TenChuThe nvarchar(50) not null,
	NgayHetHan datetime not null,
	SoDuKhaDung float not null,
	NganHang int
);

Create table NganHang(
	MaNganHang int primary key not null,
	TenNganHang nvarchar(50) not null
);

Create table GiaoDich(
	MaGiaoDich int,
	TaiKhoanNguon int,
	TaiKhoanDich int,
	ThoiDiemGiaoDich datetime not null,
	Primary Key (MaGiaoDich,TaiKhoanNguon,TaiKhoanDich)
);

Alter table The add foreign key (NganHang) references NganHang(MaNganHang);
Alter table GiaoDich add foreign key (TaiKhoanNguon) references The(MaThe);
Alter table GiaoDich add foreign key (TaiKhoanDich) references The(MaThe);

--Them ngan hang
Insert into NganHang(MaNganHang,TenNganHang) values (1,N'VietComBank');
Insert into NganHang(MaNganHang,TenNganHang) values (2,N'Agribank');
Insert into NganHang(MaNganHang,TenNganHang) values (3,N'TechComBank');
Insert into NganHang(MaNganHang,TenNganHang) values (4,N'TienPhongBank');
Insert into NganHang(MaNganHang,TenNganHang) values (5,N'KienLongBank');

Insert into The(TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (N'Hà Nguyễn Thái Học', '12/31/2020',10000000,1);
Insert into The(TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (N'Trần Văn Phương', '12/31/2020',15000000,1);
Insert into The(TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (N'Nguyễn Kim Ngân', '12/31/2020',11000000,1);
Insert into The(TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (N'Lê Vũ Anh', '12/31/2020',12040000,1);
Insert into The(TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (N'Nguyễn Chí Hiếu', '12/31/2020',14000500,1);
Insert into The(TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (N'Huỳnh Xuân Phát', '12/31/2020',11040000,1);
Insert into The(TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (N'Nguyễn Như Ngọc', '12/31/2020',19007000,1);
Insert into The(TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (N'Trần Quốc Thắng', '12/31/2020',21002000,1);
Insert into The(TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (N'Nguyễn Hoàng Gia', '12/31/2020',15030000,1);
Insert into The(TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (N'Vũ Minh Tuấn', '12/31/2020',10000000,1);
Insert into The(TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (N'Bùi Nhật Trường', '12/31/2020',18500000,1);
Insert into The(TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (N'Lê Vinh', '12/31/2020',10000000,1);
Insert into The(TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (N'Nguyễn Hoàng Duy', '12/31/2020',10500000,1);
Insert into The(TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (N'Vương Kỳ Anh', '12/31/2020',17005000,1);
Insert into The(TenChuThe,NgayHetHan,SoDuKhaDung,NganHang) values (N'Phạm Hồng Hạnh', '12/31/2020',11001000,1);
