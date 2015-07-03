using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal class InvokeEventFragmentInterceptionAspectDefinition : AbstractEventFragmentInterceptionAspectDefinition
    {
        private readonly InvokeEventFragmentInterceptionAspect aspect = null;

        internal InvokeEventFragmentInterceptionAspectDefinition(IEventExpressionBuilder eventBuilder, InvokeEventFragmentInterceptionAspect aspect, Type aspectDeclaringType, EventInfo @event)
            : base(eventBuilder, aspect, aspectDeclaringType, @event) {
            Aspect = this.aspect = aspect;
        }

        public override AspectType AspectType {
            get {
                return AspectType.InvokeEventInterceptionAspect;
            }
        }

        public override IAspectDefinition BuildAdvices() {
            Aspect.AspectType
                  .GetOverridenMethods()
                  .ForEach(method => {
                      TryBulidAdvice<MethodInfo, OnInvokeEventHandlerAdviceAttribute>(method, (advice, mi) => {
                          return new OnInvokeEventHandlerAdviceDefinition(advice, method);
                      });
                  });

            return this;
        }

        public override IAspectExpressionBuilder Accept(IAspectDefinitionVisitor visitor) {
            return visitor.Visit(aspect).Invoke(this);
        }
    }
}
