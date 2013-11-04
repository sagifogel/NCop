using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class ActionExecutionArgs<TArg1, TArg2, TArg3, TArg4> : ActionExecutionArgs<TArg1, TArg2, TArg3>
	{
        public TArg4 Arg4 { get; protected set; }
	}
}
