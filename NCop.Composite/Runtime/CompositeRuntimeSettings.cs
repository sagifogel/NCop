using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Runtime;

namespace NCop.Composite.Runtime
{
	public class CompositeRuntimeSettings : RuntimeSettings
	{
		private AspectsRuntimeSettings _aspectsRuntimeSettings = null;

		public CompositeRuntimeSettings()
		{
			_aspectsRuntimeSettings = new AspectsRuntimeSettings();
		}

		public IAspectBuilderProvider AspectBuilderProvider { get; set; }
	}
}
