using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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

        protected override void BulidAdvices() {
            Aspect.AspectType
                 .GetOverridenProperties()
                 .ForEach(property => {
                     var propertyInvokeAttribute = property.GetCustomAttribute<OnPropertyInvokeAdviceAttribute>(true);

                     if (propertyInvokeAttribute.IsNotNull()) {
                         if (property.GetMethod.IsNotNull()) {
                             TryBulidAdvice<OnMethodInvokeAdviceAttribute>(property, (advice, mi) => {
                                 return new OnMethodInvokeAdviceDefinition(advice, mi.GetMethod);
                             });
                         }

                         if (property.SetMethod.IsNotNull()) {
                             TryBulidAdvice<OnMethodInvokeAdviceAttribute>(property, (advice, mi) => {
                                 return new OnSetPropertyInvokeAdviceDefinition(advice, mi.SetMethod);
                             });
                         }
                     }
                 });
        }

        public override IAspectExpressionBuilder Accept(IAspectDefinitionVisitor visitor) {
            return visitor.Visit(aspect).Invoke(this);
        }
    }
}
