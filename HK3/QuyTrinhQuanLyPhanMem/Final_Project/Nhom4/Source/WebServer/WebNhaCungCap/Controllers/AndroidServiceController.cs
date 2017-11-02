using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebNhaCungCap.Models;
using WebNhaCungCap.Utils;

namespace WebNhaCungCap.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/android")]
    public class AndroidServiceController : ApiController
    {

        [HttpGet]
        [Route("login/{secretKey}")]
        public HttpResponseMessage Login(string secretKey)
        {
            AuthenDataContext db = new AuthenDataContext();
            User user = db.Users.SingleOrDefault(n => n.secretKey == secretKey);
            if (user != null)
                return Request.CreateResponse(HttpStatusCode.OK, new { username = user.username, loginState = true });
            else
                return Request.CreateResponse(HttpStatusCode.OK, new { username = "", loginState = false });
        }

        [HttpGet]
        [Route("synctime")]
        public HttpResponseMessage synctime()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { longTime = CurrentMillis.CurrentTimeMillis, type = "UTC" });

        }
        ////[HttpGet]
        ////[Route("securitycode/{securityCode}/{timeAlive:long}/{tokenUser}")]
        //public HttpResponseMessage SetSecurity_Code(string securityCode, long timeAlive, string tokenUser)
        //{
        //    TwoStepVerificationDataContext db = new TwoStepVerificationDataContext();
        //    User user = db.Users.SingleOrDefault(n => n.Token == tokenUser);
        //    if (user != null)
        //    {
        //        if (timeAlive < CurrentMillis.CurrentTimeMillis)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.RequestTimeout);
        //        }
        //        if (securityCode.Length > 10)
        //            securityCode = securityCode.Substring(0, 10);


        //        db.SubmitChanges();

        //        return Request.CreateResponse(HttpStatusCode.OK, "Ok");
        //    }
        //    else
        //        return Request.CreateResponse(HttpStatusCode.NotFound, "Error: not authentication!!!");
        //}

    }
}
