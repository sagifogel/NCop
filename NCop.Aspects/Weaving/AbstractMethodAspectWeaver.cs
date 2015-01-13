using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractMethodAspectWeaver : AbstractAspectWeaver
    {
        protected readonly IMethodAspectDefinition aspectMethodDefinition = null;

        internal AbstractMethodAspectWeaver(IMethodAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(aspectDefinition, aspectWeavingSettings) {
            aspectMethodDefinition = aspectDefinition;
        }
    }
}
