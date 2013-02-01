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
    public abstract class OnMethodBoundaryAspectAttribute : AspectAttribute, IOnMethodBoundryAspect
    {
        [OnInvokeAdvice]
        public abstract void OnEntry(IMethodExecution methodExecution);

        [FinallyAdvice]
        public abstract void OnExit(IMethodExecution methodExecution);

        [OnSuccessAdvice]
        public abstract void OnSuccess(IMethodExecution methodExecution);

        [OnExceptionAdvice]
        public abstract void OnException(IMethodExecution methodExecution);
    }
}
