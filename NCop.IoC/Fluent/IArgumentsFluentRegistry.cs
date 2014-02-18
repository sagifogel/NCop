using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC.Fluent
{
    public interface IArgumentsFluentRegistry : IFluentRegistry
    {
        IFactoryRegistration Register<TService, TArg1>(Func<INCopDependencyResolver, TArg1, TService> factory);
        IFactoryRegistration Register<TService, TArg1, TArg2>(Func<INCopDependencyResolver, TArg1, TArg2, TService> factory);
        IFactoryRegistration Register<TService, TArg1, TArg2, TArg3>(Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TService> factory);
        IFactoryRegistration Register<TService, TArg1, TArg2, TArg3, TArg4>(Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TService> factory);
        IFactoryRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TService> factory);
        IFactoryRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService> factory);
        IFactoryRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TService> factory);
        IFactoryRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TService> factory);
    }
}
