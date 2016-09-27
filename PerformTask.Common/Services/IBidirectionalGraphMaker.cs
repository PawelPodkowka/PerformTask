using PerformTask.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformTask.Common.Services
{
    public interface IBidirectionalGraphMaker
    {
        void MakeBidirectionalGraph(IEnumerable<Node> nodes);
    }
}
