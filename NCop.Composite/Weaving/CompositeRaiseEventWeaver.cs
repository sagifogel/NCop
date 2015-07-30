using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving;
using System.Reflection;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    internal class CompositeRaiseEventWeaver : AspectEventWeaver
    {
        internal CompositeRaiseEventWeaver(IEventTypeBuilder eventTypeBuilder, EventInfo @event, MethodInfo method, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(eventTypeBuilder, method, aspectDefinitions, aspectWeavingSettings) {
            var typeBuilder = (IAspectTypeDefinition)aspectWeavingSettings.WeavingSettings.TypeDefinition;
            var eventFieldBuilder = typeBuilder.GetEventBrokerFielTypeDefinition(@event);

            methodSignatureWeaver = new RaiseEventMethodSignatureWeaver(eventTypeBuilder, typeBuilder, eventFieldBuilder);
        }
    }
}
