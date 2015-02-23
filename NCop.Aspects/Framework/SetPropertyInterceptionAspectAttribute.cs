using NCop.Aspects.Aspects;
using System;

namespace NCop.Aspects.Framework
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class SetPropertyInterceptionAspectAttribute : AspectAttribute
    {
        public SetPropertyInterceptionAspectAttribute(Type aspectType)
            : base(aspectType) {
        }
    }
}
