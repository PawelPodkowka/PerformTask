using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PerformTask.Common.Model;

namespace PerformTask.API.DAL
{
    public class NodeEnt : Node
    {
        public string AdjacentNodesAsString
        {
            get
            {
                if (!AdjacentNodes.Any()) return string.Empty;
                var strValues = AdjacentNodes.Select(x => x.ToString())
                                             .ToArray();
                return string.Join(",", strValues);
            }
            set
            {
                AdjacentNodes = value.Split(',')
                                     .Select(x => Convert.ToInt32(x))
                                     .ToList();
            }
        }
    }
}