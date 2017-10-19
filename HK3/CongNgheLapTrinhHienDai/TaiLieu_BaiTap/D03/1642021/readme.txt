Trước khi chạy chương trình chạy file script.sql để tạo cơ sở dữ liệu
Thay đổi đường dẫn của web config để connect đến database

Postman script dung de test
//lay thong tin tai khoan, truyen vao maThe,maNganHang,taiKhoan
http://localhost:56242/api/taikhoan/thongtinthe?maThe=1&maNganHang=1,matKhau=123

//chuyen khoan
[maNguoiGui,maNguoiNhan,soTienGui,nganHangGui,nganHangNhan,xacNhan[0 = false,1 = true]
[1,3,10000,1,2,1]

//Rut tien
[maThe, nganHang, loaiRut[1,2,3 <=> 1tr,2tr,5tr; default = soTienRut], soTienRut]
[1,1,3,50000]

//Lay danh sach giao dich
http://localhost:56242/api/giaodich/xemgiaodich?ngayBatDau=12/31/2016&ngayKetThuc=12/12/2017
