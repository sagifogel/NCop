using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving;
using System.Reflection;

namespace NCop.Composite.Weaving
{
    internal class CompositeInvokeEventWeaver : AspectEventWeaver
    {
        internal CompositeInvokeEventWeaver(MethodInfo method, IAspectTypeDefinition typeDefinition, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(method, aspectDefinitions, aspectWeavingSettings) {
        }
    }
}
