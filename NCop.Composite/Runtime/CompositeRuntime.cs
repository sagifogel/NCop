using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Aspects.Runtime;

namespace NCop.Composite.Runtime
{
	public class CompositeRuntime : AbstractRuntime
	{
		private readonly AspectsRuntime _aspectsRuntime = null;
		//private readonly MixinsRuntime _aspectsRuntime = null;

		public CompositeRuntime()
		{
			_aspectsRuntime = new AspectsRuntime(new AspectsRuntimeSettings());
		}

		public CompositeRuntime(RuntimeSettings settings) 
			: this()
		{
			Settings = settings;
		}

		public RuntimeSettings Settings { get; set; }

		public override void Run()
		{
			_aspectsRuntime.Run();
		}
	}
}
