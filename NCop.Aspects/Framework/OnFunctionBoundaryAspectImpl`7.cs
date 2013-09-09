using System;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.LifetimeStrategies;
using System.Diagnostics;
using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Framework
{
    public abstract class OnFunctionBoundaryAspectImpl<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>
    {	
		[OnMethodEntryAdvice]
		public virtual void OnEntry(FunctionExecutionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> args) { }

		[FinallyAdvice]
		public virtual void OnExit(FunctionExecutionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> args) { }

		[OnMethodSuccessAdvice]
		public virtual void OnSuccess(FunctionExecutionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> args) { }

		[OnMethodExceptionAdvice]
		public virtual void OnException(FunctionExecutionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> args) { }
	}
}
