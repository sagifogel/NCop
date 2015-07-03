using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal class AddEventFragmentInterceptionAspectDefinition : AbstractEventFragmentInterceptionAspectDefinition
    {
        private readonly AddEventFragmentInterceptionAspect aspect = null;

        internal AddEventFragmentInterceptionAspectDefinition(IEventExpressionBuilder eventBuilder, AddEventFragmentInterceptionAspect aspect, Type aspectDeclaringType, EventInfo @event)
            : base(eventBuilder, aspect, aspectDeclaringType, @event) {
            Aspect = this.aspect = aspect;
        }

        public override AspectType AspectType {
            get {
                return AspectType.AddEventInterceptionAspect;
            }
        }

        public override IAspectDefinition BuildAdvices() {
            Aspect.AspectType
                  .GetOverridenMethods()
                  .ForEach(method => {
                      TryBulidAdvice<MethodInfo, OnAddEventHandlerAdviceAttribute>(method, (advice, mi) => {
                          return new OnAddHandlerAdviceDefinition(advice, method);
                      });
                  });

            return this;
        }

        public override IAspectExpressionBuilder Accept(IAspectDefinitionVisitor visitor) {
            return visitor.Visit(aspect).Invoke(this);
        }
    }
}
