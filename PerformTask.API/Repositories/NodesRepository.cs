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
            var nodesToAdd = nodes.Select(NodeEnt.CreateFromNode);
            _dbContext.Nodes.AddRange(nodesToAdd);
            return _dbContext.SaveChangesAsync();
        }

        public void ClearAll()
        {
            _dbContext.Database.ExecuteSqlCommand("truncate table Nodes");
        }
    }
}