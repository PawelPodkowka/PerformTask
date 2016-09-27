using System;
using System.Linq;
using System.Xml.Linq;
using PerformTask.Common.Model;
using PerformTask.DataLoader.Interfaces;
using System.Collections.Generic;

namespace PerformTask.DataLoader
{
    public class NodeCreator : INodeCreator
    {
        private const string DEFAULT_LABEL_PREFIX = "Node {0}";

        public Node Create(XDocument document)
        {
            var docNode = document.Root;
            var id = Convert.ToInt32(docNode.Element(NodeAttributes.IdentifierName).Value);
            return new Node
            {
                Id = id,
                Label = GetLabel(docNode, id),
                AdjacentNodes = GetAdjacentNodes(docNode.Element(NodeAttributes.AdjacentNodesName))
            };
        }

        private List<int> GetAdjacentNodes(XElement adjacentNodes)
        {
            return adjacentNodes == null ? new List<int>()
                                         : ReadAdjacnetNodes(adjacentNodes);
        }

        private List<int> ReadAdjacnetNodes(XElement adjacentNodes)
        {
            return adjacentNodes.Elements(NodeAttributes.IdentifierName)
                                .Select(x => Convert.ToInt32(x.Value))
                                .ToList();
        }

        private string GetLabel(XElement document, int id)
        {
            var labelElement = document.Element(NodeAttributes.LabelName);
            return labelElement?.Value ?? string.Format(DEFAULT_LABEL_PREFIX, id);
        }
    }
}
