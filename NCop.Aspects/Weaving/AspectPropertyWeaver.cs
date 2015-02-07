using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    public class AspectPropertyWeaver : AspectMethodWeaver
    {
        public AspectPropertyWeaver(MethodInfo method, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(method, aspectDefinitions, aspectWeavingSettings) {
        }
    }
}
