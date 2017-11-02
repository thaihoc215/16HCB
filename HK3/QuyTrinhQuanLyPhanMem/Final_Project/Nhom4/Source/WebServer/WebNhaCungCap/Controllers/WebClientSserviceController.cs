using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebNhaCungCap.Models;
using WebNhaCungCap.Utils;
using System.Web;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Web.Http.Cors;

namespace WebNhaCungCap.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/web")]
    public class WebClientSserviceController : ApiController
    {

        [HttpGet]
        [Route("getAuthenStatus/{username}/{token}")]
        public HttpResponseMessage getAuthenStatus(string username, string token)
        {

            String tokenDefault = ConfigurationManager.AppSettings["TokenUsingServerAPI"];
            if (token.Equals(tokenDefault))
            {
                AuthenDataContext db = new AuthenDataContext();

                User user = db.Users.SingleOrDefault(n => n.username == username);
                if (user == null)
                {
                    user = new User();
                    user.username = username;
                    string key = username;
                    //user.Token = Convert.ToBase64String(Encoding.UTF8.GetBytes(key));
                    user.secretKey = Utils.Utils.GenKey12Digit(key).Trim();
                    user.isEnable = false;
                    db.Users.InsertOnSubmit(user);
                    db.SubmitChanges();
                }


                return Request.CreateResponse(HttpStatusCode.OK, new { username = user.username, secretKey = user.secretKey, isEnable = user.isEnable });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Error = "Access deny!!!" });
            }

        }


        [HttpGet]
        [Route("Authen/{username}/{isEnable:bool}/{token}")]
        public HttpResponseMessage Authen(string username, bool isEnable, string token)
        {

            String tokenDefault = ConfigurationManager.AppSettings["TokenUsingServerAPI"];
            if (token.Equals(tokenDefault))
            {
                AuthenDataContext db = new AuthenDataContext();

                User user = db.Users.SingleOrDefault(n => n.username == username);
                if (user == null)
                {
                    user = new User();
                    user.username = username;
                    string key = username;
                    //user.Token = Convert.ToBase64String(Encoding.UTF8.GetBytes(key));
                    user.secretKey = Utils.Utils.GenKey12Digit(key).Trim();
                    user.isEnable = isEnable;
                    db.Users.InsertOnSubmit(user);
                }

                user.isEnable = isEnable;
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK, new { username = user.username, secretKey = user.secretKey, isEnable = user.isEnable });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Error = "Access deny!!!" });
            }
            //return Request.CreateResponse(HttpStatusCode.NotFound, new { Error = "not authentication!!!" });
            //return Request.CreateResponse(HttpStatusCode.NotFound, new { Error = "not authentication!!!" });
        }





        [HttpGet]
        [Route("CreateSecurityCodeBackup/{username}/{token}")]
        public HttpResponseMessage CreateSecurityCodeBackup(string username, string token)
        {
            String tokenDefault = ConfigurationManager.AppSettings["TokenUsingServerAPI"];
            if (token.Equals(tokenDefault))
            {
                AuthenDataContext db = new AuthenDataContext();

                User user = db.Users.SingleOrDefault(n => n.username == username);
                if (user == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Error = "User not exists!!!" });
                }
                if (user.isEnable)
                {
                    List<SecurityCodeBackup> lst = user.SecurityCodeBackups.Where(n => n.isUsed == false).ToList();
                    if (lst.Count() < 10)
                    {
                        String key = user.secretKey + CurrentMillis.CurrentTimeMillis.ToString();
                        for (int i = 0; i < 10 - lst.Count; i++)
                        {
                            SecurityCodeBackup b = new SecurityCodeBackup();

                            b.secutityCode = Utils.Utils.GetSecurityCodeBackup(key, i);
                            b.isUsed = false;
                            user.SecurityCodeBackups.Add(b);
                        }
                        db.SubmitChanges();
                    }
                    lst = user.SecurityCodeBackups.ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, new { username = user.username, backupcode = lst.Select(n => new { code = n.secutityCode.Trim(), isUsed = n.isUsed }) });
                    //return Request.CreateResponse(HttpStatusCode.OK, new { Seccess = true });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { username = user.username, isEnable = false });

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Error = "Access deny!!!" });
            }

        }

        [HttpGet]
        [Route("GetSecurityCodeBackup/{username}/{token}")]
        public HttpResponseMessage GetSecurityCodeBackup(string username, string token)
        {
            String tokenDefault = ConfigurationManager.AppSettings["TokenUsingServerAPI"];
            if (token.Equals(tokenDefault))
            {
                AuthenDataContext db = new AuthenDataContext();

                User user = db.Users.SingleOrDefault(n => n.username == username);
                if (user == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Error = "User not exists!!!" });
                }
                //return Request.CreateResponse(HttpStatusCode.OK, user.SecurityCodeBackups.Select(n => new { username = user.username, backupcode = n.secutityCode, IsUsed = n.isUsed }));
                return Request.CreateResponse(HttpStatusCode.OK, new { username = user.username, backupcode = user.SecurityCodeBackups.Select(n => new { code = n.secutityCode.Trim(), isUsed = n.isUsed }) });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Error = "Access deny!!!" });
            }
            //  return Request.CreateResponse(HttpStatusCode.NotFound, new { Error = "not authentication!!!" });
        }


        [HttpGet]
        [Route("CheckSecurityCode/{username_user}/{securityCode}/{token}")]
        public HttpResponseMessage CheckSecurityCode(string username_user, string securityCode, string token)
        {
            String tokenDefault = ConfigurationManager.AppSettings["TokenUsingServerAPI"];
            if (token.Equals(tokenDefault))
            {
                AuthenDataContext db = new AuthenDataContext();

                User user = db.Users.SingleOrDefault(n => n.username == username_user);
                if (user == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Error = "User not exists!!!" });
                string securityCodeServer = Utils.Utils.GetSecurityCode(user.secretKey);
                if (securityCode.Equals(securityCodeServer))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { username = user.username, check = true });
                }
                SecurityCodeBackup se = user.SecurityCodeBackups.SingleOrDefault(n => n.secutityCode.Trim().Equals(securityCode));
                if (se != null)
                {
                    se.isUsed = true;
                    db.SubmitChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, new { username = user.username, check = true });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { username = user.username, check = false });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Error = "Access deny!!!" });
            }
            //DateTime utcNow = DateTime.UtcNow;
            //DateTime timeAlive = new DateTime(utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute + 1, 0);

            //SecurityCode c = new SecurityCode(securityCode, CurrentMillis.DateTimeToLong(timeAlive));

            // return Request.CreateResponse(HttpStatusCode.OK, c);

            //  return Request.CreateResponse(HttpStatusCode.NotFound, new { Error = "not authentication!!!" });
        }

    }
}
