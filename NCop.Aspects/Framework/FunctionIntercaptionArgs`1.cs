using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionInterceptionArgs<TArg1, TResult> : FunctionInterceptionArgs<TResult>
	{
		public TArg1 Arg1 { get; set; }
	}
}
