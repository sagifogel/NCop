using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.IoC;
using NCop.IoC.Fluent;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.Composite.Engine;
using System.Threading;
using NCop.Core.Runtime;
using NCop.Composite.Runtime;
using NCop.Composite.IoC;

namespace NCop.Composite.Framework
{
    public class CompositeContainer : INCopDependencyContainer
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
            return dependencyContainer.CreateChildContainer();
        }
    }
}
