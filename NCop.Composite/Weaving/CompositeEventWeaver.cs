using System;
using NCop.Weaving;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Composite.Weaving
{
    internal class CompositeEventWeaver : ICompositeEventWeaver, ICompositeEventTypeBuilder
    {
        private IMethodWeaver onAddMethod = null;
        private IMethodWeaver onRemoveMethod = null;
        private IMethodWeaver onInvokeMethod = null;
        private readonly EventBuilder eventBuilder = null;

        public CompositeEventWeaver(ITypeDefinition typeDefinition, EventInfo @event) {
            EventName = @event.Name;
            EventType = @event.EventHandlerType;
            eventBuilder = typeDefinition.TypeBuilder.DefineEvent(@event);
        }

        public Type EventType { get; private set; }
        
        public string EventName { get; private set; }

        public IMethodWeaver GetOnAddMethod() {
            return onAddMethod;
        }

        public IMethodWeaver GetOnRemoveMethod() {
            return onRemoveMethod;
        }

        public IMethodWeaver GetOnInvokeMethod() {
            return onInvokeMethod;
        }

        public void SetAddOnMethod(IMethodWeaver addOnMethod) {
            this.onAddMethod = addOnMethod;
        }

        public void SetRemoveOnMethod(IMethodWeaver onRemoveMethod) {
            this.onRemoveMethod = onRemoveMethod;
        }

        public void SetOnInvokeMethod(IMethodWeaver onInvokeMethod) {
            this.onInvokeMethod = onInvokeMethod;
        }
    }
}
