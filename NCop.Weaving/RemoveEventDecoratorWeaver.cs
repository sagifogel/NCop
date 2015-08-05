using System.Reflection;

namespace NCop.Weaving
{
    public class RemoveEventDecoratorWeaver : AbstractMethodWeaver
    {
        public RemoveEventDecoratorWeaver(IEventTypeBuilder eventTypeBuilder, EventInfo @event, IWeavingSettings weavingSettings)
            : base(@event.GetRemoveMethod(), weavingSettings) {
            MethodEndWeaver = new MethodEndWeaver();
            MethodScopeWeaver = new RemoveEventDecoratorScopeWeaver(method, weavingSettings);
            MethodDefintionWeaver = new RemoveEventMethodSignatureWeaver(eventTypeBuilder, weavingSettings.TypeDefinition);
        }
    }
}
