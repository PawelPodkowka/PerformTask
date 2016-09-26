using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using PerformTask.API.Repositories;
using PerformTask.Common.Model;
using PerformTask.Common.Validators;
using PerformTask.Common.Services;
using PerformTask.Common.Exceptions;

namespace PerformTask.API.Controllers
{
    public class NodesController : ApiController
    {
        private readonly INodesRepository _repository;
        private readonly IEqualityComparer<Connection> _connectionComparer;
        private readonly IValidator<IEnumerable<Node>> _graphValidator;
        private readonly IBidirectionalGraphMaker _bidirectionalGraphMaker;

        public NodesController(INodesRepository repository, IEqualityComparer<Connection> connectionComparer, IValidator<IEnumerable<Node>> graphValidator, IBidirectionalGraphMaker bidirectionalGraphMaker)
        {
            _repository = repository;
            _connectionComparer = connectionComparer;
            _graphValidator = graphValidator;
            _bidirectionalGraphMaker = bidirectionalGraphMaker;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var nodes = _repository.Get()
                                   .ToList()
                                   .Select(n => new {
                                       Node = new { Id = n.Id, Label = n.Label },
                                       Edges = n.AdjacentNodes.Select(c => new Connection(n.Id, c))
                                   });

            var result = new
            {
                Nodes = nodes.Select(x => x.Node),
                Edges = nodes.SelectMany(x => x.Edges).Distinct(_connectionComparer)
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Add(IEnumerable<Node> node)
        {
            if (!_graphValidator.Validate(node))
                return InternalServerError(new GraphValidationException("Graph is not valid!"));

            _bidirectionalGraphMaker.MakeBidirectionalGraph(node);

            _repository.ClearAll();
            await _repository.Create(node);
            return StatusCode(HttpStatusCode.Created);
        }
    }
}
