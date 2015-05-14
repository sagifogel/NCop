using NCop.Weaving;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    public class EventBrokerFieldTypeDefinition : AbstractFieldBuilderDefinition
    {
        public EventBrokerFieldTypeDefinition(EventInfo @event, Type eventBrokerType, TypeBuilder typeBuilder)
            : base(eventBrokerType, typeBuilder) {
            Name = @event.Name;
        }

        public string Name { get; private set; }
    }
}
