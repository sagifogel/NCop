using NCop.IoC.Fluent;
using System.Collections.Generic;

namespace NCop.IoC
{
    public interface IContainerRegistry : IArgumentsFluentRegistry, INCopDependencyAwareRegistry, IEnumerable<IRegistration>, IRegisterEntry
    {
    }
}
