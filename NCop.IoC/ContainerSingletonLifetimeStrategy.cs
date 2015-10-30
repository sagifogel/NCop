using System;

namespace NCop.IoC
{
    internal class ContainerSingletonLifetimeStrategy : AbstractSingletonLifetimeStrategy
    {
        protected readonly INCopDependencyResolver container = null;

        public ContainerSingletonLifetimeStrategy(INCopDependencyResolver container) {
            this.container = container;
        }

        public override TService Resolve<TService>(ResolveContext<TService> context) {
            if (context.Container.Equals(container)) {
                return lazy.Get(context.Factory);
            }

            return CloneAndResolve(context);
        }

        private TService CloneAndResolve<TService>(ResolveContext<TService> context) {
            return CloneAndResolve(context.Key, context.Entry, context.Container, context.Registry, context.Factory);
        }

        private TService CloneAndResolve<TService>(ServiceKey key, ServiceEntry entry, INCopDependencyContainer container, Action<ServiceKey, ServiceEntry> registry, Func<TService> factory) {
            var clonedEntry = entry.CloneFor(container);

            registry(key, clonedEntry);

            var context = new ResolveContext<TService> {
                Key = key,
                Factory = factory,
                Entry = clonedEntry,
                Registry = registry,
                Container = container
            };

            return clonedEntry.LifetimeStrategy.Resolve(context);
        }
    }
}