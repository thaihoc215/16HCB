CREATE DATABASE [QLHocSinh]
GO
Use QLHocSinh
GO

CREATE TABLE [dbo].[HocSinh](
	[MaHS] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[TenHS] [nvarchar](50) NOT NULL,
	[NgaySinh] [datetime] NULL,
	[SDT] [nvarchar](20) NULL,
	[DiaChi] [nvarchar](100) NULL
	)

INSERT INTO [dbo].[HocSinh]([TenHS],[NgaySinh],[SDT],[DiaChi]) VALUES (N'Thái Học','05/05/1994','12345',N'ĐC 1')
INSERT INTO [dbo].[HocSinh]([TenHS],[NgaySinh],[SDT],[DiaChi]) VALUES (N'Xuân Phúc','06/07/1995','321354',N'ĐC 2')
INSERT INTO [dbo].[HocSinh]([TenHS],[NgaySinh],[SDT],[DiaChi]) VALUES (N'Thái Hòa','12/15/1995','219873',N'ĐC 3')
INSERT INTO [dbo].[HocSinh]([TenHS],[NgaySinh],[SDT],[DiaChi]) VALUES (N'Huỳnh Phong','03/21/1994','123435465',N'ĐC 4')
INSERT INTO [dbo].[HocSinh]([TenHS],[NgaySinh],[SDT],[DiaChi]) VALUES (N'Minh Nhật','08/05/1995','12355445',N'ĐC 5')

