using System.Reflection;

namespace NCop.Weaving
{
    public class AddEventDecoratorScopeWeaver : AbstractAddRemoveEventMethodScopeWeaver
    {
        public AddEventDecoratorScopeWeaver(EventInfo @event, MethodInfo method, IWeavingSettings weavingSettings)
            : base(@event, method, weavingSettings) {
        }

        public override string Action {
            get {
                return "Combine";
            }
        }
    }
}

