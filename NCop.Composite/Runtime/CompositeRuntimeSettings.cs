using NCop.Core.Extensions;
using NCop.Core.Runtime;
using NCop.IoC;
using System.Collections.Generic;
using System.Reflection;

namespace NCop.Composite.Runtime
{
	public class CompositeRuntimeSettings : IRuntimeSettings
	{
		protected IEnumerable<Assembly> assemblies = null;
		private readonly static RuntimeSettings runtimeSettings = null;
		public static CompositeRuntimeSettings Empty = new CompositeRuntimeSettings();

		static CompositeRuntimeSettings() {
			runtimeSettings = new RuntimeSettings();
		}

		public IEnumerable<Assembly> Assemblies {
			get {
				return assemblies ?? runtimeSettings.Assemblies;
			}
			set {
				if (value.IsNotNullOrEmpty()) {
					assemblies = value;
				}
			}
		}

		public INCopDependencyContainerAdapter DependencyContainerAdapter { get; set; }
	}
}
