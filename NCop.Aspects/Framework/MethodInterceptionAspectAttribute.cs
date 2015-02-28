using NCop.Aspects.Aspects;
using System;

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
