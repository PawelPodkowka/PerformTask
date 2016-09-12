using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PerformTask.Common;
using PerformTask.DataLoader.Interfaces;

namespace PerformTask.DataLoader
{
    internal class XmlNodeStructureValidator : IValidator
    {
        public bool Validate(string content)
        {
            var document = XDocument.Parse(content);
            return document.Root.Element("id") != null;
        }
    }
}
