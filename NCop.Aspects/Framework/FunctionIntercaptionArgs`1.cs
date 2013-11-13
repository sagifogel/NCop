using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionInterceptionArgs<TInstance, TArg1, TResult> : FunctionInterceptionArgs<TInstance, TResult>
	{
		public TArg1 Arg1 { get; protected set; }
	}
}
