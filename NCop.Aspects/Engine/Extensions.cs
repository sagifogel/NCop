using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NCop.Aspects.Framework;
using NCop.Aspects.Advices;
using NCop.Core.Extensions;
using NCop.Core.Aspects;

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
