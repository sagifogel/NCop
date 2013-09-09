using System;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.LifetimeStrategies;
using System.Diagnostics;
using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Framework
{
	[LifetimeStrategy(KnownLifetimeStrategy.Singleton)]
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	public class OnMethodBoundaryAspectAttribute : AspectAttribute
	{
		public OnMethodBoundaryAspectAttribute(Type aspectType)
			: base(aspectType) {
		}
	}
}
