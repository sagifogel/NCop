using NCop.Composite.Extensions;
using NCop.Core;
using NCop.IoC;
using System;

namespace NCop.Composite.IoC
{
    internal class CompositeContainerAdapter : INCopDependencyContainer, INCopDependencyAwareRegistry
    {
        private readonly CompositeContainer container = null;

        public CompositeContainerAdapter() {
            container = new CompositeContainer();
        }

        public void Configure() {
            container.Configure();
        }

        public TService Resolve<TService>() {
            return container.Resolve<TService>();
        }

        public TService TryResolve<TService>() {
            return container.TryResolve<TService>();
        }

        public TService ResolveNamed<TService>(string name) {
            return container.ResolveNamed<TService>(name);
        }

        public TService TryResolveNamed<TService>(string name) {
            return container.TryResolveNamed<TService>(name);
        }

        public void Dispose() {
            container.Dispose();
        }

        public INCopDependencyContainer CreateChildContainer() {
            return container.CreateChildContainer();
        }

        public void Register(Type concreteType, Type serviceType, ITypeMap dependencies = null, string name = null) {
            var castAs = serviceType.GetTypeFromAttribute();
            var disposable = serviceType.GetDisposableFromAttribute();
            var compositeRegistration = new CompositeFrameworkRegistration(container, concreteType, serviceType, dependencies, castAs, name, disposable);

            container.Register(compositeRegistration);
        }
    }
}
