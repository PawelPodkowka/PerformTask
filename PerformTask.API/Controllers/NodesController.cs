using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PerformTask.API.Repositories;
using PerformTask.Common.Model;
using PerformTask.Common.Services;

namespace PerformTask.API.Controllers
{
    public class NodesController : ApiController
    {
        private readonly INodesRepository _repository;

        public NodesController(INodesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var nodes = _repository.Get();
            if (nodes.Any())
            {
                return Ok(nodes);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPost]
        public IHttpActionResult Add(IEnumerable<Node> node)
        {

            return Ok();
        }
    }
}
