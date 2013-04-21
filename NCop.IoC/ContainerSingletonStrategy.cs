using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NCop.IoC
{
    internal class ContainerSingletonStrategy : ILifetimeStrategy
    {
        private object instance = null;
        private readonly INCopContainer container = null;

        public ContainerSingletonStrategy(INCopContainer container) {
            this.container = container;
        }

        public TService Resolve<TService>(ResolveContext<TService> context) {
            if (context.Container.Equals(this.container)) {
                return (TService)(instance ?? ExchangeInstanceConditionally(ref instance, context.Factory));
            }

            return (TService)(context.Entry.Instance ?? CloneAndResolve<TService>(context));
        }

        private object CloneAndResolve<TService>(ResolveContext<TService> context) {
            var instance = context.Entry.Instance;
            
            return context.Entry.Instance = CloneAndResolve<TService>(context.Key, context.Entry, context.Container, context.Factory, ref instance);
        }

        private object CloneAndResolve<TService>(ServiceKey key, ServiceEntry entry, NCopContainer container, Func<TService> factory, ref object instance) {
            var clonedEntry = entry.CloneFor(container);

            container.LateRegister(key, clonedEntry);

            return clonedEntry.Instance = ExchangeInstanceConditionally(ref instance, factory);
        }

        private object ExchangeInstanceConditionally<TService>(ref object instance, Func<TService> factory) {
            Interlocked.CompareExchange(ref instance, factory(), null);

            return instance;
        }
    }
}