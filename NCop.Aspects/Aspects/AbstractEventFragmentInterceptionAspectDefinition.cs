using NCop.Aspects.Weaving.Expressions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    public abstract class AbstractEventFragmentInterceptionAspectDefinition : AbstractEventAspectDefinition, IFullEventAspectDefinition
    {
        internal AbstractEventFragmentInterceptionAspectDefinition(IEventExpressionBuilder eventBuilder, IAspect aspect, Type aspectDeclaringType, EventInfo @event, MemberInfo target)
            : base(aspect, aspectDeclaringType, @event, target) {
            EventBuilder = eventBuilder;
        }

        public IEventExpressionBuilder EventBuilder { get; private set; }
    }
}

