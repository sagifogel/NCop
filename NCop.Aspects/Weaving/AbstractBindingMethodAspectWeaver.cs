using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractBindingMethodAspectWeaver : AbstractBindingTypeReflector<IMethodAspectDefinition>
    {
        internal AbstractBindingMethodAspectWeaver(IMethodAspectDefinition aspectDefinition)
            : base(aspectDefinition) {
        }
    }
}
