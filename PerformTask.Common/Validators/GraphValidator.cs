using System.Collections.Generic;
using System.Linq;
using PerformTask.Common.Model;

namespace PerformTask.Common.Validators
{
    public class GraphValidator : IValidator<IEnumerable<Node>>
    {
        public bool Validate(IEnumerable<Node> graph)
        {
            var allIds = graph.Select(x => x.Id);
            var allAdjacentIds = graph.SelectMany(x => x.AdjacentNodes)
                                    .Distinct();

            return !allAdjacentIds.Except(allIds).Any();
        }
    }
}
