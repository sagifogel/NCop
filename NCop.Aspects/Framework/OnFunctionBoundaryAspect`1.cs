using System;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using System.Diagnostics;
using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Framework
{
    public abstract class OnFunctionBoundaryAspect<TArg1, TResult>
    {	
		[OnMethodEntryAdvice]
        public virtual void OnEntry(FunctionExecutionArgs<TArg1, TResult> args) { }

		[FinallyAdvice]
        public virtual void OnExit(FunctionExecutionArgs<TArg1, TResult> args) { }

		[OnMethodSuccessAdvice]
        public virtual void OnSuccess(FunctionExecutionArgs<TArg1, TResult> args) { }

		[OnMethodExceptionAdvice]
        public virtual void OnException(FunctionExecutionArgs<TArg1, TResult> args) { }
	}
}
