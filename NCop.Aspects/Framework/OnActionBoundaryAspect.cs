using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public class OnActionBoundaryAspect : IOnMethodBoundaryAspect
	{
		[OnMethodEntryAdvice]
		public virtual void OnEntry(ActionExecutionArgs args) { }

		[FinallyAdvice]
        public virtual void OnExit(ActionExecutionArgs args) { }

		[OnMethodSuccessAdvice]
        public virtual void OnSuccess(ActionExecutionArgs args) { }

		[OnMethodExceptionAdvice]
        public virtual void OnException(ActionExecutionArgs args) { }
	
	}
}
