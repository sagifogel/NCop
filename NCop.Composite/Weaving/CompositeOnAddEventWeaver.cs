using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving;
using NCop.Weaving;
using System.Reflection;

namespace NCop.Composite.Weaving
{
    internal class CompositeOnAddEventWeaver : AspectEventWeaver
    {
        internal CompositeOnAddEventWeaver(MethodInfo method, ITypeDefinition typeDefinition, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(method, aspectDefinitions, aspectWeavingSettings) {
        }
    }
}
