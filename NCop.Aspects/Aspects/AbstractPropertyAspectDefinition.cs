using NCop.Aspects.Weaving.Expressions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal abstract class AbstractPropertyAspectDefinition : AbstractAspectDefinition, IFullPropertyAspectDefinition
    {
        internal AbstractPropertyAspectDefinition(IPropertyExpressionBuilder propertyBuilder, Type aspectDeclaringType, PropertyInfo property)
            : base(aspectDeclaringType) {
            Property = property;
            PropertyBuilder = propertyBuilder;
        }

        public PropertyInfo Property { get; protected set; }

        public IPropertyExpressionBuilder PropertyBuilder { get; private set; }
    }
}
