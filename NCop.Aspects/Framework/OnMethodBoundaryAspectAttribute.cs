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
    [LifetimeStrategy(KnownLifetimeStrategy.Singleton)]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public abstract class OnMethodBoundaryAspectAttribute : AspectAttribute, IOnMethodBoundryContract
    {
        [OnInvokeAdvice]
        public abstract void OnInvoke(IMethodExecution methodExecution);

        [OnFinallyAdvice]
        public abstract void Finally(IMethodExecution methodExecution);

        [OnSuccessAdvice]
        public abstract void OnSuccess(IMethodExecution methodExecution);

        [OnErrorAdvice]
        public abstract void OnError(IMethodExecution methodExecution);
    }
}
