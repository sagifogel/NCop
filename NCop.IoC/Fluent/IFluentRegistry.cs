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
    }
}
