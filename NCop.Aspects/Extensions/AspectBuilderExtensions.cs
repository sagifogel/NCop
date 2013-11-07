using NCop.Aspects.Aspects;
using NCop.Aspects.Aspects.Builders;
using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Extensions
{
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
