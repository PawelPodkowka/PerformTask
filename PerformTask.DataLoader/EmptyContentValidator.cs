using System.Xml.Linq;
using PerformTask.DataLoader.Interfaces;

namespace PerformTask.DataLoader
{
    internal class EmptyContentValidator : IValidator
    {
        public bool Validate(XDocument document)
        {
            return document.Root != null;
        }
    }
}
