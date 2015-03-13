using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving;
using System.Reflection;

namespace NCop.Composite.Weaving
{
    public class CompositeGetPropertyWeaver : AspectMethodWeaver
    {
        public CompositeGetPropertyWeaver(PropertyInfo propertyInfo, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(propertyInfo.GetGetMethod(), aspectDefinitions, aspectWeavingSettings) {
        }
    }
}