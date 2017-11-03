var express = require('express'),
    nhModel = require('../models/nganhangModel'),
    cons = require('../cons');

var router = express.Router();

//Lay danh sach ngan hang
router.get('/', (req, res) => {
    nhModel.layDsNganHang().then((result) => {
        res.status(cons.HTTPCODE.OK).json(result);
    }).catch(() => {
        res.status(cons.HTTPCODE.Notfound);
    });
})

module.exports = router;