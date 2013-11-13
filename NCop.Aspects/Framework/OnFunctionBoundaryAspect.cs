using System;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using System.Diagnostics;
using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Framework
{
    public abstract class OnFunctionBoundaryAspect<TInstance, TResult>
	{
		[OnMethodEntryAdvice]
        public virtual void OnEntry(FunctionExecutionArgs<TInstance, TResult> args) { }

		[FinallyAdvice]
        public virtual void OnExit(FunctionExecutionArgs<TInstance, TResult> args) { }

		[OnMethodSuccessAdvice]
        public virtual void OnSuccess(FunctionExecutionArgs<TInstance, TResult> args) { }

		[OnMethodExceptionAdvice]
        public virtual void OnException(FunctionExecutionArgs<TInstance, TResult> args) { }
	}
}
