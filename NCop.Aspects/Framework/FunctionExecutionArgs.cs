using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Framework
{
	public class FunctionExecutionArgs<TResult> : MethodExecutionArgs, IFunctionExecutionArgs
	{
		public TResult ReturnType { get; private set; }
	}
}
