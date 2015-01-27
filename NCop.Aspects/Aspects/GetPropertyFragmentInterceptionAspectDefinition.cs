using System;
using System.Reflection;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving.Expressions;
using NCop.Core.Extensions;
using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving;

namespace NCop.Aspects.Engine
{
    internal class GetPropertyFragmentInterceptionAspectDefinition : AbstractPropertyAspectDefinition, IPropertyFragment
    {
        private readonly GetPropertyFragmentInterceptionAspect aspect = null;

        internal GetPropertyFragmentInterceptionAspectDefinition(IPropertyExpressionBuilder propertyBuilder, GetPropertyFragmentInterceptionAspect aspect, Type aspectDeclaringType, MethodInfo method, PropertyInfo property)
            : base(aspectDeclaringType, property) {
            Aspect = this.aspect = aspect;
            PropertyBuilder = PropertyBuilder;
        }
        
        public override AspectType AspectType {
            get {
                return AspectType.PropertyInterceptionAspect;
            }
        }
        
        public IPropertyExpressionBuilder PropertyBuilder { get; private set; }

        public override IAspectDefinition BuildAdvices() {
            Aspect.AspectType
                 .GetOverridenMethods()
                 .ForEach(method => {
                     TryBulidAdvice<OnGetPropertyAdviceAttribute>(method, (advice, mi) => {
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
