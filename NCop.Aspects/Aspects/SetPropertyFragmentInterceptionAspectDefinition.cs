using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal class SetPropertyFragmentInterceptionAspectDefinition : AbstractPropertyAspectDefinition
    {
        private readonly SetPropertyFragmentInterceptionAspect aspect = null;

        internal SetPropertyFragmentInterceptionAspectDefinition(IPropertyExpressionBuilder propertyBuilder, SetPropertyFragmentInterceptionAspect aspect, Type aspectDeclaringType, MethodInfo method, PropertyInfo property)
            : base(propertyBuilder, aspectDeclaringType, property) {
            Aspect = this.aspect = aspect;
        }

        public override AspectType AspectType {
            get {
                return AspectType.SetPropertyFragmentInterceptionAspect;
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