using NCop.IoC;
using StructureMap;
using System;

namespace NCop.Samples
{
    public class StructureMapAdapter : INCopDependencyContainerAdapter
    {
        private readonly IContainer container = null;

        public StructureMapAdapter() {
            container = ObjectFactory.Container;
        }

        public StructureMapAdapter(IContainer container) {
            this.container = container;
        }

        public void Configure() { }

        public TService Resolve<TService>() {
            return container.GetInstance<TService>();
        }

        public TService TryResolve<TService>() {
            return container.TryGetInstance<TService>();
        }

        public TService ResolveNamed<TService>(string name) {
            return container.GetInstance<TService>(name);
        }

        public TService TryResolveNamed<TService>(string name) {
            return container.TryGetInstance<TService>(name);
        }

        public void Dispose() {
            container.Dispose();
        }

        public INCopDependencyContainer CreateChildContainer() {
            return new StructureMapAdapter(container.GetNestedContainer());
        }

        public void Register(Type concreteType, Type serviceType, string name = null) {
            container.Configure(x => {
                var use = x.For(serviceType)
                           .Use(concreteType);

                if (!string.IsNullOrEmpty(name)) {
                    use.Named(name);
                }
            });
        }
    }
}
