using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC.Fluent
{
    public interface IFluentRegistry
    {
        ICastableRegistration<TCastable> Register<TCastable>();
        ICastableRegistration<TCastable> RegisterAuto<TCastable>();
        IReuseStrategyRegistration Register<TService>(Func<INCopContainer, TService> factory);
        IFactoryRegistration Register<TService, TArg1>(Func<INCopContainer, TArg1, TService> factory);
        IFactoryRegistration Register<TService, TArg1, TArg2>(Func<INCopContainer, TArg1, TArg2, TService> factory);
        IFactoryRegistration Register<TService, TArg1, TArg2, TArg3>(Func<INCopContainer, TArg1, TArg2, TArg3, TService> factory);
        IFactoryRegistration Register<TService, TArg1, TArg2, TArg3, TArg4>(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TService> factory);
        IFactoryRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TService> factory);
        IFactoryRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService> factory);
        IFactoryRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TService> factory);
        IFactoryRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TService> factory);
    }
}
