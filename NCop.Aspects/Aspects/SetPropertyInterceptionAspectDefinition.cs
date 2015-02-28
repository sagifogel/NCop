using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal class SetPropertyInterceptionAspectDefinition : AbstractMethodAspectDefinition
    {
        private readonly SetPropertyInterceptionAspectAttribute aspect = null;

        internal SetPropertyInterceptionAspectDefinition(SetPropertyInterceptionAspectAttribute aspect, Type aspectDeclaringType, MethodInfo method, PropertyInfo property)
            : base(aspect, aspectDeclaringType, method) {
            this.aspect = aspect;
        }

        public override AspectType AspectType {
            get {
                return AspectType.SetPropertyInterceptionAspect;
            }
        }

        public override IAspectDefinition BuildAdvices() {
            Aspect.AspectType
                 .GetOverridenMethods()
                 .ForEach(method => {
                     TryBulidAdvice<OnSetPropertyAdviceAttribute>(method, (advice, mi) => {
                         return new OnSetPropertyAdviceDefinition(advice, mi);
                     });
                 });

            return this;
        }

        public override IAspectExpressionBuilder Accept(IAspectDefinitionVisitor visitor) {
            return visitor.Visit(aspect).Invoke(this);
        }
    }
}
