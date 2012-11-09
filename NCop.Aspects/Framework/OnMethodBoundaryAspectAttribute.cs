using System;
using System.Diagnostics.Contracts;
using NCop.Aspects.Advices;
using NCop.Aspects.Aspects.Interception;
using NCop.Aspects.Engine;
using NCop.Aspects.LifetimeStrategies;
using System.Diagnostics;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.Framework
{
    [LifetimeStrategy(WellKnownLifetimeStrategy.Singleton)]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class OnMethodBoundaryAspectAttribute : AspectAttribute, IOnMethodBoundryContract
    {
        [OnInvokeAdvice]
        public virtual void OnInvoke(MethodExecution methodExecution) { }

        [OnFinallyAdvice]
        public virtual void Finally(MethodExecution methodExecution) { }

        [OnSuccessAdvice]
        public virtual void OnSuccess(MethodExecution methodExecution) { }

        [OnErrorAdvice]
        public virtual void OnError(MethodExecution methodExecution) { }
    }
}
