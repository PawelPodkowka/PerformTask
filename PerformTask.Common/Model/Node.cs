using System.Collections.Generic;

namespace PerformTask.Common.Model
{
    public class Node
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public IEnumerable<int> AdjacentNodes { get; set; }
    }
}