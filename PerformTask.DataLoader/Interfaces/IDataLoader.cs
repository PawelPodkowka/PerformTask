using System.Collections.Generic;
using PerformTask.Common.Model;

namespace PerformTask.DataLoader.Interfaces
{
    internal interface IDataLoader
    {
        void Load(IEnumerable<Node> graph);
    }
}
