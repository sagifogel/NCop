using NCop.Aspects.Weaving.Expressions;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal abstract class AbstractPropertyAspectDefinition : AbstractAspectDefinition, IPropertyAspectDefinition
    {
        internal AbstractPropertyAspectDefinition(IAspect aspect, Type aspectDeclaringType, MethodInfo method, PropertyInfo property)
            : base(aspectDeclaringType) {
            Aspect = aspect;
            Method = method;
            Property = property;
        }

        public PropertyInfo Property { get; protected set; }

    }
}
