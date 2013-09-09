using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public class FunctionExecutionArgs<TArg1, TArg2, TArg3, TArg4, TResult> : FunctionExecutionArgs<TArg1, TArg2, TArg3, TResult> 
	{
		public TArg4 Arg4 { get; private set; }
	}
}
