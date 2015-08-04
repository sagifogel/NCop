using System.Reflection;

namespace NCop.Weaving
{
    public class RemoveEventDecoratorScopeWeaver : AbstractAddRemoveEventMethodScopeWeaver
    {
        public RemoveEventDecoratorScopeWeaver(EventInfo @event, MethodInfo method, IWeavingSettings weavingSettings)
            : base(@event, method, weavingSettings) {
        }

        public override string Action {
            get {
                return "Remove";
            }
        }
    }
}
