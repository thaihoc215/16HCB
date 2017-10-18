using _1642021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1642021.Controllers
{
    public class ATMApiController : ApiController
    {
        [HttpGet]
        [Route("api/demo/sayhello")]
        public HttpResponseMessage SayHello()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "á");
        }
        [HttpGet]
        [Route("api/taikhoan/dstaikhoan")]
        public HttpResponseMessage GetListTaiKhoan()
        {
            using (var ctx = new Models.REST_ATMEntities())
            {
                var lstThe = ctx.Thes.ToList();
                List<TheModel> lst = new List<TheModel>();
                foreach (var item in lstThe)
                {
                    TheModel tmp = new TheModel(item);
                    lst.Add(tmp);
                }
                return Request.CreateResponse(HttpStatusCode.OK, lst);
            }
        }

        [HttpGet]
        [Route("api/taikhoan/thongtinthe")]
        public HttpResponseMessage GetTaiKhoan(int maThe)
        {
            using (var ctx = new Models.REST_ATMEntities())
            {
                var tmp = ctx.Thes.Where(t => t.MaThe == maThe).FirstOrDefault();
                if(tmp != null)
                {
                    TheModel tkhoan = new TheModel(tmp);
                    return Request.CreateResponse(HttpStatusCode.OK, tkhoan);
                }
                return Request.CreateResponse(HttpStatusCode.NoContent);

            }

        }

        [HttpPost]
        [Route("api/chuyenkhoan/chuyentien")]
        public HttpResponseMessage ChuyenKhoanNoiBo([FromBody]ChuyenKhoan ck)
        {
            if (ck.XacNhan == false)
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Không tiến hành giao dịch");
            using (var ctx = new Models.REST_ATMEntities())
            {
                var nd1 = ctx.Thes.Where(t => t.MaThe == ck.MaNguoiGui).FirstOrDefault();
                var nd2 = ctx.Thes.Where(t => t.MaThe == ck.MaNguoiNhan).FirstOrDefault();
                if (nd2 != null)
                {
                    //kiem tra hop le tien gui
                    if (ck.SoTienGui <= 0)
                        return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Số tiền gửi không hợp lệ");
                    //kiem tra tai khoan nguon va dich
                    if (nd1.MaThe == nd2.MaThe)
                        return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Tài khoản người nhận phải khác tài khoản người gửi");
                    
                    //con lai trong tai khoan it hon 50000
                    if (nd1.SoDuKhaDung - ck.SoTienGui < 50000)
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
                        rs.Add(new TheModel(ctx.Thes.Where(t => t.MaThe == ck.MaNguoiGui).FirstOrDefault()));
                        rs.Add(new TheModel(ctx.Thes.Where(t => t.MaThe == ck.MaNguoiNhan).FirstOrDefault()));
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
                        rs.Add(new TheModel(ctx.Thes.Where(t => t.MaThe == ck.MaNguoiGui).FirstOrDefault()));
                        rs.Add(new TheModel(ctx.Thes.Where(t => t.MaThe == ck.MaNguoiNhan).FirstOrDefault()));
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

        public ChuyenKhoan()
        {

        }
    }

}
