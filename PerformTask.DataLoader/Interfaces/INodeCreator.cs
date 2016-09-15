using System.Xml.Linq;
using PerformTask.Common.Model;

namespace PerformTask.DataLoader.Interfaces
{
    public interface INodeCreator
    {
        Node Create(XDocument document);
    }
}
