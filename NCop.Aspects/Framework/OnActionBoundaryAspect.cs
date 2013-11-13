using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Advices;

namespace NCop.Aspects.Framework
{
	public class OnActionBoundaryAspect
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
