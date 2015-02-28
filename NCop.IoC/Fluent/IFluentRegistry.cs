using System;

namespace NCop.IoC.Fluent
{
    public interface IFluentRegistry
    {
        ICastableRegistration<TCastable> Register<TCastable>();
        ICastableRegistration<TCastable> RegisterAuto<TCastable>();
        IReuseStrategyRegistration Register<TService>(Func<INCopDependencyResolver, TService> factory);        
    }
}
