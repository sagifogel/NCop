using NCop.Composite.Engine;
using NCop.Composite.IoC;
using NCop.Composite.Runtime;
using NCop.Core.Extensions;
using NCop.Core.Runtime;
using NCop.IoC;

namespace NCop.Composite.Framework
{
    public sealed class CompositeContainer : INCopDependencyContainer
    {
        private readonly CompositeRuntimeSettings runtimeSettings = null;
        private readonly INCopDependencyContainer dependencyContainer = null;

        public CompositeContainer(CompositeRuntimeSettings runtimeSettings = null)
            : this(runtimeSettings, null) {
        }

        private CompositeContainer(CompositeRuntimeSettings runtimeSettings = null, IoC.CompositeContainer container = null) {
            IRuntime compositeRuntime = null;
            INCopDependencyAwareRegistry registry = null;
            INCopDependencyContainerAdapter compositeAdpater = null;

            this.runtimeSettings = runtimeSettings ?? CompositeRuntimeSettings.Empty;
            compositeAdpater = this.runtimeSettings.DependencyContainerAdapter;

            if (compositeAdpater.IsNotNull()) {
                dependencyContainer = compositeAdpater;
                registry = new NCopRegistryAdapter(compositeAdpater);
            }
            else {
                var compositeContainerAdapter = new CompositeContainerAdapter(container);

                registry = compositeContainerAdapter;
                dependencyContainer = compositeContainerAdapter;
            }

            registry = new CompositeRegistryDecorator(registry);
            compositeRuntime = new CompositeRuntime(this.runtimeSettings, registry);
            compositeRuntime.Run();
        }

        public void Configure() {
            dependencyContainer.Configure();
        }

        public TService Resolve<TService>() {
            return dependencyContainer.Resolve<TService>();
        }

        public TService TryResolve<TService>() {
            return dependencyContainer.TryResolve<TService>();
        }

        public TService ResolveNamed<TService>(string name) {
            return dependencyContainer.ResolveNamed<TService>(name);
        }

        public TService TryResolveNamed<TService>(string name) {
            return dependencyContainer.TryResolveNamed<TService>(name);
        }

        public void Dispose() {
            dependencyContainer.Dispose();
        }

        public INCopDependencyContainer CreateChildContainer() {
            var childContainer = (NCop.Composite.IoC.CompositeContainer)dependencyContainer.CreateChildContainer();
            var newCompositeSettings = new CompositeRuntimeSettings {
                Types = runtimeSettings.Types,
                Assemblies = runtimeSettings.Assemblies
            };

            return new Framework.CompositeContainer(newCompositeSettings, childContainer);
        }
    }
}
