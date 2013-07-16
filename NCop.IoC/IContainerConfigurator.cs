using NCop.IoC.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public interface IContainerConfigurator<TFluentRegistry> where TFluentRegistry : IFluentRegistry
    {
        void Configure(Action<TFluentRegistry> registrationAction = null);
    }
}
