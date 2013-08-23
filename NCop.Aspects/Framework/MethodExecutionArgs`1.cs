using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
	public class MethodExecutionArgs<TArg1, TResult> : MethodExecutionArgs<TResult>
	{
		public TArg1 Arg1 { get; private set; }
	}
}
