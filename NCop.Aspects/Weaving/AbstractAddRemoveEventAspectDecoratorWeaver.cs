using NCop.Aspects.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractAddRemoveEventAspectDecoratorWeaver : AbstractMethodScopeWeaver, IAspectWeaver
    {
        private readonly EventInfo @event = null;

        internal AbstractAddRemoveEventAspectDecoratorWeaver(EventInfo @event, IAspectWeavingSettings aspectWeavingSettings)
            : base(@event.GetAddMethod(), aspectWeavingSettings.WeavingSettings) {
            this.@event = @event;
        }

        public override void Weave(ILGenerator ilGenerator) {
            var aspectArgsType = @event.ToEventArgumentContract();
            var eventBrokerProperty = aspectArgsType.GetProperty("EventBroker");

            ilGenerator.EmitLoadArg(3);
            ilGenerator.Emit(OpCodes.Callvirt, eventBrokerProperty.GetGetMethod());
            ilGenerator.EmitLoadArg(2);
            ilGenerator.Emit(OpCodes.Callvirt, eventBrokerProperty.PropertyType.GetMethod(Action));
        }

        protected abstract string Action { get; }
    }
}
