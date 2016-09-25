using PerformTask.Common.Model;
using System.Collections.Generic;

namespace PerformTask.API.Comparers
{
    public class BidirectionalConnectionComparer : IEqualityComparer<Connection>
    {
        public bool Equals(Connection x, Connection y)
        {
            return (x.From == y.From && x.To == y.To)
                    || (x.From == y.To && x.To == y.From);
        }

        public int GetHashCode(Connection obj)
        {
            return obj.From ^ obj.To;
        }
    }
}