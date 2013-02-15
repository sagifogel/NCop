using NCop.Aspects.Aspects;
using NCop.Aspects.Aspects.Builders;
using NCop.Core.Weaving;
using NCop.Core.Weaving.Responsibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Weaving
{
    public class AspectMethodWeaverHandler : AbstractMethodWeaverHandler
    {
        public AspectMethodWeaverHandler(Type type)
            : base(type) {
        }

        public override IMethodWeaver Handle(MethodInfo methodInfo, ITypeDefinition typeDefinition) {
            IAspectBuilder aspectBuilder;

            if (KnownAspects.TryMatchAspectBuilder(methodInfo, out aspectBuilder)) {
                return new AspectStrategyWeaver(aspectBuilder);
            }

            return NextHandler.Handle(methodInfo, typeDefinition);
        }
    }
}
