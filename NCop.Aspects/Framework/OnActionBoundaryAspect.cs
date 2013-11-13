using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Advices;

namespace NCop.Aspects.Framework
{
	public class OnActionBoundaryAspect<TInstance>
	{
		[OnMethodEntryAdvice]
		public virtual void OnEntry(ActionExecutionArgs<TInstance> args) { }

		[FinallyAdvice]
        public virtual void OnExit(ActionExecutionArgs<TInstance> args) { }

		[OnMethodSuccessAdvice]
        public virtual void OnSuccess(ActionExecutionArgs<TInstance> args) { }

		[OnMethodExceptionAdvice]
        public virtual void OnException(ActionExecutionArgs<TInstance> args) { }
	
	}
}
