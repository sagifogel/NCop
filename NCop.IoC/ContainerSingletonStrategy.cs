using System;
using System.Threading;

namespace NCop.IoC
{
    internal class ContainerSingletonStrategy : AbstractLifetimeStrategy
    {
        protected readonly INCopDependencyResolver container = null;

        public ContainerSingletonStrategy(INCopDependencyResolver container) {
            this.container = container;
        }

        public override TService Resolve<TService>(ResolveContext<TService> context) {
            if (context.Container.Equals(this.container)) {
                return (TService)(instance ?? ExchangeInstanceConditionally(ref instance, context.Factory));
            }

            return CloneAndResolve<TService>(context);
        }

        private TService CloneAndResolve<TService>(ResolveContext<TService> context) {
            return CloneAndResolve<TService>(context.Key, context.Entry, context.Container, context.Registry, context.Factory);
        }

        private TService CloneAndResolve<TService>(ServiceKey key, ServiceEntry entry, INCopDependencyResolver container, Action<ServiceKey, ServiceEntry> registry, Func<TService> factory) {
            ServiceEntry clonedEntry = entry.CloneFor(container);

            registry(key, clonedEntry);

            var context = new ResolveContext<TService> {
                Key = key,
                Factory = factory,
                Entry = clonedEntry,
                Registry = registry,
                Container = container
            };

            return (TService)clonedEntry.LifetimeStrategy.Resolve<TService>(context);
        }

        private object ExchangeInstanceConditionally<TService>(ref object instance, Func<TService> factory) {
            Interlocked.CompareExchange(ref instance, factory(), null);

            return instance;
        }
    }
}