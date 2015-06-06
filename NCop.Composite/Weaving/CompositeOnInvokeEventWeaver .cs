using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving;
using NCop.Weaving;
using System.Reflection;

namespace NCop.Composite.Weaving
{
    internal class CompositeOnInvokeEventWeaver : OnInvokeMethodWeaver
    {
        internal CompositeOnInvokeEventWeaver(EventInfo @event, IAspectTypeDefinition typeDefinition, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(@event, typeDefinition, aspectDefinitions, aspectWeavingSettings) {
        }
    }
}
