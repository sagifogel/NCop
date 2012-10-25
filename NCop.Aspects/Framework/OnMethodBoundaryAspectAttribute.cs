using System;
using System.Diagnostics.Contracts;
using NCop.Aspects.Advices;
using NCop.Aspects.Aspects.Interception;
using NCop.Aspects.Engine;
using NCop.Aspects.LifetimeStrategies;
using System.Diagnostics;

namespace NCop.Aspects.Framework
{
    public class OnMethodBoundaryAspectAttribute : AspectAttribute
    {
        public OnMethodBoundaryAspectAttribute()
            : base() { }

        [OnInvokeAdvice]
        public virtual void OnInvoke(MethodExecution methodExecution) { }

        [OnFinallyAdvice]
        public virtual void Finally(MethodExecution methodExecution) { }

        [OnSuccessAdvice]
        public virtual void Success(MethodExecution methodExecution) { }

        [OnErrorAdvice]
        public virtual void Error(MethodExecution methodExecution) { }
    }
}
