using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    public class EventBrokerResolvedType
    {
        public EventBrokerResolvedType(EventInfo @event) {
            Event = @event;
            EventBrokerInvokeDelegateName = "Invoke{0}".Fmt(@event.Name);
        }

        public Type[] Arguments { get; set; }

        public Type DecalringType { get; set; }

        public EventInfo Event { get; private set; }

        public Type EventBrokerFieldType { get; set; }

        public Type EventInterceptionArgs { get; set; }

        public Type EventBrokerBaseClassType { get; set; }

        public Type EventBrokerInvokeDelegateType { get; set; }

        public string EventBrokerInvokeDelegateName { get; private set; }
    }
}
