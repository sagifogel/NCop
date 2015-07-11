using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class BindingAddEventAspectDecoratorWeaver : AbstractAddRemoveEventAspectDecoratorWeaver
    {
        internal BindingAddEventAspectDecoratorWeaver(EventInfo @event, IAspectWeavingSettings aspectWeavingSettings)
            : base(@event, aspectWeavingSettings) {
        }

        protected override string Action {
            get {
                return "AddHandler";
            }
        }
    }
}
