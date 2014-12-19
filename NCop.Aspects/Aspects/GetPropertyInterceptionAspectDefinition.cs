using System;
using System.Reflection;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;

namespace NCop.Aspects.Aspects
{
    internal class GetPropertyInterceptionAspectDefinition : AbstractPropertyAspectDefinition
    {
        private readonly GetPropertyInterceptionAspectAttribute aspect = null;

        public GetPropertyInterceptionAspectDefinition(GetPropertyInterceptionAspectAttribute aspect, Type aspectDeclaringType, MethodInfo member, PropertyInfo property)
            : base(aspect, aspectDeclaringType, member, property) {
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
                     TryBulidAdvice<OnGetPropertyAdviceAttribute>(method, (advice, mi) => {
                         return new OnGetPropertyAdviceDefinition(advice, mi);
                     });
                 });
        }

        public override IAspectExpressionBuilder Accept(IAspectDefinitionVisitor visitor) {
            return visitor.Visit(aspect).Invoke(this);
        }
    }
}
