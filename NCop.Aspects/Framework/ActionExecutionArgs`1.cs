using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public abstract class ActionExecutionArgs<TArg1> : ActionExecutionArgs
	{
        public TArg1 Arg1 { get; set; }
	}
}
