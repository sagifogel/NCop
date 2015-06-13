using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal class MethodInterceptionAspectDefinition : AbstractMethodAspectDefinition
    {
        private readonly MethodInterceptionAspectAttribute aspect = null;

        internal MethodInterceptionAspectDefinition(MethodInterceptionAspectAttribute aspect, Type aspectDeclaringType, MethodInfo method)
            : base(aspect, aspectDeclaringType, method) {
            this.aspect = aspect;
        }

        public override AspectType AspectType {
            get {
                return AspectType.MethodInterceptionAspect;
            }
        }

        public override IAspectDefinition BuildAdvices() {
            Aspect.AspectType
                  .GetOverridenMethods()
                  .ForEach(method => {
                      TryBulidAdvice<OnMethodInvokeAdviceAttribute>(method, (advice, mi) => {
                          return new OnMethodInvokeAdviceDefinition(advice, mi);
                      });
                  });

            return this;
        }

        public override IAspectExpressionBuilder Accept(IAspectDefinitionVisitor visitor) {
            return visitor.Visit(aspect).Invoke(this);
        }
    }
}
