using NCop.Aspects.Aspects;
using NCop.Weaving;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    public class SetPropertyAspectWeaver : AspectPropertyWeaver
    {
        public SetPropertyAspectWeaver(IPropertyTypeBuilder propertyTypeBuilder, MethodInfo method, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(method, aspectDefinitions, aspectWeavingSettings) {
            methodSignatureWeaver = new SetPropertyMethodSignatureWeaver(propertyTypeBuilder, aspectWeavingSettings.WeavingSettings.TypeDefinition);
        }
    }
}
