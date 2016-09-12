using System.Web.Http;
using PerformTask.Common.Model;

namespace PerformTask.API.Controllers
{
    public class NodesController : ApiController
    {

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Add(Node node)
        {

            return Ok();
        }
    }
}
