using System;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using System.Diagnostics;
using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Framework
{
    public abstract class OnActionBoundaryAspect<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
    {	
		[OnMethodEntryAdvice]
		public virtual void OnEntry(ActionExecutionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> args) { }

		[FinallyAdvice]
		public virtual void OnExit(ActionExecutionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> args) { }

		[OnMethodSuccessAdvice]
		public virtual void OnSuccess(ActionExecutionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> args) { }

		[OnMethodExceptionAdvice]
		public virtual void OnException(ActionExecutionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> args) { }
	}
}
