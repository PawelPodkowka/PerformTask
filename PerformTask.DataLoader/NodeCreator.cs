using System;
using System.Linq;
using System.Xml.Linq;
using PerformTask.Common.Model;
using PerformTask.DataLoader.Interfaces;

namespace PerformTask.DataLoader
{
    public class NodeCreator : INodeCreator
    {
        public Node Create(XDocument document)
        {
            var docNode = document.Root;
            return new Node
            {
                Id = Convert.ToInt32(docNode.Element(NodeAttributes.IdentifierName).Value),
                Label = GetLabel(docNode),
                AdjacentNodes = docNode.Element(NodeAttributes.AdjacentNodesName)
                                        .Elements(NodeAttributes.IdentifierName)
                                        .Select(x=> Convert.ToInt32(x.Value))
                                        .ToList()
            };
        }

        private string GetLabel(XElement document)
        {
            var labelElement = document.Element(NodeAttributes.LabelName);
            return labelElement.Value ?? string.Empty;
        }
    }
}
