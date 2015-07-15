using NCop.Core.Extensions;
using NCop.Weaving;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    public class EventBrokerFieldTypeDefinition : AbstractFieldBuilderDefinition
    {
        public EventBrokerFieldTypeDefinition(EventInfo @event, EventBrokerResolvedType eventBrokerResolvedType, TypeBuilder typeBuilder, Type eventBrokerGeneratedType)
            : base(eventBrokerResolvedType.EventBrokerFieldType, typeBuilder, @event.Name) {
            Name = @event.Name;
            EventType = @event.EventHandlerType;
            EventBrokerType = eventBrokerGeneratedType;
            InvokeMethodName = "Invoke{0}".Fmt(@event.Name);
            EventInterceptionArgs = eventBrokerResolvedType.EventInterceptionArgs;
            EventInterceptionContractArgs = eventBrokerResolvedType.EventInterceptionContractArgs;
        }

        public string Name { get; private set; }

        public Type EventType { get; private set; }

        public Type EventBrokerType { get; private set; }

        public string InvokeMethodName { get; private set; }

        public Type EventInterceptionArgs { get; private set; }

        public Type EventInterceptionContractArgs { get; private set; }
    }
}
