var express = require('express'),
    model = require('../models/giaodichModel.js'),
    ndModel = require('../models/taiKhoanModel.js');

var router = express.Router();

//Rut tien
router.post('/rutrien', (req, res) => {
    var mathe = req.body.mathe,
        manganhang = req.body.manganhang,
        matkhau = req.body.matkhau,
        loairut = req.body.loairut,
        sotienrut = req.body.sotienrut;
    switch (loairut) {
        case 1:
            sotienrut = 1000000;
            break;
        case 2:
            sotienrut = 2000000;
            break;
        case 3:
            sotienrut = 5000000;
            break;
        default:
            break;
    }
    if (sotienrut % 50000 != 0) {
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
            return model.rutTien(mathe, manganhang, sodu);
        }
    }).then((rs) => {
        if (rs)
            rs.status(200).json('Rut tien thanh cong');
        else
            rs.status(204).json('Rut tien that bai');
    }).catch((err) => {

    });
});

//chuyen tien
router.post('/chuyentien', (req, res) => {
    var maNguoiGui = req.body.maNguoiGui;
    var maNguoiNhan = req.body.maNguoiNhan;
    var soTienGui = req.body.soTienGui;
    var nganHangGui = req.body.nganHangGui;
    var nganHangNhan = req.body.nganHangNhan;
    var xacNhan = req.body.xacNhan;
})