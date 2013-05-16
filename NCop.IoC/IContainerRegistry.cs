using NCop.IoC.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public interface IContainerRegistry : IFluentRegistry, IRegistry, IEnumerable<IRegistration>
    {
    }
}
