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
        loairut = req.body.loairut,
        sotienrut = req.body.sotienrut;

    var sotien;
    switch (loairut) {
        case 1:
            sotien = 1000000;
            break;
        case 2:
            sotien = 2000000;
            break;
        case 3:
            sotien = 5000000;
            break;
        default:
            sotien = sotienrut;
            break;
    }
    if (sotien % 50000 != 0) {
        res.status(404).json('So tien rut phai la boi so cua 50000');
    }

    //kiem tra so tien nguoi dung
    var nd = {};
    ndModel.loadTaiKhoan(mathe, matkhau, manganhang).
        then((rows) => {
            nd = rows[0];
            if (nd.SoDuKhaDung < 100000) {
                res.status(404).json('So du tai khoan khong du');
            } else {
                var sodu = nd.SoDuKhaDung - sotienrut;
                return gdmodel.rutTien(mathe, manganhang, sodu)
            }
        }).then((rs) => {
            if (rs) {
                return ndModel.loadTaiKhoan(mathe, matkhau, manganhang)
            } else
                res.status(204).json('Rut tien that bai');
        }).then((rows) => {
            res.status(200).json(rows[0]);
        });;
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
            if (nd1.MaThe == nd2.MaThe && nd1.MaNganHang == nd2.MaNganHang) {
                res.status(cons.HTTPCODE.NotAccept).json('Tai khoan nhan tien phai khac tai khoan gui tien');
            } else if (soTienGui < 0) {
                res.status(cons.HTTPCODE.NotAccept).json('So tien gui khong hop le');
            } else if (nd1.SoDuKhaDung - soTienGui < 100000) {
                res.status(cons.HTTPCODE.NotAccept).json('So du tai khoan khong du');
            } else {
                let sodunguoigui = nd1.SoDuKhaDung - soTienGui;
                let sodunguoinhan = nd2.SoDuKhaDung + soTienGui;
                //chuyen khoan cung ngan hang
                if (nd1.MaNganHang == nd2.MaNganHang) {
                    sodunguoigui = sodunguoigui - 3300;
                } else {//chuyen khoan trai ngan hang
                    sodunguoigui = sodunguoigui - 11000;
                }
                gdmodel.chuyenTien(magui, nganHangDi, sodunguoigui);
                gdmodel.nhanTien(manhan, nganHangDen, sodunguoinhan);
                res.status('200').json('Giao dich thanh cong');
            }
        }).catch(() => {
            res.status(cons.HTTPCODE.Notfound).json("LOI");
        });
    }
});

module.exports = router;