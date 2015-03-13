using NCop.Aspects.Aspects;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class NestedOnMethodBoundaryAspectWeaver : AbstractOnMethodBoundaryAspectWeaver
    {
        protected readonly IArgumentsWeaver argumentsWeaver = null;

        internal NestedOnMethodBoundaryAspectWeaver(IAspectWeaver nestedWeaver, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(nestedWeaver, aspectDefinition, aspectWeavingSettings) {
        }

        public override void Weave(ILGenerator ilGenerator) {
            weaver.Weave(ilGenerator);
        }
    }
}
