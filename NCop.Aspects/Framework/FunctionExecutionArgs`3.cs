using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public abstract class FunctionExecutionArgs<TArg1, TArg2, TArg3, TResult> : FunctionExecutionArgs<TArg1, TArg2, TResult> 
	{
        public TArg3 Arg3 { get; set; }
	}
}
