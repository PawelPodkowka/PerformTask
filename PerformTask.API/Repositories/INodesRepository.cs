using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerformTask.Common.Model;

namespace PerformTask.API.Repositories
{
    public interface INodesRepository
    {
        IQueryable<Node> Get();

        Task<int> Create(IEnumerable<Node> nodes);

        void ClearAll();
    }
}
