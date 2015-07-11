using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class BindingRemoveEventAspectDecoratorWeaver : AbstractAddRemoveEventAspectDecoratorWeaver
    {
        internal BindingRemoveEventAspectDecoratorWeaver(EventInfo @event, IAspectWeavingSettings aspectWeavingSettings)
            : base(@event, aspectWeavingSettings) {
        }

        protected override string Action {
            get {
                return "RemoveHandler";
            }
        }
    }
}
