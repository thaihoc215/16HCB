var express = require('express'),
    model = require('../models/taiKhoanModel');

var router = express.Router();

//lay thong tin toan bo tai khoan
router.get('/', (req, res) => {
    // var sql = 'select * from the';
    // db.load(sql).then(rows => {
    //     res.json(rows);
    // });

    model.loadAllTK().then(rows => {
        res.json(rows);
    });
});

//lay thong tin mot tai khoan
router.post('/', (req, res) => {
    var mathe = req.body.mathe,
        matkhau = req.body.matkhau,
        nganhang = req.body.nganhang;
    model.loadTaiKhoan(mathe, matkhau, nganhang).then(rows => {
        res.statusCode = 201;
        res.json(rows[0]);
    });
    // res.json(obj = {abc: String(id)});
});

//middle ware
module.exports = router;
