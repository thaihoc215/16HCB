using _1642021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1642021.Controllers
{
    public class GiaoDichController : ApiController
    {
        [HttpPost]
        [Route("api/giaodich/ruttien")]
        public HttpResponseMessage RutTien([FromBody]Object[] rutTien)
        {
            int maTaiKhoan = int.Parse(rutTien[0].ToString());
            int maNganHang = int.Parse(rutTien[1].ToString());
            int loaiRut = int.Parse(rutTien[2].ToString());
            double soTienRut = double.Parse(rutTien[3].ToString());
            using (var ctx = new Models.REST_ATMEntities())
            {
                var nd = ctx.Thes.Where(t => t.MaThe == maTaiKhoan && t.NganHang == maNganHang).FirstOrDefault();
                if(nd == null)
                    return Request.CreateResponse(HttpStatusCode.NoContent, "Không tìm thấy tài khoản");
                switch (loaiRut)
                {
                    case 1:
                        soTienRut = 1000000;
                        break;
                    case 2:soTienRut = 2000000;
                        break;
                    case 3: soTienRut = 5000000;
                        break;
                    default:
                        break;
                }
                if(soTienRut%50000!=0)
                    return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Số tiền rút phải là bội số 50000");
                if(nd.SoDuKhaDung - soTienRut < 100000)
                    return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Số dư tài khoản không đủ");
                nd.SoDuKhaDung = nd.SoDuKhaDung - soTienRut;
                ctx.Entry(nd).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                List<object> rs = new List<object>();
                rs.Add("Rút tiền thành công");
                TheModel tkRutTien = new TheModel(ctx.Thes.Where(t => t.MaThe == nd.MaThe && t.NganHang == nd.NganHang).FirstOrDefault());
                tkRutTien.MatKhau = "";
                tkRutTien.TenNganHang = ctx.NganHangs.Where(ng => ng.MaNganHang == tkRutTien.NganHang).FirstOrDefault().TenNganHang;
                rs.Add(tkRutTien);
                GiaoDich gd = new GiaoDich();
                gd.TaiKhoan = tkRutTien.MaThe;
                gd.NganHangSoHu = tkRutTien.NganHang;
                gd.SoTienGiaoDich = soTienRut;
                gd.ThoiDiemGiaoDich = DateTime.Now;
                gd.LoaiGiaoDich = 1;
                ctx.GiaoDiches.Add(gd);
                ctx.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, rs);
            }
        }

        /// <summary>
        /// Chuc nang chuyen tien
        /// </summary>
        /// <param name="ck"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/giaodich/chuyentien")]
        public HttpResponseMessage ChuyenKhoan([FromBody]Object[] ck)
        {
            int maNguoiGui = int.Parse(ck[0].ToString());
            int maNguoiNhan = int.Parse(ck[1].ToString());
            double soTienGui = double.Parse(ck[2].ToString());
            int nganHangGui = int.Parse(ck[3].ToString());
            int nganHangNhan = int.Parse(ck[4].ToString());
            bool xacNhan = int.Parse(ck[5].ToString()) == 1 ? true : false;
            if (xacNhan == false)
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Không tiến hành giao dịch");
            using (var ctx = new Models.REST_ATMEntities())
            {
                var nd1 = ctx.Thes.Where(t => t.MaThe == maNguoiGui && t.NganHang == nganHangGui).FirstOrDefault();
                var nd2 = ctx.Thes.Where(t => t.MaThe == maNguoiNhan && t.NganHang == nganHangNhan).FirstOrDefault();
                if (nd2 != null)
                {
                    if (nd1.MaThe == nd2.MaThe && nd1.NganHang == nd2.NganHang)
                        return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Tài khoản người nhận phải khác tài khoản người gửi");

                    //kiem tra hop le tien gui
                    if (soTienGui <= 0)
                        return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Số tiền gửi không hợp lệ");
                    //kiem tra tai khoan nguon va dich


                    //con lai trong tai khoan it hon 100000
                    if (nd1.SoDuKhaDung - soTienGui < 100000)
                        return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Số dư trong tài khoản không đủ");
                    //chuyen khoan noi bo
                    if (nd1.NganHang == nd2.NganHang)
                    {
                        nd1.SoDuKhaDung -= (soTienGui + 3300);
                        ctx.Entry(nd1).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                        nd2.SoDuKhaDung += soTienGui;
                        ctx.Entry(nd2).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                        List<object> rs = new List<object>();
                        rs.Add("Chuyển khoản nội bộ.");
                        TheModel tkg = new TheModel(ctx.Thes.Where(t => t.MaThe == maNguoiGui && t.NganHang == nganHangGui).FirstOrDefault());
                        tkg.MatKhau = "";
                        tkg.TenNganHang = ctx.NganHangs.Where(ng => ng.MaNganHang == tkg.NganHang).FirstOrDefault().TenNganHang;
                        rs.Add(tkg);

                        TheModel tkn = new TheModel(ctx.Thes.Where(t => t.MaThe == maNguoiNhan && t.NganHang == nganHangNhan).FirstOrDefault());
                        tkn.MatKhau = "";
                        tkn.TenNganHang = ctx.NganHangs.Where(ng => ng.MaNganHang == tkn.NganHang).FirstOrDefault().TenNganHang;
                        rs.Add(tkn);
                        GiaoDich gd = new GiaoDich();
                        gd.TaiKhoan = tkg.MaThe;
                        gd.NganHangSoHu = tkg.NganHang;
                        gd.SoTienGiaoDich = soTienGui;
                        gd.ThoiDiemGiaoDich = DateTime.Now;
                        gd.LoaiGiaoDich = 2;
                        ctx.GiaoDiches.Add(gd);
                        ctx.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, rs);
                    }
                    if (nd1.NganHang != nd2.NganHang)
                    {
                        nd1.SoDuKhaDung -= (soTienGui + 11000);
                        ctx.Entry(nd1).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                        nd2.SoDuKhaDung += soTienGui;
                        ctx.Entry(nd2).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                        List<object> rs = new List<object>();
                        rs.Add("Chuyển khoản liên ngân hàng.");
                        TheModel tkg = new TheModel(ctx.Thes.Where(t => t.MaThe == maNguoiGui && t.NganHang == nganHangGui).FirstOrDefault());
                        tkg.MatKhau = "";
                        tkg.TenNganHang = ctx.NganHangs.Where(ng => ng.MaNganHang == tkg.NganHang).FirstOrDefault().TenNganHang;
                        rs.Add(tkg);

                        TheModel tkn = new TheModel(ctx.Thes.Where(t => t.MaThe == maNguoiNhan && t.NganHang == nganHangNhan).FirstOrDefault());
                        tkn.MatKhau = "";
                        tkn.TenNganHang = ctx.NganHangs.Where(ng => ng.MaNganHang == tkn.NganHang).FirstOrDefault().TenNganHang;
                        rs.Add(tkn);

                        GiaoDich gd = new GiaoDich();
                        gd.TaiKhoan = tkg.MaThe;
                        gd.NganHangSoHu = tkg.NganHang;
                        gd.SoTienGiaoDich = soTienGui;
                        gd.ThoiDiemGiaoDich = DateTime.Now;
                        gd.LoaiGiaoDich = 2;
                        ctx.GiaoDiches.Add(gd);
                        ctx.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, rs);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }

        [HttpGet]
        [Route("api/giaodich/xemgiaodich")]
        public HttpResponseMessage GetGiaoDich(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            using (var ctx = new Models.REST_ATMEntities())
            {
                var gdichs = ctx.GiaoDiches.Where(gd => gd.ThoiDiemGiaoDich >= ngayBatDau && gd.ThoiDiemGiaoDich <= ngayKetThuc);
                if (gdichs != null && gdichs.Count() > 0)
                {
                    List<GiaoDichModel> lst = new List<GiaoDichModel>();
                    foreach (var gd in gdichs)
                    {
                        GiaoDichModel giaoDich = new GiaoDichModel(gd);
                        giaoDich.TenGiaoDich = ctx.LoaiGiaoDiches.Where(g => g.MaLoai == gd.LoaiGiaoDich).FirstOrDefault().TenLoai;
                        giaoDich.TenChuThe = ctx.Thes.Where(t => t.MaThe == gd.TaiKhoan && t.NganHang == gd.NganHangSoHu).FirstOrDefault().TenChuThe;
                        lst.Add(giaoDich);
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, lst);
                }
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }
    }
}
