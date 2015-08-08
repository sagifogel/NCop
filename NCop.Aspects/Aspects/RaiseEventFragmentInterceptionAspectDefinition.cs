using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    public class RaiseEventFragmentInterceptionAspectDefinition : AbstractEventFragmentInterceptionAspectDefinition
    {
        private readonly RaiseEventFragmentInterceptionAspect aspect = null;

        internal RaiseEventFragmentInterceptionAspectDefinition(IEventExpressionBuilder eventBuilder, RaiseEventFragmentInterceptionAspect aspect, Type aspectDeclaringType, EventInfo @event)
            : base(eventBuilder, aspect, aspectDeclaringType, @event) {
            Aspect = this.aspect = aspect;
        }

        public override AspectType AspectType {
            get {
                return AspectType.RaiseEventInterceptionAspect;
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
