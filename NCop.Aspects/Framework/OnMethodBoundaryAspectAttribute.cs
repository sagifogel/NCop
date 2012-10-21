using System;
using System.Diagnostics.Contracts;
using NCop.Aspects.Advices;
using NCop.Aspects.Aspects.Interception;
using NCop.Aspects.Engine;
using NCop.Aspects.LifetimeStrategies;

namespace NCop.Aspects.Framework
{
    public class OnMethodBoundaryAspectAttribute : MethodInterceptionAspectAttribute
    {
        public OnMethodBoundaryAspectAttribute()
            : base() { }

        [OnFinallyAdvice]
        public virtual void Finally(MethodInterception interception) { }

        [OnSuccessAdvice]
        public virtual void Success(MethodInterception interception) { }

        [OnErrorAdvice]
        public virtual void Error(MethodInterception interception) { }
    }
}
