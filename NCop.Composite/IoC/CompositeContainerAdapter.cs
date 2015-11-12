using NCop.Composite.Extensions;
using NCop.Core;
using NCop.IoC;
using NCop.IoC.Fluent;

namespace NCop.Composite.IoC
{
    internal class CompositeContainerAdapter : INCopDependencyContainer, INCopDependencyAwareRegistry
    {
        private readonly CompositeContainer container = null;

        internal CompositeContainerAdapter(CompositeContainer container = null) {
            this.container = container ?? new CompositeContainer();
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

        public void Register(TypeMap typeMap, ITypeMapCollection dependencies = null, bool isComposite = false) {
            var serviceType = typeMap.ServiceType;
            var concreteType = typeMap.ConcreteType;
            IRegistration compositeRegistration = null;
            var castAs = serviceType.GetTypeFromAttribute();
            var disposable = serviceType.GetDisposableFromAttribute();

            compositeRegistration = isComposite ?
                                    new CompositeTypeRegistration(container, typeMap, dependencies, castAs, disposable) :
                                    new CompositeFrameworkRegistration(container, typeMap, dependencies, castAs, disposable);

            container.Register(compositeRegistration);
        }
    }
}
