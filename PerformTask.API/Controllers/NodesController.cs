using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using PerformTask.API.Repositories;
using PerformTask.Common.Model;

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
            return Ok(nodes);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Add(IEnumerable<Node> node)
        {
            _repository.ClearAll();
            await _repository.Create(node);
            return StatusCode(HttpStatusCode.Created);
        }
    }
}
