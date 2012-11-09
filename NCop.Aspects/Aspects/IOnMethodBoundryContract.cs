using NCop.Aspects.Advices;
using NCop.Aspects.Aspects.Interception;
using NCop.Aspects.Engine;
using NCop.Core.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Aspects
{
    public interface IOnMethodBoundryContract : IAspect
    {
        [OnInvokeAdvice]
        void OnInvoke(MethodExecution methodExecution);

        [OnFinallyAdvice]
        void Finally(MethodExecution methodExecution);

        [OnSuccessAdvice]
        void OnSuccess(MethodExecution methodExecution);

        [OnErrorAdvice]
        void OnError(MethodExecution methodExecution);
    }
}
