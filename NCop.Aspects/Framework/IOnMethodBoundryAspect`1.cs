using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Advices;

namespace NCop.Aspects.Framework
{
	public interface IOnMethodBoundryAspect<TResult>
	{
		[OnMethodEntryAdvice]
		void OnEntry(MethodExecutionArgs<TResult> methodExecution);

		[FinallyAdvice]
		void OnExit(MethodExecutionArgs<TResult> methodExecution);

		[OnMethodSuccessAdvice]
		void OnSuccess(MethodExecutionArgs<TResult> methodExecution);

		[OnMethodExceptionAdvice]
		void OnException(MethodExecutionArgs<TResult> methodExecution);
	}
}
