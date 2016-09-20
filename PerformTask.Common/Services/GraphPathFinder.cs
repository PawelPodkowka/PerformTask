using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using PerformTask.Common.Model;

namespace PerformTask.Common.Services
{
    public class GraphPathFinder : IGraphPathFinder
    {
        public GraphPathFinder()
        {
                
        }

        public IEnumerable<Connection> CalculateRoute(int start, int end, IEnumerable<Node> nodes)
        {
            if (!CanCalculateRoute(start, end, nodes)) return null;

            var currentNode = nodes.Single(x => x.Id == start);
            var visitedNodes = new List<int> { start };
            var route = new List<Connection>();
            var routeFound = false;

            var possibleRoutes = new Dictionary<int, List<Connection>>();

            while (visitedNodes.Count() != nodes.Count() && !routeFound)
            {
                if (possibleRoutes.Any())
                {
                    var possibleRoute = possibleRoutes.FirstOrDefault(x => x.Value.Count() == possibleRoutes.Values.Select(y => y.Count()).Min());

                    currentNode = nodes.Single(x => x.Id == possibleRoute.Key);
                    route = new List<Connection>(possibleRoute.Value);
                    possibleRoutes.Remove(possibleRoute.Key);
                }

                foreach (var node in currentNode.AdjacentNodes)
                {
                    var currentRoute = route.ToList();
                    if (visitedNodes.Contains(node)) continue;

                    currentRoute.Add(new Connection(currentNode.Id, node));
                    possibleRoutes.Add(node, currentRoute);
                    visitedNodes.Add(node);
                    routeFound = node == end;
                    if (routeFound) break;
                }
            }

           return possibleRoutes[end];
        }

        private bool CanCalculateRoute(int start, int end, IEnumerable<Node> nodes)
        {
            return start != end && nodes.Count(x => x.Id == start || x.Id == end) == 2;
        }
    }
}
