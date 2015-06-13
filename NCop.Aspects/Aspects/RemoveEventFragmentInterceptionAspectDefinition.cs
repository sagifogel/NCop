using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal class RemoveEventFragmentInterceptionAspectDefinition : AbstractEventFragmentInterceptionAspectDefinition
    {
        private readonly RemoveEventFragmentInterceptionAspect aspect = null;

        internal RemoveEventFragmentInterceptionAspectDefinition(IEventExpressionBuilder eventBuilder, RemoveEventFragmentInterceptionAspect aspect, Type aspectDeclaringType, EventInfo @event)
            : base(eventBuilder, aspect, aspectDeclaringType, @event) {
            Aspect = this.aspect = aspect;
        }

        public override AspectType AspectType {
            get {
                return AspectType.RemoveEventInterceptionAspect;
            }
        }

        public override IAspectDefinition BuildAdvices() {
            Aspect.AspectType
                  .GetOverridenMethods()
                  .ForEach(method => {
                      TryBulidAdvice<OnRemoveHandlerAdviceAttribute>(method, (advice, mi) => {
                          return new OnRemoveHandlerAdviceDefinition(advice, mi);
                      });
                  });

            return this;
        }

        public override IAspectExpressionBuilder Accept(IAspectDefinitionVisitor visitor) {
            return visitor.Visit(aspect).Invoke(this);
        }
    }
}
