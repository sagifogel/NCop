using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionExecutionArgs<TResult> : MethodExecutionArgs, IFunctionExecutionArgs
	{
		public TResult ReturnValue { get; protected set; }
	}
}
