using NCop.Aspects.Weaving.Expressions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal abstract class AbstractPropertyFragmentInterceptionAspectDefinition : AbstractPropertyAspectDefinition, IFullPropertyAspectDefinition
    {
        internal AbstractPropertyFragmentInterceptionAspectDefinition(IPropertyExpressionBuilder propertyBuilder, IAspect aspect, Type aspectDeclaringType, PropertyInfo property)
            : base(aspect, aspectDeclaringType, property) {
            PropertyBuilder = propertyBuilder;
        }

        public IPropertyExpressionBuilder PropertyBuilder { get; private set; }
    }
}
