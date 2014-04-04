using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Composite.Weaving;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractTopOnMethodBoundaryAspectWeaver : AbstractOnMethodBoundaryAspectWeaver
    {
        internal AbstractTopOnMethodBoundaryAspectWeaver(IAspectWeaver nestedAspect, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(nestedAspect, aspectDefinition, aspectWeavingSettings) {
        }

        protected override void OnFunctionWeavingDetected() {
            returnValueWeaver = new TopGetReturnValueWeaver(aspectWeavingSettings, argumentsWeavingSetings);
        }
    }
}
