using NCop.Core;
using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class AspectEventMap : AbstractMemberMap<EventInfo>, IAspectEventMap
    {
        public AspectEventMap(Type contractType, Type implementationType, EventInfo contractEvent, EventInfo implementationEvent, EventInfo aspectEvent)
            : base(contractType, implementationType, contractEvent, implementationEvent) {
            AspectEvent = aspectEvent;
            AddIfNotNull(() => aspectEvent);
        }

        public EventInfo AspectEvent { get; private set; }
    }
}

