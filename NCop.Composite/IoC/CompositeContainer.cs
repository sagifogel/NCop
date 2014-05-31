using NCop.IoC;
using NCop.IoC.Fluent;
using System;
using NCop.Core.Extensions;
using NCop.Composite.Extensions;
using NCop.Composite.Properties;

namespace NCop.Composite.IoC
{
    internal class CompositeContainer : NCopContainer, IRegistrationResolver
    {
        private CompositeDependencyResolver dependencyResolver = null;

        public CompositeContainer() {
            dependencyResolver = new CompositeDependencyResolver(this);
        }

        protected override IContainerRegistry CreateRegistry() {
            return new CompositeContainerRegistry();
        }

        public IRegistration Resolve(Type concreteType) {
            return ((CompositeContainerRegistry)registry).Resolve(concreteType);
        }

        protected override TService ResolveImpl<TService, TFunc>(Func<TFunc, TService> factoryInvoker, string name = null, bool throwIfMissing = true) {
            var identifier = new ServiceKey(typeof(TService), typeof(TFunc), name);
            var nestedIdentifier = new ServiceKey(typeof(TService), typeof(TFunc), name);
            ServiceEntry entry = GetEntry(identifier);

            if (entry.IsNull()) {
                if (throwIfMissing) {
                    throw new ResolutionException(Resources.CouldNotResolveType.Fmt(identifier.ServiceType));
                }

                return default(TService);
            }

            return ResolveByContext(nestedIdentifier, entry, (Func<INCopDependencyResolver, TService> factory) => {
                return factory(dependencyResolver);
            });
        }

        private TService ResolveDependency<TService>() {
            return ResolveInternal<TService>();
        }

        public override TService Resolve<TService>() {
            return ResolveInternal<TService>(string.Empty.ToCompositeName());
        }

        private override TService ResolveUnNamed<TService>() {
            return ResolveInternal<TService>();
        }

        public override TService TryResolve<TService>() {
            return ResolveInternal<TService>(string.Empty.ToCompositeName(), false);
        }

        public override TService ResolveNamed<TService>(string name) {
            return ResolveInternal<TService>(name.ToCompositeName());
        }

        public override TService TryResolveNamed<TService>(string name) {
            return ResolveInternal<TService>(name.ToCompositeName(), false);
        }
    }
}
