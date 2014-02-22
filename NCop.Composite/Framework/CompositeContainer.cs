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
		private readonly INCopDependencyContainerAdapter compositeAdapter = null;

		public CompositeContainer(CompositeRuntimeSettings runtimeSettings = null) {
            INCopRegistry registry = null;
            IRuntime compositeRuntime = null;

			runtimeSettings = runtimeSettings ?? CompositeRuntimeSettings.Empty;
			compositeAdapter = runtimeSettings.DependencyContainerAdapter ?? new CompositeContainerAdapter();
            registry = new CompositeRegistryDecorator(compositeAdapter);
			compositeRuntime = new CompositeRuntime(runtimeSettings, registry);
			compositeRuntime.Run();
		}

		public void Configure() {
			compositeAdapter.Configure();
		}

		public TService Resolve<TService>() {
			return compositeAdapter.Resolve<TService>();
		}

		public TService TryResolve<TService>() {
			return compositeAdapter.TryResolve<TService>();
		}

		public TService ResolveNamed<TService>(string name) {
			return compositeAdapter.ResolveNamed<TService>(name);
		}

		public TService TryResolveNamed<TService>(string name) {
			return compositeAdapter.TryResolveNamed<TService>(name);
		}

		public void Dispose() {
			compositeAdapter.Dispose();
		}

		public INCopDependencyResolver CreateChildContainer() {
			return compositeAdapter.CreateChildContainer();
		}
	}
}
