using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public abstract class ActionExecutionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> : ActionExecutionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
	{
        public TArg7 Arg7 { get; protected set; }
	}
}