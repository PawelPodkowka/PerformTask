using System.Xml.Linq;
using PerformTask.Common.Model;

namespace PerformTask.DataLoader.Interfaces
{
    internal interface INodeCreator
    {
        Node Create(XDocument document);
    }
}
