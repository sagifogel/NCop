using NCop.Core;
using NCop.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSharpBinder = Microsoft.CSharp.RuntimeBinder;

namespace NCop.Aspects.Runtime
{
	public class AspectsRuntimeSettings : RuntimeSettings
	{
		private readonly RuntimeSettings _runtimeSettings = null;

		public AspectsRuntimeSettings(IEnumerable<Assembly> assemblies = null)
		{
			_runtimeSettings = new RuntimeSettings(assemblies);
		}

		public IEnumerable<Assembly> Assemblies
		{
			get { return _runtimeSettings.Assemblies; }
		}

		public IAspectBuilderProvider AspectBuilderProvider { get; set; }
	}
}
