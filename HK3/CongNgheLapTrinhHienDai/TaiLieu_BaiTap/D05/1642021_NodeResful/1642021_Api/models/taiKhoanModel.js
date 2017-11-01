var db = require('../fn_dao/dbconnect_mysql');

exports.loadAllTK = () => {
    var sql = 'select * from the';
    var obj = {};
    // db.load(sql).then(rows => {
    //     return rows;
    // });
    return db.load(sql);
};

exports.loadTaiKhoan = (mathe,matkhau,nganhang) => {
    var sql = `select * from the where MaThe = ${mathe}
                                    and MatKhau = ${matkhau}
                                    and NganHang = ${nganhang}`;
    return db.load(sql);
};