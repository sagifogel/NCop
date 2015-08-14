using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal class EventInterceptionAspectDefinition : IEventAspectDefinition
    {
        internal EventInterceptionAspectDefinition(IAspect aspect, Type aspectDeclaringType, EventInfo @event, MemberInfo target) {
            Aspect = aspect;
            Member = @event;
            Target = target;
            AspectDeclaringType = aspectDeclaringType;
        }

        public AspectType AspectType {
            get {
                return AspectType.EventInterceptionAspect;
            }
        }
        public IAspect Aspect { get; private set; }

        public EventInfo Member { get; private set; }

        public MemberInfo Target { get; private set; }

        public Type AspectDeclaringType { get; private set; }

        public IAdviceDefinitionCollection Advices { get; private set; }

        public IAspectExpressionBuilder Accept(IAspectDefinitionVisitor visitor) {
            throw new NotSupportedException();
        }

        public IAspectDefinition BuildAdvices() {
            throw new NotSupportedException();
        }
    }
}
