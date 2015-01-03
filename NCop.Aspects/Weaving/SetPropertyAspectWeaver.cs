using NCop.Aspects.Aspects;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    public class SetPropertyAspectWeaver : AspectPropertyWeaver
    {
        public SetPropertyAspectWeaver(PropertyInfo propertyInfo, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(propertyInfo, aspectDefinitions, aspectWeavingSettings) {
        }
    }
}
