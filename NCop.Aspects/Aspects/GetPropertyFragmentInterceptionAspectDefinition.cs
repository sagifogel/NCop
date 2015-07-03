using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal class GetPropertyFragmentInterceptionAspectDefinition : AbstractPropertyFragmentInterceptionAspectDefinition
    {
        private readonly GetPropertyFragmentInterceptionAspect aspect = null;

        internal GetPropertyFragmentInterceptionAspectDefinition(IPropertyExpressionBuilder propertyBuilder, GetPropertyFragmentInterceptionAspect aspect, Type aspectDeclaringType, PropertyInfo property)
            : base(propertyBuilder, aspect, aspectDeclaringType, property) {
            Aspect = this.aspect = aspect;
        }

        public override AspectType AspectType {
            get {
                return AspectType.GetPropertyFragmentInterceptionAspect;
            }
        }

        public override IAspectDefinition BuildAdvices() {
            Aspect.AspectType
                  .GetOverridenMethods()
                  .ForEach(method => {
                      TryBulidAdvice<MethodInfo, OnGetPropertyAdviceAttribute>(method, (advice, mi) => {
                          return new OnGetPropertyAdviceDefinition(advice, mi);
                      });
                  });

            return this;
        }

        public override IAspectExpressionBuilder Accept(IAspectDefinitionVisitor visitor) {
            return visitor.Visit(aspect).Invoke(this);
        }
    }
}
