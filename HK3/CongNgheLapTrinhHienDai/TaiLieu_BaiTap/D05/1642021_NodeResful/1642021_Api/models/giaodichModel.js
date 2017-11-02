var db = require('../fn_dao/dbconnect_mysql');

exports.rutTien = (mathe, manganhang, sotienconlai) => {
    var sql = `update the set SoDuKhaDung = ${sotienconlai} 
                where mathe = ${mathe} and nganhang = ${manganhang}`;
    return db.load(sql);
};

exports.chuyenTien = (mathegui, nganhanggui, sodugui) => {
    let sql = `update the set SoDuKhaDung = ${sodugui} 
                where mathe = ${mathegui} and nganhang = ${nganhanggui}`;
    return db.load(sql);
}

exports.nhanTien = (mathenhan, nganhangnhan, sodunhan) => {
    let sql = `update the set SoDuKhaDung = ${sodunhan} 
                where mathe = ${mathenhan} and nganhang = ${nganhangnhan}`;
    return db.load(sql);
}