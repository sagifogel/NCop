using NCop.Aspects.Advices;
using NCop.Aspects.Aspects.Interception;
using NCop.Aspects.Engine;
using System;
using NCop.Aspects.LifetimeStrategies;

namespace NCop.Aspects.Framework
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MethodInterceptionAspectAttribute : AspectAttribute
    {
        public MethodInterceptionAspectAttribute(WellKnownLifetimeStrategy lifetimeStrategy = LifetimeStrategies.WellKnownLifetimeStrategy.Singleton)
            : base(lifetimeStrategy) { }

        [OnInvokeAdvice]
        public virtual void OnInvoke(MethodInterception interception) { }
    }
}
