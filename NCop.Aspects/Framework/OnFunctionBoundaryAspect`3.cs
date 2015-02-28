using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public abstract class OnFunctionBoundaryAspect<TArg1, TArg2, TArg3, TResult> : IOnMethodBoundaryAspect
    {	
		[OnMethodEntryAdvice]
		public virtual void OnEntry(FunctionExecutionArgs<TArg1, TArg2, TArg3, TResult> args) { }

		[FinallyAdvice]
		public virtual void OnExit(FunctionExecutionArgs<TArg1, TArg2, TArg3, TResult> args) { }

		[OnMethodSuccessAdvice]
		public virtual void OnSuccess(FunctionExecutionArgs<TArg1, TArg2, TArg3, TResult> args) { }

		[OnMethodExceptionAdvice]
		public virtual void OnException(FunctionExecutionArgs<TArg1, TArg2, TArg3, TResult> args) { }
	}
}
