using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionExecutionArgs<TArg1, TResult> : FunctionExecutionArgs<TResult>
	{
        public TArg1 Arg1 { get; set; }
	}
}
