using NCop.Core;
using NCop.Core.Extensions;
using NCop.IoC;
using StructureMap;

namespace NCop.Samples.IntegrationWithExternalIoC
{
    public class StructureMapAdapter : INCopDependencyContainerAdapter
    {
        private readonly IContainer container = null;

        public StructureMapAdapter()
            : this(ObjectFactory.Container) {
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

        public void Register(TypeMap typeMap, ITypeMapCollection dependencies = null) {
            container.Configure(x => {
                var name = typeMap.Name;
                var use = x.For(typeMap.ServiceType)
                           .Use(typeMap.ConcreteType);

                if (dependencies.IsNotNullOrEmpty()) {
                    dependencies.ForEach(dependency => {
                        use.WithCtorArg(dependency.Name);
                    });
                }
            });
        }
    }
}
