using System;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.LifetimeStrategies;
using System.Diagnostics;
using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;

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
