using NCop.Aspects.Weaving.Expressions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal abstract class AbstractPropertyAspectDefinition : AbstractMethodAspectDefinition, IPropertyAspectDefinition
    {
        internal AbstractPropertyAspectDefinition(IAspect aspect, Type aspectDeclaringType, MethodInfo method, PropertyInfo property)
            : base(aspect, aspectDeclaringType, method) {
            Property = property;
        }

        public PropertyInfo Property { get; protected set; }

    }
}
