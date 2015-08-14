using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal class OnMethodBoundaryAspectDefinition : AbstractMethodAspectDefinition
    {
        private readonly OnMethodBoundaryAspectAttribute aspect = null;

        internal OnMethodBoundaryAspectDefinition(OnMethodBoundaryAspectAttribute aspect, Type aspectDeclaringType, MethodInfo method, MemberInfo target)
            : base(aspect, aspectDeclaringType, method, target) {
            this.aspect = aspect;
        }

        public override AspectType AspectType {
            get {
                return AspectType.OnMethodBoundaryAspect;
            }
        }

        public override IAspectExpressionBuilder Accept(IAspectDefinitionVisitor visitor) {
            return visitor.Visit(aspect).Invoke(this);
        }

        public override IAspectDefinition BuildAdvices() {
            Aspect.AspectType
                  .GetOverridenMethods()
                  .ForEach(method => {
                      TryBulidAdvice<MethodInfo, OnMethodEntryAdviceAttribute>(method, (advice, mi) => {
                          return new OnMethodEntryAdviceDefinition(advice, mi);
                      });

                      TryBulidAdvice<MethodInfo, OnMethodSuccessAdviceAttribute>(method, (advice, mi) => {
                          return new OnMethodSuccessAdviceDefinition(advice, mi);
                      });

                      TryBulidAdvice<MethodInfo, OnMethodExceptionAdviceAttribute>(method, (advice, mi) => {
                          return new OnMethodExceptionAdviceDefinition(advice, mi);
                      });

                      TryBulidAdvice<MethodInfo, FinallyAdviceAttribute>(method, (advice, mi) => {
                          return new FinallyAdviceDefinition(advice, mi);
                      });
                  });

            return this;
        }
    }
}
