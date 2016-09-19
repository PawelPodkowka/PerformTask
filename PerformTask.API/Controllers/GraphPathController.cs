using System.Linq;
using System.Web.Http;
using PerformTask.API.Repositories;
using PerformTask.Common.Services;

namespace PerformTask.API.Controllers
{
    public class GraphPathController : ApiController
    {
        private readonly IGraphPathFinder _pathFinder;
        private readonly INodesRepository _nodeRepository;

        public GraphPathController(IGraphPathFinder pathFinder, INodesRepository nodeRepository)
        {
            _pathFinder = pathFinder;
            _nodeRepository = nodeRepository;
        }

        [HttpGet]
        public IHttpActionResult Get(int start, int end)
        {
            var nodes = _nodeRepository.Get().ToList();
            return Ok(_pathFinder.CalculateRoute(start, end, nodes));
        }
    }
}
