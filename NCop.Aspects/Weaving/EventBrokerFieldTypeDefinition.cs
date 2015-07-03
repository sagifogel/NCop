using NCop.Weaving;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    public class EventBrokerFieldTypeDefinition : AbstractFieldBuilderDefinition
    {
        public EventBrokerFieldTypeDefinition(EventInfo @event, Type eventBrokerContractType, TypeBuilder typeBuilder, Type eventBrokerImplementationType, Type eventInterceptionArgs)
            : base(eventBrokerContractType, typeBuilder, @event.Name) {
            Name = @event.Name;
            EventType = @event.EventHandlerType;
            EventInterceptionArgs = eventInterceptionArgs;
            EventBrokerType = eventBrokerImplementationType;
        }

        public string Name { get; private set; }

        public Type EventType { get; private set; }

        public Type EventBrokerType { get; private set; }

        public string InvokeMethodName { get; private set; }

        public Type EventInterceptionArgs { get; private set; }
    }
}
