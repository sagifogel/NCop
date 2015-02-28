using NCop.Aspects.Aspects;
using System;

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
