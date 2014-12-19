using System;
using System.Reflection;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;

namespace NCop.Aspects.Aspects
{
    internal class SetPropertyInterceptionAspectDefinition : AbstractPropertyAspectDefinition
    {
        private readonly SetPropertyInterceptionAspectAttribute aspect = null;

        public SetPropertyInterceptionAspectDefinition(SetPropertyInterceptionAspectAttribute aspect, Type aspectDeclaringType, MethodInfo member, PropertyInfo property)
            : base(aspect, aspectDeclaringType, member, property) {
            this.aspect = aspect;
        }

        public override AspectType AspectType {
            get {
                return AspectType.SetPropertyInterceptionAspect;
            }
        }

        public override void BulidAdvices() {
            Aspect.AspectType
                 .GetOverridenMethods()
                 .ForEach(method => {
                     TryBulidAdvice<OnSetPropertyAdviceAttribute>(method, (advice, mi) => {
                         return new OnSetPropertyAdviceDefinition(advice, mi);
                     });
                 });
        }

        public override IAspectExpressionBuilder Accept(IAspectDefinitionVisitor visitor) {
            return visitor.Visit(aspect).Invoke(this);
        }
    }
}
