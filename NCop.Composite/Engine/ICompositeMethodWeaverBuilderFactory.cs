using NCop.Aspects.Weaving;
using NCop.Weaving;

namespace NCop.Composite.Engine
{
    public interface ICompositeMethodWeaverBuilderFactory
    {
        void Get(IPropertyTypeBuilder propertyTypeBuilder, ITypeDefinition typeDefinition, IAspectWeavingServices weavingServices);
    }
}
