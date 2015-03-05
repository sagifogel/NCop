
using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving;
using System.Reflection;

namespace NCop.Composite.Weaving
{
    public class CompositeSetPropertyWeaver : AspectMethodWeaver
    {
        public CompositeSetPropertyWeaver(PropertyInfo propertyInfo, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(propertyInfo.GetSetMethod(), aspectDefinitions, aspectWeavingSettings) {
        }
    }
}