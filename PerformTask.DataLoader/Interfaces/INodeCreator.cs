using System.Xml.Linq;

namespace PerformTask.DataLoader.Interfaces
{
    internal interface INodeCreator
    {
        Node Create(XDocument document);
    }
}
