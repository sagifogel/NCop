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
    public abstract class MethodBoundaryAspectAttribute : AspectAttribute, IOnMethodBoundryContract
    {
        [OnInvokeAdvice]
        public abstract void OnInvoke(MethodExecution methodExecution);

        [OnFinallyAdvice]
        public abstract void Finally(MethodExecution methodExecution);

        [OnSuccessAdvice]
        public abstract void OnSuccess(MethodExecution methodExecution);

        [OnErrorAdvice]
        public abstract void OnError(MethodExecution methodExecution);
    }
}
