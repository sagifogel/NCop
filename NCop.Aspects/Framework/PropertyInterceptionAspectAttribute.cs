using System;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.Framework
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
	public class PropertyInterceptionAspectAttribute : AspectAttribute
	{
		public PropertyInterceptionAspectAttribute(Type aspectType)
			: base(aspectType) {
		}
	}
}
