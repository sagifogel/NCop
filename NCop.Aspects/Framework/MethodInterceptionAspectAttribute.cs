using NCop.Aspects.Advices;
using NCop.Aspects.Aspects.Interception;
using NCop.Aspects.Engine;
using System;
using NCop.Aspects.LifetimeStrategies;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.Framework
{
    [LifetimeStrategy(KnownLifetimeStrategy.Singleton)]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public abstract class MethodInterceptionAspectAttribute : AspectAttribute, IMethodInterceptionAspect
    {
        [OnInvokeAdvice]
        public abstract void OnInvoke(IMethodInterception methodInterception);
    }
}
