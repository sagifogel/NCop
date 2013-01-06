using NCop.Aspects.Aspects;
using System.Reflection.Emit;
using NCop.Aspects.Extensions;
using NCop.Weaving.Extensions;

namespace NCop.Aspects.Weaving
{
    internal class NestedOnMethodBoundaryAspectWeaver : AbstractOnMethodBoundaryAspectWeaver
    {
        protected IArgumentsWeaver argumentsWeaver = null;

        internal NestedOnMethodBoundaryAspectWeaver(IAspectWeaver nestedWeaver, IAspectDefinition aspectDefinition, IAspectWeavingSettings settings)
            : base(nestedWeaver, aspectDefinition, settings) {
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            return weaver.Weave(ilGenerator);
        }
    }
}
