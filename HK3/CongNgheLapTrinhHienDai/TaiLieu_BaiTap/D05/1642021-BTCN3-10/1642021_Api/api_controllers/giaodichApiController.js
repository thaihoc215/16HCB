var express = require('express'),
    gdmodel = require('../models/giaodichModel'),
    ndModel = require('../models/taiKhoanModel'),
    cons = require('../cons');

var router = express.Router();

//Rut tien
router.post('/ruttien', (req, res) => {
    var mathe = req.body.mathe,
        manganhang = req.body.manganhang,
        matkhau = req.body.matkhau,
        sotienrut = req.body.sotienrut;

    if (sotienrut % 50000 != 0) {
        res.status(cons.HTTPCODE.NotAccept).json('Số tiền rút phải là bội số của 50000');
    }
    else {
        //kiem tra so tien nguoi dung
        var nd = {};
        ndModel.loadThongTinTaiKhoan(mathe, manganhang).
            then((rows) => {
                nd = rows[0];
                if (nd.SoDuKhaDung - sotienrut < 100000) {
                    res.status(cons.HTTPCODE.NotAccept).json('Số dư tài khoản không đủ');
                } else {
                    var sodu = nd.SoDuKhaDung - sotienrut;
                    return gdmodel.rutTien(mathe, manganhang, sodu)
                }
            }).then((rs) => {
                if (rs) {
                    return ndModel.loadThongTinTaiKhoan(mathe, manganhang)
                } else
                    res.status(cons.HTTPCODE.NotAccept).json('Rút tiền thất bại');
            }).then((rows) => {
                gdmodel.luuGiaoDich(mathe, manganhang, sotienrut, new Date().toLocaleString(), 1);
                res.status(200).json(rows[0]);
            });;
    }

});

//chuyen tien
router.post('/chuyentien', (req, res) => {
    var maNguoiGui = req.body.maNguoiGui;
    var maNguoiNhan = req.body.maNguoiNhan;
    var soTienGui = req.body.soTienGui;
    var nganHangGui = req.body.nganHangGui;
    var nganHangNhan = req.body.nganHangNhan;
    var xacNhan = req.body.xacNhan;
    if (xacNhan == false) {
        res.status(cons.HTTPCODE.OK).json('Huy giao dich');
    }
    else {
        let nd1 = {};
        let nd2 = {};
        let magui = maNguoiGui,
            manhan = maNguoiNhan;
        let nganHangDi = nganHangGui,
            nganHangDen = nganHangNhan;
        let p1 = ndModel.loadThongTinTaiKhoan(maNguoiGui, nganHangDi);
        let p2 = ndModel.loadThongTinTaiKhoan(maNguoiNhan, nganHangDen);
        Promise.all([p1, p2]).then((rs) => {
            nd1 = rs[0][0];
            nd2 = rs[1][0];
            // res.status(200).json([nd1,nd2]);
        }).then(() => {
            if (nd2 == null) {
                res.status(cons.HTTPCODE.NotAccept)
                    .json('Người nhận tiền không có trong hệ thông');
            } else if (nd1.MaThe == nd2.MaThe && nd1.MaNganHang == nd2.MaNganHang) {
                res.status(cons.HTTPCODE.NotAccept)
                    .json('Tài khoản nhận phải khác tài khoản gửi');
            } else if (nd1.SoDuKhaDung - soTienGui < 100000) {
                res.status(cons.HTTPCODE.NotAccept)
                    .json('Số dư tài khoản không đủ');
            } else {
                let sodunguoigui = nd1.SoDuKhaDung - soTienGui;
                let sodunguoinhan = nd2.SoDuKhaDung + soTienGui;
                //chuyen khoan cung ngan hang
                if (nd1.MaNganHang == nd2.MaNganHang) {
                    sodunguoigui = sodunguoigui - 3300;
                } else {//chuyen khoan trai ngan hang
                    sodunguoigui = sodunguoigui - 11000;
                }
                Promise.all([gdmodel.chuyenTien(magui, nganHangDi, sodunguoigui),
                gdmodel.nhanTien(manhan, nganHangDen, sodunguoinhan)]).then(() => {
                    ndModel.loadThongTinTaiKhoan(maNguoiGui, nganHangDi).then((rs2) => {
                        gdmodel.luuGiaoDich(maNguoiGui, nganHangDi, soTienGui, new Date().toLocaleString(), 2);
                        res.status('200').json(rs2[0]);
                    })
                });
            }
        }).catch(() => {
            res.status(cons.HTTPCODE.Notfound).json("Chuyển tiền không thành công");
        });
    }
});
router.get('/ngay', (req, res) => {
    var mathe = req.query.mathe,
        ngaybatdau = req.query.ngaybatdau,
        ngayketthuc = req.query.ngayketthuc;
    gdmodel.layGiaoDichNgay(mathe, ngaybatdau, ngayketthuc).then((rs) => {
        res.status(200).json(rs);
    });
});

router.get('/', (req, res) => {
    gdmodel.layGiaoDich(req.query.mathe).then((rs) => {
        res.status(200).json(rs);
    });
});

module.exports = router;