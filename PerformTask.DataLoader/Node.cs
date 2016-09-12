using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformTask.DataLoader
{
    public class Node
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public IEnumerable<int> AdjacentNodes { get; set; }
    }
}
