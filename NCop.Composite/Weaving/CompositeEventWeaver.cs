using NCop.Weaving;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Composite.Weaving
{
    internal class CompositeEventWeaver : IEventWeaver, ICompositeEventTypeBuilder
    {
        private IMethodWeaver addMethod = null;
        private IMethodWeaver removeMethod = null;
        private IMethodWeaver invokeMethod = null;
        private readonly EventBuilder eventBuilder = null;

        public CompositeEventWeaver(ITypeDefinition typeDefinition, EventInfo @event) {
            EventName = @event.Name;
            EventType = @event.EventHandlerType;
            eventBuilder = typeDefinition.TypeBuilder.DefineEvent(@event);
        }

        public Type EventType { get; private set; }

        public string EventName { get; private set; }

        public IMethodWeaver GetAddMethod() {
            return addMethod;
        }

        public IMethodWeaver GetRemoveMethod() {
            return removeMethod;
        }

        public IMethodWeaver GetInvokeMethod() {
            return invokeMethod;
        }

        public void SetAddMethod(IMethodWeaver addMethod) {
            this.addMethod = addMethod;
        }

        public void SetRemoveMethod(IMethodWeaver removeMethod) {
            this.removeMethod = removeMethod;
        }

        public void SetInvokeMethod(IMethodWeaver invokeMethod) {
            this.invokeMethod = invokeMethod;
        }
    }
}
