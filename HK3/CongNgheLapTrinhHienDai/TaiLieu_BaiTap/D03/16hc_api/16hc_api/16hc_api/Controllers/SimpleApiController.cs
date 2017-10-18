using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _16hc_api.Controllers
{
    public class SimpleApiController : ApiController
    {
        [HttpGet]
        [Route("api/simple/say")]
        public HttpResponseMessage SayHello()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "hello");
        }
    }
}
