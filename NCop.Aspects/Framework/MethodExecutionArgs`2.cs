using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public class MethodExecutionArgs<TArg1, TArg2, TResult> : MethodExecutionArgs<TArg1, TResult>
	{
		public TArg2 Arg2 { get; private set; }
	}
}
