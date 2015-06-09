using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractBindingPropertyAspectWeaver : AbstractBindingTypeReflector<IPropertyAspectDefinition>
    {
        internal AbstractBindingPropertyAspectWeaver(IPropertyAspectDefinition aspectDefinition)
            : base(aspectDefinition) {
        }
    }
}
