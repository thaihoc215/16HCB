CREATE DATABASE QuanLyThanhVien
GO
USE QuanLyThanhVien;
GO
CREATE TABLE ThanhVien
    (
      MaTV INT PRIMARY KEY
                  IDENTITY(1, 1) ,
      TenTV NVARCHAR(50) ,
      NgaySinh Date ,
      SDT VARCHAR(15) ,
      Email VARCHAR(50)
    );

Insert into ThanhVien(TenTV,NgaySinh,SDT,Email) values ('Hoc1','12/21/1994','123456','hoc1@gmail.com');
Insert into ThanhVien(TenTV,NgaySinh,SDT,Email) values ('Hoc2','12/21/1995','123457','hoc2@gmail.com');
Insert into ThanhVien(TenTV,NgaySinh,SDT,Email) values ('Hoc3','12/21/1996','123458','hoc3@gmail.com');
Insert into ThanhVien(TenTV,NgaySinh,SDT,Email) values ('Hoc4','12/21/1997','123459','hoc4@gmail.com');