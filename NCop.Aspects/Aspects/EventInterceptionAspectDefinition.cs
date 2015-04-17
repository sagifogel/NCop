using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal class EventInterceptionAspectDefinition : AbstractEventAspectDefinition
    {
        private readonly EventInterceptionAspectAttribute aspect = null;

        internal EventInterceptionAspectDefinition(EventInterceptionAspectAttribute aspect, Type aspectDeclaringType, EventInfo @event)
            : base(aspect, aspectDeclaringType, @event) {
        }

        public override AspectType AspectType {
            get {
                return AspectType.EventInterceptionAspect;
            }
        }

        public override IAspectExpressionBuilder Accept(IAspectDefinitionVisitor visitor) {
            return visitor.Visit(aspect).Invoke(this);
        }

        public override IAspectDefinition BuildAdvices() {
            Aspect.AspectType
                .GetOverridenMethods()
                .ForEach(method => {
                    TryBulidAdvice<OnAddHandlerAdviceAttribute>(method, (advice, mi) => {
                        return new OnAddHandlerAdviceDefinition(advice, mi);
                    });

                    TryBulidAdvice<OnRemoveHandlerAdviceAttribute>(method, (advice, mi) => {
                        return new OnRemoveHandlerAdviceDefinition(advice, mi);
                    });

                    TryBulidAdvice<OnInvokeHandlerAdviceAttribute>(method, (advice, mi) => {
                        return new OnInvokeHandlerAdviceDefinition(advice, mi);
                    });
                });

            return this;
        }
    }
}
