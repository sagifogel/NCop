using System;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    public class EventBrokerResolvedType
    {
        public EventBrokerResolvedType(EventInfo @event) {
            Event = @event;
        }

        public Type[] Arguments { get; set; }

        public Type DecalringType { get; set; }

        public EventInfo Event { get; private set; }

        public string OnInvokeUniqueName { get; set; }

        public Type EventBrokerFieldType { get; set; }

        public Type EventInterceptionArgs { get; set; }

        public Type EventBrokerBindingType { get; set; }

        public Type EventBrokerBaseClassType { get; set; }

    }
}
