using NCop.Aspects.Aspects;
using NCop.Aspects.Aspects.Builders;
using NCop.Aspects.Framework;
using NCop.Aspects.LifetimeStrategies;
using NCop.Core.Extensions;
using System;

namespace NCop.Aspects.Extensions
{
	public static class LifetimeStrategiesExtensions
	{
		public static ILifetimeStrategy GetLifetimeStrategy(this Type aspectType) {
			var lifetimeStragtegy = aspectType.GetCustomAttribute<LifetimeStrategyAttribute>(true);

			return lifetimeStragtegy != null ?
				   lifetimeStragtegy.GetLifetimeStrategy(aspectType) :
				   new SingletonLifetimeStrategy(new AspectByReflectionFactory(aspectType));
		}
	}
}
