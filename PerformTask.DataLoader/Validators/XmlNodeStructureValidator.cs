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
            var containsId = ContainsPositiveIntegerAsAIdentifier(node.Element(NodeAttributes.IdentifierName));
            var containsAdjacentNodes = ContainsPositiveIntegersAsAdjcactentNodeIdentifiers(node.Element(NodeAttributes.AdjacentNodesName));

            return containsId && containsAdjacentNodes;
        }

        private bool ContainsPositiveIntegerAsAIdentifier(XElement element)
        {
            if (element == null) return false;

            var id = 0;
            int.TryParse(element.Value, out id);
            return id >= MIN_IDENTIFIER_VALUE;
        }

        private bool ContainsPositiveIntegersAsAdjcactentNodeIdentifiers(XContainer adjacentNodes)
        {
            if (adjacentNodes == null) return true;

            var adjacents = adjacentNodes.Elements(NodeAttributes.IdentifierName);
            return !adjacents.Any() || adjacents.All(ContainsPositiveIntegerAsAIdentifier);
        }
    }
}