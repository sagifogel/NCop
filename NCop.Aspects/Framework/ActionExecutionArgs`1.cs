using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public abstract class ActionExecutionArgs<TInstance, TArg1> : ActionExecutionArgs<TInstance>
	{
        public TArg1 Arg1 { get; protected set; }
	}
}
