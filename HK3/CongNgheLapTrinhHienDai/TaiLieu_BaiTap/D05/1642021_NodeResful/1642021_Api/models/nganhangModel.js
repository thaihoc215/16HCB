var db = require('../fn_dao/dbconnect_mysql');

exports.layDsNganHang = () => {
    // var sql = `Select * from NganHang where MaNganHang = ${maNganHang}`;
    var sql = `Select * from NganHang`;
    return db.load(sql);
};