using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformTask.Common.Services
{
    public class BidirectionalGraphMaker : IBidirectionalGraphMaker
    {
        public void MakeBidirectionalGraph(IEnumerable<Model.Node> nodes)
        {
            foreach (var node in nodes)
            {
                node.AdjacentNodes.ForEach(x => FillAdjacentNodes(x, node.Id, nodes));
            }
        }

        private void FillAdjacentNodes(int nodeId, int adjacentNode, IEnumerable<Model.Node> nodes)
        {
            var node = nodes.SingleOrDefault(x => x.Id == nodeId);
            if (node == null || node.AdjacentNodes.Contains(adjacentNode)) return;

            node.AdjacentNodes.Add(adjacentNode);
        }
    }
}
