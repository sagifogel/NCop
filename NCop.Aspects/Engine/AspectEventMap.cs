using NCop.Core;
using NCop.Core.Extensions;
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
            AspectAddEvent = aspectEvent.GetAddMethod();
            AspectRemoveEvent = aspectEvent.GetRemoveMethod();
            AspectRaiseEvent = aspectEvent.GetInvokeMethod();
        }

        public EventInfo AspectEvent { get; private set; }

        public MethodInfo AspectAddEvent { get; private set; }

        public MethodInfo AspectRaiseEvent { get; private set; }

        public MethodInfo AspectRemoveEvent { get; private set; }
    }
}

