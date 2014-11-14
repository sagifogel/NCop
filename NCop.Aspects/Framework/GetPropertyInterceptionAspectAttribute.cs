using System;
using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.Framework
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class GetPropertyInterceptionAspectAttribute : AspectAttribute
    {
		public GetPropertyInterceptionAspectAttribute(Type aspectType)
			: base(aspectType) {
		}
    }
}
