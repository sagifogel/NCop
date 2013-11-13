using System;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using System.Diagnostics;
using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Framework
{
    public abstract class OnActionBoundaryAspect<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>
    {
        [OnMethodEntryAdvice]
        public virtual void OnEntry(ActionExecutionArgs<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> args) { }

        [FinallyAdvice]
        public virtual void OnExit(ActionExecutionArgs<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> args) { }

        [OnMethodSuccessAdvice]
        public virtual void OnSuccess(ActionExecutionArgs<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> args) { }

        [OnMethodExceptionAdvice]
        public virtual void OnException(ActionExecutionArgs<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> args) { }
    }
}
