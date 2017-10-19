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
        [Route("api/giaodich/rutien")]
        public HttpResponseMessage RutTien([FromBody]ChuyenKhoan ck)
        {
            return Request.CreateResponse(HttpStatusCode.NoContent, "Không tiến hành giao dịch");
        }
        /// <summary>
        /// Chuc nang chuyen tien
        /// </summary>
        /// <param name="ck"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/giaodich/chuyentien")]
        public HttpResponseMessage ChuyenKhoan([FromBody]ChuyenKhoan ck)
        {
            if (ck.XacNhan == false)
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Không tiến hành giao dịch");
            using (var ctx = new Models.REST_ATMEntities())
            {
                var nd1 = ctx.Thes.Where(t => t.MaThe == ck.MaNguoiGui && t.NganHang == ck.NganHangGui).FirstOrDefault();
                var nd2 = ctx.Thes.Where(t => t.MaThe == ck.MaNguoiNhan && t.NganHang == ck.NganHangNhan).FirstOrDefault();
                if (nd2 != null)
                {
                    if (nd1.MaThe == nd2.MaThe && nd1.NganHang == nd2.NganHang)
                        return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Tài khoản người nhận phải khác tài khoản người gửi");

                    //kiem tra hop le tien gui
                    if (ck.SoTienGui <= 0)
                        return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Số tiền gửi không hợp lệ");
                    //kiem tra tai khoan nguon va dich
                    

                    //con lai trong tai khoan it hon 100000
                    if (nd1.SoDuKhaDung - ck.SoTienGui < 100000)
                        return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Số dư trong tài khoản không đủ");
                    //chuyen khoan noi bo
                    if (nd1.NganHang == nd2.NganHang)
                    {
                        nd1.SoDuKhaDung -= (ck.SoTienGui + 3300);
                        ctx.Entry(nd1).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                        nd2.SoDuKhaDung += ck.SoTienGui;
                        ctx.Entry(nd2).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                        List<object> rs = new List<object>();
                        rs.Add("Chuyển khoản nội bộ.");
                        TheModel tkg = new TheModel(ctx.Thes.Where(t => t.MaThe == ck.MaNguoiGui && t.NganHang == ck.NganHangGui).FirstOrDefault());
                        tkg.MatKhau = "";
                        tkg.TenNganHang = ctx.NganHangs.Where(ng => ng.MaNganHang == tkg.NganHang).FirstOrDefault().TenNganHang;
                        rs.Add(tkg);

                        TheModel tkn = new TheModel(ctx.Thes.Where(t => t.MaThe == ck.MaNguoiNhan&& t.NganHang == ck.NganHangNhan).FirstOrDefault());
                        tkn.MatKhau = "";
                        tkn.TenNganHang = ctx.NganHangs.Where(ng => ng.MaNganHang == tkn.NganHang).FirstOrDefault().TenNganHang;
                        rs.Add(tkn);
                        return Request.CreateResponse(HttpStatusCode.OK, rs);
                    }
                    if (nd1.NganHang != nd2.NganHang)
                    {
                        nd1.SoDuKhaDung -= (ck.SoTienGui + 11000);
                        ctx.Entry(nd1).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                        nd2.SoDuKhaDung += ck.SoTienGui;
                        ctx.Entry(nd2).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                        List<object> rs = new List<object>();
                        rs.Add("Chuyển khoản liên ngân hàng.");
                        TheModel tkg = new TheModel(ctx.Thes.Where(t => t.MaThe == ck.MaNguoiGui && t.NganHang == ck.NganHangGui).FirstOrDefault());
                        tkg.MatKhau = "";
                        tkg.TenNganHang = ctx.NganHangs.Where(ng => ng.MaNganHang == tkg.NganHang).FirstOrDefault().TenNganHang;
                        rs.Add(tkg);

                        TheModel tkn = new TheModel(ctx.Thes.Where(t => t.MaThe == ck.MaNguoiNhan && t.NganHang == ck.NganHangNhan).FirstOrDefault());
                        tkn.MatKhau = "";
                        tkn.TenNganHang = ctx.NganHangs.Where(ng => ng.MaNganHang == tkn.NganHang).FirstOrDefault().TenNganHang;
                        rs.Add(tkn);
                        return Request.CreateResponse(HttpStatusCode.OK, rs);
                    }

                }
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }
    }

    public class ChuyenKhoan
    {
        public int MaNguoiGui { get; set; }
        public int MaNguoiNhan { get; set; }
        public double SoTienGui { get; set; }
        public bool XacNhan { get; set; }
        public int NganHangNhan { get; set; }
        public int NganHangGui { get; set; }
        public ChuyenKhoan()
        {

        }
    }
}
