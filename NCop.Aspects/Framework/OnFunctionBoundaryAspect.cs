using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public abstract class OnFunctionBoundaryAspect<TResult> : IOnMethodBoundaryAspect
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
