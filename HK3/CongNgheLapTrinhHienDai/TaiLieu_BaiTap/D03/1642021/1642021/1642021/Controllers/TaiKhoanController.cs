using _1642021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1642021.Controllers
{
    public class TaiKhoanController : ApiController
    {
        [HttpGet]
        [Route("api/demo/sayhello")]
        public HttpResponseMessage SayHello()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "á");
        }

        /// <summary>
        /// Lay danh sach tai khoan the ngan hang
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Lấy thông tin thẻ
        /// </summary>
        /// <param name="maThe"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/taikhoan/thongtinthe")]
        public HttpResponseMessage GetTaiKhoan(int maThe, string matKhau)
        {
            using (var ctx = new Models.REST_ATMEntities())
            {
                var tkhoan = ctx.Thes.Where(t => t.MaThe == maThe).FirstOrDefault();
                if(tkhoan != null)
                {
                    if (tkhoan.MatKhau.Equals(matKhau))
                    {
                        tkhoan.MatKhau = "***";
                        TheModel rs = new TheModel(tkhoan);
                        rs.TenNganHang = ctx.NganHangs.Where(ng => ng.MaNganHang == rs.NganHang).FirstOrDefault().TenNganHang;
                        return Request.CreateResponse(HttpStatusCode.OK, rs);
                    }
                        
                    else
                        return Request.CreateErrorResponse(HttpStatusCode.NoContent,"Mật khẩu không đúng");
                }
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "Không tìm thấy tài khoản");

            }

        }

        
    }
}
