using System.Xml.Linq;
using PerformTask.Common.Validators;

namespace PerformTask.DataLoader.Validators
{
    internal class EmptyContentValidator : IValidator<XDocument>
    {
        public bool Validate(XDocument document)
        {
            return document.Root != null;
        }
    }
}
