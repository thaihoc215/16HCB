var db = require('../fn_dao/dbconnect_mysql');

exports.rutTien = (mathe,manganhang,sotienconlai) =>{
    var sql = `update the set SoDuKhaDung = ${sotienconlai} 
                where mathe = ${mathe} and nganhang = ${manganhang}`;
    return db.load(sql);
};