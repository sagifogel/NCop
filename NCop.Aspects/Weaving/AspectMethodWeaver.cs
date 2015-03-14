using NCop.Aspects.Aspects;
using NCop.Weaving;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    public class AspectMethodWeaver : AbstractAspectMethodWeaver
    {
        protected AspectMethodWeaver(MethodInfo method, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(method, aspectDefinitions, aspectWeavingSettings) {
            methodSignatureWeaver = new MethodSignatureWeaver(aspectWeavingSettings.WeavingSettings.TypeDefinition);
        }
    }
}
