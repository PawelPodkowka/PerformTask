using System.Linq;
using System.Xml.Linq;
using PerformTask.Common.Validators;

namespace PerformTask.DataLoader.Validators
{
    public class XmlNodeStructureValidator : IValidator<XDocument>
    {
        private const int MIN_IDENTIFIER_VALUE = 1;

        public bool Validate(XDocument document)
        {
            var node = document.Root;
            var containsId = ContainsPositiveIntegerAsAIdentifier(node.Element("id"));
            var containsAdjacentNodes = ContainsAtLeastOneAdjcactentNode(node.Element("adjacentNodes"));

            return containsId && containsAdjacentNodes;
        }

        private bool ContainsPositiveIntegerAsAIdentifier(XElement element)
        {
            if (element == null) return false;

            var id = 0;
            int.TryParse(element.Value, out id);
            return id >= MIN_IDENTIFIER_VALUE;
        }

        private bool ContainsAtLeastOneAdjcactentNode(XContainer adjacentNodes)
        {
            if (adjacentNodes == null) return false;

            var adjacents = adjacentNodes.Elements("id");
             return adjacents.Any() && adjacents.All(ContainsPositiveIntegerAsAIdentifier);
        }
    }
}
