using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public class ActionExecutionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> : ActionExecutionArgs<TArg1, TArg2, TArg3, TArg4, TArg5>
	{
		public TArg6 Arg6 { get; private set; }
	}
}
