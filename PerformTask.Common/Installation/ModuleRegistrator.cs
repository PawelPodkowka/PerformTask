using System.Collections.Generic;
using DryIoc;
using PerformTask.Common.Model;
using PerformTask.Common.Services;
using PerformTask.Common.Validators;

namespace PerformTask.Common.Installation
{
    public class ModuleRegistrator : IModuleDependencyRegistrator
    {
        public void Register(IContainer container)
        {
            container.Register<IGraphPathFinder, GraphPathFinder>();
            container.Register<IValidator<IEnumerable<Node>>, GraphValidator>();
        }
    }
}
