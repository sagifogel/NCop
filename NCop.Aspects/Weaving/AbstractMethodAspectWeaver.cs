using NCop.Aspects.Aspects;

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
