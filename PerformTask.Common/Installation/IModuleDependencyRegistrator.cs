

using DryIoc;

namespace PerformTask.Common.Installation
{
    public interface IModuleDependencyRegistrator
    {
        void Register(IContainer container);
    }
}
