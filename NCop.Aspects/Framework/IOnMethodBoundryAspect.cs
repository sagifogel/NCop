using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public interface IOnMethodBoundryAspect : IAspect
    {
        [OnMethodEntryAdvice]
        void OnEntry(IMethodExecution methodExecution);

        [FinallyAdvice]
        void OnExit(IMethodExecution methodExecution);

        [OnMethodSuccessAdvice]
        void OnSuccess(IMethodExecution methodExecution);

        [OnMethodExceptionAdvice]
        void OnException(IMethodExecution methodExecution);
    }
}