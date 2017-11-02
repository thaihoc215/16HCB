using APIClientServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIClientServer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        //  đăng nhập
        [HttpGet]
        [Route("api/login/{username}/{password}")]
        public HttpResponseMessage login(string username, string password)
        {
            using(WebClientEntities ctx = new WebClientEntities())
            {
                User user = ctx.Users.SingleOrDefault(u => u.username == username && u.password == password);
                if(user != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, user);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                }
            }
        }

        // Thêm user
        [HttpPost]
        [Route("api/user")]
        public HttpResponseMessage addUser([FromBody] User us)
        {
            using(WebClientEntities ctx = new WebClientEntities())
            {
                ctx.Users.Add(us);
                ctx.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, us);
            }

        }

        // Sửa user
        [HttpPut]
        [Route("api/user")]
        public IHttpActionResult updateUser([FromBody] User us)
        {
            using(WebClientEntities ctx = new WebClientEntities())
            {
                ctx.Users.Attach(us);
                var entry = ctx.Entry(us);
                entry.Property(x => x.username).IsModified = true;
                entry.Property(x => x.password).IsModified = true;
                entry.Property(x => x.fullname).IsModified = true;
                entry.Property(x => x.email).IsModified = true;
                entry.Property(x => x.phone).IsModified = true;
                entry.Property(x => x.username).IsModified = true;
                entry.Property(x => x.level).IsModified = true;

                ctx.SaveChanges();

                return Ok(us);
            }
        }

        // xóa user
        [HttpDelete]
        [Route("api/user/{id}")]
        public HttpResponseMessage deleteUser(int id)
        {
            using(WebClientEntities ctx = new WebClientEntities())
            {
                User us = new User
                {
                    id = id
                };

                ctx.Users.Attach(us);
                ctx.Users.Remove(us);
                ctx.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, new { deleteSuccess = true });

            }
        }

        // lấy tất cả user
        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult getAllUsers()
        {
            using(WebClientEntities ctx = new WebClientEntities())
            {
                var list = ctx.Users.ToList();

                return Ok(list);
            }
        }

        // Lấy một user theo mã
        [HttpGet]
        [Route("api/user/{id}")]
        public IHttpActionResult getUser(int id)
        {
            using(WebClientEntities ctx = new WebClientEntities())
            {
                var list = ctx.Users.Where(x => x.id == id).ToList();

                return Ok(list);
            }
        }
    }
}
