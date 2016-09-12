using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PerformTask.DataLoader.Interfaces;

namespace PerformTask.DataLoader
{
    internal class NodeCreator : INodeCreator
    {
        public Node Create(XDocument document)
        {
            var docNode = document.Root;
            var node = new Node
            {
                Id = Convert.ToInt32(docNode.Element(NodeAttributes.IdentifierName).Value),
                Label = GetLabel(docNode),
                AdjacentNodes = docNode.Element(NodeAttributes.AdjacentNodesName)
                                        .Elements(NodeAttributes.IdentifierName)
                                        .Select(x=> Convert.ToInt32(x.Value))
            };

            return node;
        }

        private string GetLabel(XElement document)
        {
            var labelElement = document.Element(NodeAttributes.LabelName);
            return labelElement?.Value ?? string.Empty;
        }
    }
}
