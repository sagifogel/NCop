using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using CSharpBinder = Microsoft.CSharp.RuntimeBinder;
using NCop.Core.Extensions;
using System.Collections;
using Lib = NCop.Core.Lib;

namespace NCop.Core.Runtime
{
	internal sealed class IgnoredAssemblies : IEnumerable<Assembly>
	{
		private ISet<Assembly> assemblies = null;
		private string objectPublicKeyToken = typeof(object).GetAssemblyPublicKeyToken();
		private string binderPublicKeyToken = typeof(CSharpBinder.Binder).GetAssemblyPublicKeyToken();
		private static Lib.Lazy<IgnoredAssemblies> ignoredAssemblies = new Lib.Lazy<IgnoredAssemblies>(() => new IgnoredAssemblies());

		private IgnoredAssemblies() {
			assemblies = AppDomain.CurrentDomain
								  .GetAssemblies()
								  .Where(assembly => {
									  return assembly.IsNCopAssembly() ||
											 assembly.HasSamePublicKeyToken(objectPublicKeyToken) ||
											 assembly.HasSamePublicKeyToken(binderPublicKeyToken);
								  })
								  .ToSet();
		}

		internal static IgnoredAssemblies Instance {
			get {
				return ignoredAssemblies.Value;
			}
		}

		public IEnumerator<Assembly> GetEnumerator() {
			return assemblies.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		internal bool Contains(Assembly assembly) {
			return assemblies.Contains(assembly);
		}
	}
}
