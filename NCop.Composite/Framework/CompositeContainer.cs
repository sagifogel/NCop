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
        private readonly INCopDependencyContainer dependencyContainer = null;

        public CompositeContainer(CompositeRuntimeSettings runtimeSettings = null) {
            IRuntime compositeRuntime = null;
            INCopDependencyAwareRegistry registry = null;
            INCopDependencyContainerAdapter compositeAdpater = null;

            runtimeSettings = runtimeSettings ?? CompositeRuntimeSettings.Empty;
            compositeAdpater = runtimeSettings.DependencyContainerAdapter;

            if (compositeAdpater.IsNotNull()) {
                dependencyContainer = compositeAdpater;
                registry = new NCopRegistryAdapter(compositeAdpater);
            }
            else {
                var compositeContainerAdapter = new CompositeContainerAdapter();

                registry = compositeContainerAdapter;
                dependencyContainer = compositeContainerAdapter;
            }

            registry = new CompositeRegistryDecorator(registry);
            compositeRuntime = new CompositeRuntime(runtimeSettings, registry);
            try {

                compositeRuntime.Run();
            }
            catch (System.Exception) {
                
            }
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
            return dependencyContainer.CreateChildContainer();
        }
    }
}
