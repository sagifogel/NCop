using NCop.Aspects.Aspects.Interception;
using NCop.Aspects.Framework;
using System;

namespace NCop.Aspects.Aspects
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MethodInterceptionAspect : AspectAttribute
    {
        public virtual void OnInvoke(MethodInterception interception) { }
    }
}
