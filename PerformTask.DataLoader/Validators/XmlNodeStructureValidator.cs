using System.Linq;
using System.Xml.Linq;
using PerformTask.Common.Validators;

namespace PerformTask.DataLoader.Validators
{
    internal class XmlNodeStructureValidator : IValidator<XDocument>
    {
        public bool Validate(XDocument document)
        {
            var node = document.Root;
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
