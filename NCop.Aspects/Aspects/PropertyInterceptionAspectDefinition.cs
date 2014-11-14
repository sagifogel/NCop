using System;
using System.Linq;
using System.Reflection;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;

namespace NCop.Aspects.Aspects
{
    internal class PropertyInterceptionAspectDefinition : AbstractAspectDefinition<PropertyInfo>
    {
        private readonly PropertyInterceptionAspectAttribute aspect = null;

        internal PropertyInterceptionAspectDefinition(PropertyInterceptionAspectAttribute aspect, Type aspectDeclaringType, MemberInfo member)
            : base(aspect, aspectDeclaringType, member) {
            this.aspect = aspect;
        }

        public override AspectType AspectType {
            get {
                return AspectType.PropertyInterceptionAspect;
            }
        }

        public override void BulidAdvices() {
            Aspect.AspectType
                 .GetOverridenMethods()
                 .ForEach(method => {
                     if (method.IsDefined<OnGetPropertyInvokeAdviceAttribute>()) {
                         var getPropertyAspectAttribute = new GetPropertyInterceptionAspectAttribute(Aspect.AspectType);
                         var getPropertyAspectDefinition = new GetPropertyInterceptionAspectDefinition(getPropertyAspectAttribute, AspectDeclaringType, method);

                         advices.AddRange(getPropertyAspectDefinition.Advices);
                     }
                     else if (method.IsDefined<OnSetPropertyInvokeAdviceAttribute>()) {
                         var setPropertyAspectAttribute = new SetPropertyInterceptionAspectAttribute(Aspect.AspectType);
                         var setPropertyAspectDefinition = new SetPropertyInterceptionAspectDefinition(setPropertyAspectAttribute, AspectDeclaringType, method);

                         advices.AddRange(setPropertyAspectDefinition.Advices);
                     }
                 });
        }

        public override IAspectExpressionBuilder Accept(IAspectDefinitionVisitor visitor) {
            return visitor.Visit(aspect).Invoke(this);
        }
    }
}
