using System;
using System.Reflection;
using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Aspects
{
    internal abstract class AbstractPropertyFragmentInterceptionAspectDefinition : AbstractPropertyAspectDefinition, IFullPropertyAspectDefinition
    {
        internal AbstractPropertyFragmentInterceptionAspectDefinition(IPropertyExpressionBuilder propertyBuilder, IAspect aspect, Type aspectDeclaringType, MethodInfo method, PropertyInfo property)
            : base(aspect, aspectDeclaringType, method, property) {
            PropertyBuilder = propertyBuilder;
        }

        public IPropertyExpressionBuilder PropertyBuilder { get; private set; }
    }
}
