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
            return aspectType.GetCustomAttribute<LifetimeStrategyAttribute>(true)
                             .GetLifetimeStrategy(aspectType);
        }
    }

    public static class AspectBuilderExtensions
    {
        public static IAspectDefinitionCollection Build(this IAspectBuilder aspectBuilder, Func<IAspectDefinitionCollection> builder) {
            return builder();
        }
    }
}
