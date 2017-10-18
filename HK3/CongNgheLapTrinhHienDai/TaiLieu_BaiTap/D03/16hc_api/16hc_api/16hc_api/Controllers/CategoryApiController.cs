using _16hc_api.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _16hc_api.Controllers
{
    public class CategoryApiController : ApiController
    {
        [HttpGet]
        [Route("api/category/list")]
        public HttpResponseMessage GetList()
        {
            using (var ctx = new qlbhEntities()) {
                var list = ctx.Categories.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
        }

        [HttpGet]
        [Route("api/category/single")]
        public HttpResponseMessage GetOne(int id)
        {
            using (var ctx = new qlbhEntities()) {
                var category = ctx.Categories.Where(c => c.CatID == id).FirstOrDefault();
                if (category != null) {
                    return Request.CreateResponse(HttpStatusCode.OK, category);
                }

                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }

        [HttpPost]
        [Route("api/category/add")]
        public HttpResponseMessage Add([FromBody]Category c)
        {
            using (var ctx = new qlbhEntities()) {
                ctx.Categories.Add(c);
                ctx.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.Created, c);
            }
        }

        [HttpPut]
        [Route("api/category/update")]
        public HttpResponseMessage Update([FromBody]Category c)
        {
            using (var ctx = new qlbhEntities()) {
                ctx.Entry(c).State = EntityState.Modified;
                ctx.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.Created, c);
            }
        }

        [HttpDelete]
        [Route("api/category/delete")]
        public HttpResponseMessage Delete([FromBody]Category c)
        {
            using (var ctx = new qlbhEntities()) {
                ctx.Entry(c).State = EntityState.Deleted;
                ctx.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}
