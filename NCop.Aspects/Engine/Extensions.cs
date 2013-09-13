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

	public static class AspectBuilderExtensions
	{
		public static IAspectDefinitionCollection Build(this IAspectBuilder aspectBuilder, Func<IAspectDefinitionCollection> builder) {
			return builder();
		}

		public static bool Is<TAspect>(this IAspect aspectBuilder) where TAspect : IAspect {
			return typeof(TAspect).IsAssignableFrom(aspectBuilder.GetType());
		}

		public static bool IsMethodLevelAspect(this IAspect aspect) {
			var type = aspect.GetType();

			return typeof(OnMethodBoundaryAspectAttribute).IsAssignableFrom(type) ||
				   typeof(MethodInterceptionAspectAttribute).IsAssignableFrom(type);

		}
	}
}
