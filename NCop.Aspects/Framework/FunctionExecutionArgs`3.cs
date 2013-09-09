using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public class FunctionExecutionArgs<TArg1, TArg2, TArg3, TResult> : FunctionExecutionArgs<TArg1, TArg2, TResult> 
	{
		public TArg3 Arg3 { get; private set; }
	}
}
