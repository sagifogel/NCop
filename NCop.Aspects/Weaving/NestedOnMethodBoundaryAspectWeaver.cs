using NCop.Aspects.Aspects;
using System.Reflection.Emit;
using NCop.Aspects.Extensions;
using NCop.Weaving.Extensions;
using System;

namespace NCop.Aspects.Weaving
{
    internal class NestedOnMethodBoundaryAspectWeaver : AbstractOnMethodBoundaryAspectWeaver
    {
        protected readonly Type topAspectInScopeArgType = null;
        protected readonly IArgumentsWeaver argumentsWeaver = null;

        internal NestedOnMethodBoundaryAspectWeaver(Type topAspectInScopeArgType, IAspectWeaver nestedWeaver, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(nestedWeaver, aspectDefinition, aspectWeavingSettings) {
            this.topAspectInScopeArgType = topAspectInScopeArgType;
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            return weaver.Weave(ilGenerator);
        }
    }
}
