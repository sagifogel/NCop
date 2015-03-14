using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving;
using NCop.Weaving;
using System.Reflection;

namespace NCop.Composite.Weaving
{
    internal class CompositeSetPropertyWeaver : AspectPropertyWeaver
    {
        public CompositeSetPropertyWeaver(IPropertyTypeBuilder propertyTypeBuilder, ITypeDefinition typeDefinition, PropertyInfo propertyInfo, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(propertyInfo.GetSetMethod(), aspectDefinitions, aspectWeavingSettings) {
            methodSignatureWeaver = new SetPropertyMethodSignatureWeaver(propertyTypeBuilder, typeDefinition);
        }
    }
}