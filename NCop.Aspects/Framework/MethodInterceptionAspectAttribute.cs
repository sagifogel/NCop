using NCop.Aspects.Advices;
using NCop.Aspects.Aspects.Interception;
using NCop.Aspects.Engine;
using System;
using NCop.Aspects.LifetimeStrategies;

namespace NCop.Aspects.Framework
{   
    [LifetimeStrategyAttribute(WellKnownLifetimeStrategy.Singleton)]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MethodInterceptionAspectAttribute : AspectAttribute
    {
        [OnInvokeAdvice]
        public virtual void OnInvoke(MethodInterception methodInterception) { }
    }
}
