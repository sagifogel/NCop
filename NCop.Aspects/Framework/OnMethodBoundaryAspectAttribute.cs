using NCop.Aspects.Aspects;
using System;

namespace NCop.Aspects.Framework
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class OnMethodBoundaryAspectAttribute : AspectAttribute
	{
		public OnMethodBoundaryAspectAttribute(Type aspectType)
			: base(aspectType) {
		}
	}
}
