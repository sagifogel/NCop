using System;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.LifetimeStrategies;
using System.Diagnostics;
using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Framework
{
    public abstract class OnMethodBoundaryAspectImpl<TResult>
    {	
		[OnMethodEntryAdvice]
		public virtual void OnEntry(MethodExecutionArgs<TResult> args) { }

		[FinallyAdvice]
		public virtual void OnExit(MethodExecutionArgs<TResult> args) { }

		[OnMethodSuccessAdvice]
		public virtual void OnSuccess(MethodExecutionArgs<TResult> args) { }

		[OnMethodExceptionAdvice]
		public virtual void OnException(MethodExecutionArgs<TResult> args) { }
	}
}
