using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NCop.Core.Runtime
{
	public class RuntimeSettings : IRuntimeSettings
	{
		protected Lib.Lazy<IEnumerable<Assembly>> LazyAssemblies = null;

		public RuntimeSettings(IEnumerable<Assembly> assemblies = null) {
			LazyAssemblies = new Lib.Lazy<IEnumerable<Assembly>>(() => assemblies ?? AssembliesInternal);
		}

		public IEnumerable<Assembly> Assemblies {
			get {
				return LazyAssemblies.Value;
			}
		}

		private static IEnumerable<Assembly> AssembliesInternal {
			get {
				return AppDomain.CurrentDomain
								.GetAssemblies()
								.Where(assembly => !IgnoredAssemblies.Instance.Contains(assembly));
			}
		}
	}
}
