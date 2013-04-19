using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC.Fluent
{
    public interface IRegistry
    {
        ICastableRegistration<TCastable> Register<TCastable>();
        IFluenatRegistration Register<TService>(Func<INCopContainer, TService> factory);
        IFluenatRegistration Register<TService, TArg1>(Func<INCopContainer, TArg1, TService> factory);
        IFluenatRegistration Register<TService, TArg1, TArg2>(Func<INCopContainer, TArg1, TArg2, TService> factory);
        IFluenatRegistration Register<TService, TArg1, TArg2, TArg3>(Func<INCopContainer, TArg1, TArg2, TArg3, TService> factory);
        IFluenatRegistration Register<TService, TArg1, TArg2, TArg3, TArg4>(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TService> factory);
        IFluenatRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TService> factory);
        IFluenatRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService> factory);
        IFluenatRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TService> factory);
        IFluenatRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TService> factory);
    }
}
