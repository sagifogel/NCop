using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving;
using System.Reflection;
using NCop.Core.Extensions;

namespace NCop.Composite.Weaving
{
    internal class CompositeInvokeEventWeaver : AbstractAspectMethodWeaver
    {
        internal CompositeInvokeEventWeaver(EventInfo @event, MethodInfo method, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(method, aspectDefinitions, aspectWeavingSettings) {
            var typeBuilder = (IAspectTypeDefinition)aspectWeavingSettings.WeavingSettings.TypeDefinition;
            var eventFieldBuilder = typeBuilder.GetEventBrokerFielTypeDefinition(@event);

            methodSignatureWeaver = new InvokeEventMethodSignatureWeaver(typeBuilder, eventFieldBuilder);
        }
    }
}
