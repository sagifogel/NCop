using NCop.Weaving;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Composite.Weaving
{
    internal class CompositeEventWeaver : IEventWeaver, IEventTypeBuilder
    {
        private IMethodWeaver addMethodWeaver = null;
        private IMethodWeaver removeMethodWeaver = null;
        private IMethodWeaver raiseMethodWeaver = null;
        private readonly Core.Lib.Lazy<EventBuilder> lazyEventBuilder = null;

        public CompositeEventWeaver(ITypeDefinition typeDefinition, EventInfo @event) {
            EventName = @event.Name;
            EventType = @event.EventHandlerType;
            lazyEventBuilder = new Core.Lib.Lazy<EventBuilder>(() => {
                return typeDefinition.TypeBuilder.DefineEvent(@event);
            });
        }

        public Type EventType { get; private set; }

        public string EventName { get; private set; }

        public IMethodWeaver GetAddMethod() {
            return addMethodWeaver;
        }

        public IMethodWeaver GetRaiseMethod() {
            return raiseMethodWeaver;
        }

        public IMethodWeaver GetRemoveMethod() {
            return removeMethodWeaver;
        }

        public void SetAddMethodWeaver(IMethodWeaver addMethodWeaver) {
            this.addMethodWeaver = addMethodWeaver;
        }

        public void SetRemoveMethodWeaver(IMethodWeaver removeMethodWeaver) {
            this.removeMethodWeaver = removeMethodWeaver;
        }


        public void SetRaiseMethodWeaver(IMethodWeaver raiseMethodWeaver) {
            this.raiseMethodWeaver = raiseMethodWeaver;
        }

        public void SetAddMethod(MethodBuilder addMethod) {
            lazyEventBuilder.Value.SetAddOnMethod(addMethod);
        }

        public void SetRemoveMethod(MethodBuilder removeMethod) {
            lazyEventBuilder.Value.SetRemoveOnMethod(removeMethod);
        }
    }
}
