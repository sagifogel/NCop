using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving;
using NCop.Weaving;
using System.Reflection;

namespace NCop.Composite.Weaving
{
    internal class CompositeAddEventWeaver : AspectEventWeaver
    {
        internal CompositeAddEventWeaver(IEventTypeBuilder eventTypeBuilder, MethodInfo method, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(eventTypeBuilder, method, aspectDefinitions, aspectWeavingSettings) {
            methodSignatureWeaver = new AddEventMethodSignatureWeaver(eventTypeBuilder, aspectWeavingSettings.WeavingSettings.TypeDefinition);
        }
    }
}