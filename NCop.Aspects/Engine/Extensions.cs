using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Extensions
{
    public static class LifetimeStrategiesExtensions
    {
        public static ILifetimeStrategy GetLifetimeStrategy(this Type aspectType) {
            return aspectType.GetCustomAttributes<LifetimeStrategyAttribute>(true)
                             .Select(provider => {
                                 return provider.GetLifetimeStrategy(aspectType);
                             })
                             .First();
        }
    }
}
