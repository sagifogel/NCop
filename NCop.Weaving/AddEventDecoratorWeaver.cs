using System.Reflection;

namespace NCop.Weaving
{
    public class AddEventDecoratorWeaver : AbstractMethodWeaver
    {
        public AddEventDecoratorWeaver(IEventTypeBuilder eventTypeBuilder, EventInfo @event, IWeavingSettings weavingSettings)
            : base(@event.GetAddMethod(), weavingSettings) {
            MethodEndWeaver = new MethodEndWeaver();
            MethodScopeWeaver = new AddEventDecoratorScopeWeaver(method, weavingSettings);
            MethodDefintionWeaver = new AddEventMethodSignatureWeaver(eventTypeBuilder, weavingSettings.TypeDefinition);
        }
    }
}
