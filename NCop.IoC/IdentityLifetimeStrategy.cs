using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    internal class IdentityLifetimeStrategy : ILifetimeStrategy
    {
        public TService Resolve<TService, TFunc>(TFunc factory, Func<TFunc, TService> factoryInvoker) {
            return factoryInvoker(factory);
        }
    }
}
