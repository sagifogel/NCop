using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public static class IoCExtensions
    {
        internal static ILifetimeStrategy ToStrategy(this ReuseScope scope, INCopDependencyResolver container) {
            return LifetimeStrategyFactory.Get(scope, container);
        }
    }
}
