using NCop.Aspects.Advices;
using NCop.Aspects.Aspects.Interception;
using NCop.Aspects.Engine;
using System;
using NCop.Aspects.LifetimeStrategies;
using NCop.Aspects.Aspects;
using NCop.Core.Engine;

namespace NCop.Aspects.Framework
{
    [LifetimeStrategy(WellKnownLifetimeStrategy.Singleton)]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class MethodInterceptionAspectAttribute : AspectAttribute, IMethodInterceptionContract
    {
        [OnInvokeAdvice]
        public virtual void OnInvoke(MethodInterception methodInterception) { }
    }
}
