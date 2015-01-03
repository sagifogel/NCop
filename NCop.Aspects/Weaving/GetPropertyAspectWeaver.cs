using NCop.Aspects.Aspects;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    public class GetPropertyAspectWeaver : AspectPropertyWeaver
    {
        public GetPropertyAspectWeaver(PropertyInfo propertyInfo, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(propertyInfo, aspectDefinitions, aspectWeavingSettings) {
        }
    }
}
