using System;
using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.Framework
{
    public class GetPropertyInterceptionAspectAttribute : PropertyInterceptionAspectAttribute
    {
		public GetPropertyInterceptionAspectAttribute(Type aspectType)
			: base(aspectType) {
		}
    }
}
