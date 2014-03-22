using NCop.IoC.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public interface IContainerRegistry : IArgumentsFluentRegistry, INCopDependencyAwareRegistry, IEnumerable<IRegistration>, IRegisterEntry
    {
    }
}
