using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Framework
{
	public abstract class MethodExecutionArgs
	{
		public object Instance { get; protected set; }
		public MethodBase Method { get; protected set; }
		public Exception Exception { get; protected set; }
		public FlowBehavior FlowBehavior { get; protected set; }
	}
}
