using System.Collections.Generic;
using System.Xml.Linq;

namespace PerformTask.DataLoader.Interfaces
{
    public interface ISourceReader
    {
        IEnumerable<XDocument> ReadNodes();
    }
}
