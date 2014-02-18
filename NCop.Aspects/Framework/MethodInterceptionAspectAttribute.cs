using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using System;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.Framework
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class MethodInterceptionAspectAttribute : AspectAttribute
    {
        public MethodInterceptionAspectAttribute(Type aspectType)
            : base(aspectType) {
        }
    }
}
