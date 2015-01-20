using System;
using System.Reflection;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;

namespace NCop.Aspects.Aspects
{
    internal class PropertyInterceptionAspectsDefinition : AbstractAspectDefinition, IPropertyAspectDefinition
    {
        private readonly PropertyInterceptionAspectAttribute aspect = null;

        public PropertyInterceptionAspectsDefinition(PropertyInterceptionAspectAttribute aspect, GetPropertyInterceptionAspectAttribute getAspect, SetPropertyInterceptionAspectAttribute setAspect, Type aspectDeclaringType, PropertyInfo property)
            : base(aspectDeclaringType) {
            Property = property;
            Aspect = this.aspect = aspect;
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

                     TryBulidAdvice<OnGetPropertyAdviceAttribute>(method, (advice, mi) => {
                         return new OnGetPropertyAdviceDefinition(advice, mi);
                     });
                 });

            return this;
        }

        public override IAspectExpressionBuilder Accept(IAspectDefinitionVisitor visitor) {
            return visitor.Visit(aspect).Invoke(this);
        }

        public PropertyInfo Property { get; protected set; }

    }
}
