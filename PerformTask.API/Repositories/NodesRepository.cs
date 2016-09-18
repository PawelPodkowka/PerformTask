using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PerformTask.API.DAL;
using PerformTask.Common.Model;

namespace PerformTask.API.Repositories
{
    public class NodesRepository : INodesRepository
    {
        private readonly NodesContext _dbContext;

        public NodesRepository(NodesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Node> Get()
        {
            return _dbContext.Nodes.AsQueryable();
        }

        public Task<int> Create(IEnumerable<Node> nodes)
        {
            throw new NotImplementedException();
        }

        public void ClearAll()
        {
            throw new NotImplementedException();
        }
    }
}