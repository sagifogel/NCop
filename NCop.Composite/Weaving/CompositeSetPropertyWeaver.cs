using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving;
using NCop.Weaving;
using System.Reflection;

namespace NCop.Composite.Weaving
{
    internal class CompositeSetPropertyWeaver : AspectPropertyWeaver
    {
        public CompositeSetPropertyWeaver(IPropertyTypeBuilder propertyTypeBuilder, PropertyInfo property, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(property.GetSetMethod(), aspectDefinitions, aspectWeavingSettings) {
            methodSignatureWeaver = new SetPropertyMethodSignatureWeaver(propertyTypeBuilder, aspectWeavingSettings.WeavingSettings.TypeDefinition);
        }
    }
}