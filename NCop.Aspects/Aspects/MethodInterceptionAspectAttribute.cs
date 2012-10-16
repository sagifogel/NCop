using NCop.Aspects.Advices;
using NCop.Aspects.Aspects.Interception;
using NCop.Aspects.Engine;
using System;

namespace NCop.Aspects.Aspects
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MethodInterceptionAspectAttribute : AspectAttribute
    {   
        [OnInvokeAdvice]
        public virtual void OnInvoke(MethodInterception interception) { }
    }
}
