using System;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using System.Diagnostics;
using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Framework
{
    public abstract class OnFunctionBoundaryAspect<TResult>
	{
		[OnMethodEntryAdvice]
        public virtual void OnEntry(FunctionExecutionArgs<TResult> args) { }

		[FinallyAdvice]
        public virtual void OnExit(FunctionExecutionArgs<TResult> args) { }

		[OnMethodSuccessAdvice]
        public virtual void OnSuccess(FunctionExecutionArgs<TResult> args) { }

		[OnMethodExceptionAdvice]
        public virtual void OnException(FunctionExecutionArgs<TResult> args) { }
	}
}
