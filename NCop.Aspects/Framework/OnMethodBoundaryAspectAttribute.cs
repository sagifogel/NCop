using System;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.LifetimeStrategies;
using System.Diagnostics;
using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Framework
{
    [LifetimeStrategy(KnownLifetimeStrategy.Singleton)]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public abstract class OnMethodBoundaryAspectAttribute : AspectAttribute, IOnMethodBoundryAspect
    {
        [OnMethodEntryAdvice]
        public virtual void OnEntry(IMethodExecution methodExecution) { }

        [FinallyAdvice]
        public virtual void OnExit(IMethodExecution methodExecution) { }

        [OnMethodSuccessAdvice]
        public virtual void OnSuccess(IMethodExecution methodExecution) { }

        [OnMethodExceptionAdvice]
        public virtual void OnException(IMethodExecution methodExecution) { }
    }
}
