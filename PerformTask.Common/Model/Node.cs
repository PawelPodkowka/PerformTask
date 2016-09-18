using System;
using System.Collections.Generic;
using System.Linq;

namespace PerformTask.Common.Model
{
    public class Node
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public List<int> AdjacentNodes { get; set; }
    }
}