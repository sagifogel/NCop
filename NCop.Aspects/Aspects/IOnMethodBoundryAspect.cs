using NCop.Aspects.Advices;
using NCop.Aspects.Aspects.Interception;
using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Aspects
{
    public interface IOnMethodBoundryAspect : IAspect
    {
        [OnEntryAdvice]
        void OnEntry(IMethodExecution methodExecution);

        [FinallyAdvice]
        void OnExit(IMethodExecution methodExecution);

        [OnSuccessAdvice]
        void OnSuccess(IMethodExecution methodExecution);

        [OnExceptionAdvice]
        void OnException(IMethodExecution methodExecution);
    }
}