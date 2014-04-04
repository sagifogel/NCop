using NCop.Aspects.Aspects;
using System.Reflection.Emit;
using NCop.Aspects.Extensions;
using NCop.Weaving.Extensions;
using System;

namespace NCop.Aspects.Weaving
{
    internal class NestedOnMethodBoundaryAspectWeaver : AbstractOnMethodBoundaryAspectWeaver
    {
        protected readonly IArgumentsWeaver argumentsWeaver = null;

        internal NestedOnMethodBoundaryAspectWeaver(IAspectWeaver nestedWeaver, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(nestedWeaver, aspectDefinition, aspectWeavingSettings) {
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            return weaver.Weave(ilGenerator);
        }
    }
}
