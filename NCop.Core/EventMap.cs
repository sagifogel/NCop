using System;
using System.Reflection;

namespace NCop.Core
{
    public class EventMap : MemberMap<EventInfo>, IEventMap
    {
        public EventMap(Type contractType, Type implementationType, EventInfo contractEvent, EventInfo implementationEvent)
            : base(contractType, implementationType, contractEvent, implementationEvent) {
        }
    }
}
