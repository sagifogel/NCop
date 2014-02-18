using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Runtime;
using NCop.IoC;
using NCop.Core.Extensions;
using Lib = NCop.Core.Lib;

namespace NCop.Composite.Runtime
{
	public class CompositeRuntimeSettings : IRuntimeSettings
	{
		protected IEnumerable<Assembly> assemblies = null;
		private static RuntimeSettings runtimeSettings = null;
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
