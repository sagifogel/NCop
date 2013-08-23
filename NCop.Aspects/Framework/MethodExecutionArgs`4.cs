using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public class MethodExecutionArgs<TArg1, TArg2, TArg3, TArg4, TResult> : MethodExecutionArgs<TArg1, TArg2, TArg3, TResult> 
	{
		public TArg4 Arg4 { get; private set; }
	}
}
