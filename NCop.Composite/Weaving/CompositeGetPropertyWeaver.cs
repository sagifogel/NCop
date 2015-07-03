using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving;
using NCop.Weaving;
using System.Reflection;

namespace NCop.Composite.Weaving
{
    public class CompositeGetPropertyWeaver : AspectPropertyWeaver
    {
        public CompositeGetPropertyWeaver(IPropertyTypeBuilder propertyTypeBuilder, ITypeDefinition typeDefinition, PropertyInfo property, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(property.GetGetMethod(), aspectDefinitions, aspectWeavingSettings) {
            methodSignatureWeaver = new GetPropertyMethodSignatureWeaver(propertyTypeBuilder, typeDefinition);
        }
    }
}