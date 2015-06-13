
using NCop.Aspects.Weaving.Expressions;
using System;
using System.Reflection;
namespace NCop.Aspects.Aspects
{
    internal abstract class AbstractEventFragmentInterceptionAspectDefinition : AbstractEventAspectDefinition, IFullEventAspectDefinition
    {
        internal AbstractEventFragmentInterceptionAspectDefinition(IEventExpressionBuilder eventBuilder, IAspect aspect, Type aspectDeclaringType, EventInfo @event)
            : base(aspect, aspectDeclaringType, @event) {
            EventBuilder = eventBuilder;
        }

        public IEventExpressionBuilder EventBuilder { get; private set; }
    }
}

