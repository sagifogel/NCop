using NCop.IoC.Fluent;
using System;

namespace NCop.IoC
{
    public interface IContainerConfigurator<TFluentRegistry> where TFluentRegistry : IFluentRegistry
    {
        void Configure(Action<TFluentRegistry> registrationAction = null);
    }
}
