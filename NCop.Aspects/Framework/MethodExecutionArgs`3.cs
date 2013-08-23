using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public class MethodExecutionArgs<TArg1, TArg2, TArg3, TResult> : MethodExecutionArgs<TArg1, TArg2, TResult> 
	{
		public TArg3 Arg3 { get; private set; }
	}
}
