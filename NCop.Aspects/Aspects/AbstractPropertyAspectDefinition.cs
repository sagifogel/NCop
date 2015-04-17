using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal abstract class AbstractPropertyAspectDefinition : AbstractAspectDefinition<PropertyInfo>, IPropertyAspectDefinition
    {
        internal AbstractPropertyAspectDefinition(IAspect aspect, Type aspectDeclaringType, PropertyInfo property)
            : base(aspectDeclaringType) {
            Aspect = aspect;
            Member = property;
        }
    }
}
