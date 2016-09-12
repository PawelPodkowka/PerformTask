using System.Linq;
using System.Xml.Linq;
using PerformTask.DataLoader.Interfaces;

namespace PerformTask.DataLoader
{
    internal class XmlNodeStructureValidator : IValidator
    {
        public bool Validate(XDocument document)
        {
            var node = document.Root;
            if (node == null)return false;

            var containsId = node.Element("id") != null;
            var containsAdjacentNodes = ContainsAtLeastOneAdjcactentNode(node.Element("adjacentNodes"));

            return containsId && containsAdjacentNodes;
        }

        private bool ContainsAtLeastOneAdjcactentNode(XContainer adjacentNodes)
        {
            return adjacentNodes != null && adjacentNodes.Elements("id").Any();
        }
    }
}
