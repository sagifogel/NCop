using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NCop.Core.Extensions;

namespace NCop.IoC
{
    internal class SingletonLifetimeSrategy : ILifetimeStrategy
    {
        private object instance = null;

        public TService Resolve<TService, TFunc>(TFunc factory, Func<TFunc, TService> factoryInvoker) {
            return (TService)(instance ?? CreateInstance(factory, factoryInvoker));
        }

        private object CreateInstance<TService, TFunc>(TFunc factory, Func<TFunc, TService> factoryInvoker) {
            Interlocked.CompareExchange(ref instance, factoryInvoker(factory), null);

            return instance;
        }
    }
}
