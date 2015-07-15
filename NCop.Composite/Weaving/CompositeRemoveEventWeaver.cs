using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving;
using System.Reflection;

namespace NCop.Composite.Weaving
{
    internal class CompositeRemoveEventWeaver : AspectEventWeaver
    {
        internal CompositeRemoveEventWeaver(MethodInfo method, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(method, aspectDefinitions, aspectWeavingSettings) {
        }
    }
}
