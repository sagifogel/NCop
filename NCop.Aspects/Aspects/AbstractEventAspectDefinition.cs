using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    public abstract class AbstractEventAspectDefinition : AbstractAspectDefinition<EventInfo>, IEventAspectDefinition
    {
        protected AbstractEventAspectDefinition(IAspect aspect, Type aspectDeclaringType, EventInfo @event, MemberInfo target)
            : base(aspectDeclaringType, target) {
            Aspect = aspect;
            Member = @event;
        }
    }
}
