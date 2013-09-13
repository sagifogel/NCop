using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using System;
using NCop.Aspects.LifetimeStrategies;
using NCop.Aspects.Aspects;
using NCop.Core.Visitors;

namespace NCop.Aspects.Framework
{
	[LifetimeStrategy(KnownLifetimeStrategy.Singleton)]
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class MethodInterceptionAspectAttribute : AspectAttribute
	{
		public MethodInterceptionAspectAttribute(Type aspectType)
			: base(aspectType) {
		}
	}
}
