using NCop.Aspects.Aspects;
using NCop.Weaving;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    public class GetPropertyAspectWeaver : AspectPropertyWeaver
    {
        public GetPropertyAspectWeaver(IPropertyTypeBuilder propertyTypeBuilder, MethodInfo method, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(method, aspectDefinitions, aspectWeavingSettings) {
            methodSignatureWeaver = new GetPropertyMethodSignatureWeaver(propertyTypeBuilder, aspectWeavingSettings.WeavingSettings.TypeDefinition);
        }
    }
}

