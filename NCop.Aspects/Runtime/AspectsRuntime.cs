using NCop.Core;
using NCop.Core.Runtime;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

namespace NCop.Aspects.Runtime
{
	public class AspectsRuntime : IRuntime
	{
		private readonly IWeaver _weaver = null;
		private readonly AspectsRuntimeSettings _settings = null;
		
		public AspectsRuntime(AspectsRuntimeSettings settings)
		{
			Contract.Assert(settings != null, "Runtime Settings can not be null.");

			_settings = settings;
		}

		public void Run()
		{
		}
	}
}
