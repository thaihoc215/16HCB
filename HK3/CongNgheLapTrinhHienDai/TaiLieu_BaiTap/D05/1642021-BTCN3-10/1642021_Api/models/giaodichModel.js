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

exports.luuGiaoDich = (mathe, nganhang, sotien, thoigian, loaigiaodich) => {
    let sql = `insert into giaodich(TaiKhoan,NganHangSoHu,SoTienGiaoDich,ThoiDiemGiaoDich,loaigiaodich)
    values (${mathe},${nganhang},${sotien},'${thoigian}',${loaigiaodich})`;
    return db.load(sql);
};

exports.layGiaoDich = (mathe) => {
    let sql = `select gd.MaGiaoDich MaGiaoDich, 
                        gd.SoTienGiaoDich SoTienGiaoDich,
                        gd.ThoiDiemGiaoDich ThoiDiemGiaoDich,
                        lgd.TenLoai TenLoai
                from giaodich gd,
                    loaigiaodich lgd
                where gd.LoaiGiaoDich = lgd.MaLoai
                        and gd.TaiKhoan = ${mathe}`;
    return db.load(sql);
};

exports.layGiaoDichNgay = (mathe, ngaybatdau, ngayketthuc) => {
    let sql = `select gd.MaGiaoDich MaGiaoDich, 
                    gd.SoTienGiaoDich SoTienGiaoDich,
                    gd.ThoiDiemGiaoDich ThoiDiemGiaoDich,
                    lgd.TenLoai TenLoai
                from giaodich gd,
                loaigiaodich lgd
                where gd.LoaiGiaoDich = lgd.MaLoai
                    and gd.TaiKhoan = ${mathe}
                    and gd.ThoiDiemGiaoDich >= '${ngaybatdau}' 
                    and gd.ThoiDiemGiaoDich <= '${ngayketthuc}'`;
    return db.load(sql);
};