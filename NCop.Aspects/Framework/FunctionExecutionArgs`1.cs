using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public class FunctionExecutionArgs<TArg1, TResult> : FunctionExecutionArgs<TResult>
	{
		public TArg1 Arg1 { get; private set; }
	}
}
