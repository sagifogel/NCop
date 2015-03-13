using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractMethodAspectWeaver : AbstractAspectWeaver
    {
        protected readonly IAspectDefinition aspectMethodDefinition = null;

        internal AbstractMethodAspectWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(aspectDefinition, aspectWeavingSettings) {
            aspectMethodDefinition = aspectDefinition;
        }
    }
}
