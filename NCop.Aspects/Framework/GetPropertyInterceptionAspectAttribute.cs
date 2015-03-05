using NCop.Aspects.Aspects;
using System;

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
