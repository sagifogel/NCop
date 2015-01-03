using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    public class AspectPropertyWeaver : AspectMethodWeaver
    {
        private readonly PropertyInfo propertyInfo = null;

        public AspectPropertyWeaver(PropertyInfo propertyInfo, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(aspectDefinitions, aspectWeavingSettings) {
            this.propertyInfo = propertyInfo;
        }
    }
}
