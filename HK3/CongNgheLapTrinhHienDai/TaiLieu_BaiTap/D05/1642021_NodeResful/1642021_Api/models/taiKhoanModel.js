var db = require('../fn_dao/dbconnect_mysql');

exports.loadAllTK = () => {
    var sql = 'select * from the';
    var obj = {};
    // db.load(sql).then(rows => {
    //     return rows;
    // });
    console.log(db.load(sql));
    return db.load(sql);
};

exports.loadTaiKhoan = (mathe, matkhau, nganhang) => {
    let sql = `select t.MaThe MaThe,
                        t.TenChuThe TenChuThe,
                        t.SoDuKhaDung SoDuKhaDung,
                        t.NgayHetHan NgayHetHan,
                        t.MatKhau MatKhau,
                        nh.TenNganHang TenNganHang,
                        nh.MaNganHang MaNganHang
                from the t,nganhang nh
                where t.NganHang = nh.MaNganHang 
                                and t.MaThe = ${mathe}
                                and t.MatKhau = ${matkhau}
                                and t.NganHang = ${nganhang}`;
    return db.load(sql);
};

exports.loadThongTinTaiKhoan = (mathe, nganhang) => {
    let sql = `select t.MaThe MaThe,
                    t.TenChuThe TenChuThe,
                    t.SoDuKhaDung SoDuKhaDung,
                    t.NgayHetHan NgayHetHan,
                    nh.TenNganHang TenNganHang,
                    nh.MaNganHang MaNganHang
                from the t,nganhang nh
                where t.NganHang = nh.MaNganHang 
                            and t.MaThe = ${mathe}
                            and t.NganHang = ${nganhang}`;
    return db.load(sql);
};