using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;

namespace NCop.Aspects.Weaving
{
    public class AspectPropertyWeaver : AspectMethodWeaver
    {
        public AspectPropertyWeaver(IAspectDefinitionCollection aspectDefinitions, IAspectPropertyMethodWeavingSettings aspectWeavingSettings)
            : base(aspectDefinitions, aspectWeavingSettings) {
        }
    }
}
