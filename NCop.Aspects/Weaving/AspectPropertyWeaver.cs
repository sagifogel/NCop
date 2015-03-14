using NCop.Aspects.Aspects;
using System.Reflection;
using NCop.Weaving;

namespace NCop.Aspects.Weaving
{
    public class AspectPropertyWeaver : AbstractAspectMethodWeaver
    {
        public AspectPropertyWeaver(MethodInfo method, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(method, aspectDefinitions, aspectWeavingSettings) {
        }
    }
}
