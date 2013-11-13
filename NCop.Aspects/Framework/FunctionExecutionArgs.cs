using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionExecutionArgs<TInstance, TResult> : MethodExecutionArgs<TInstance>, IFunctionExecutionArgs
	{
		public TResult ReturnValue { get; protected set; }
	}
}
