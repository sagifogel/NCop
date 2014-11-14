using System;
using System.Reflection;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;

namespace NCop.Aspects.Aspects
{
    internal class GetPropertyInterceptionAspectDefinition : AbstractAspectDefinition<MethodInfo>
    {
        private readonly GetPropertyInterceptionAspectAttribute aspect = null;

        public GetPropertyInterceptionAspectDefinition(GetPropertyInterceptionAspectAttribute aspect, Type aspectDeclaringType, MethodInfo member)
            : base(aspect, aspectDeclaringType, member) {
            this.aspect = aspect;
        }

        public override AspectType AspectType {
            get {
                return AspectType.GetPropertyInterceptionAspect;
            }
        }

        public override void BulidAdvices() {
            Aspect.AspectType
                 .GetOverridenMethods()
                 .ForEach(method => {
                     TryBulidAdvice<OnGetPropertyInvokeAdviceAttribute>(method, (advice, mi) => {
                         return new OnGetPropertyInvokeAdviceDefinition(advice, mi);
                     });
                 });
        }

        public override IAspectExpressionBuilder Accept(IAspectDefinitionVisitor visitor) {
            return visitor.Visit(aspect).Invoke(this);
        }
    }
}
