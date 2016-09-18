using PerformTask.Common.Model;
using System.Collections.Generic;

namespace PerformTask.Common.Services
{
    public interface IGraphPathFinder
    {
        IEnumerable<Connection> CalculateRoute(int start, int end, IEnumerable<Node> nodes);
    }
}
