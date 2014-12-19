using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal abstract class AbstractMethodAspectDefinition : AbstractAspectDefinition
    {
        internal AbstractMethodAspectDefinition(IAspect aspect, Type aspectDeclaringType, MethodInfo method)
            : base(aspect, aspectDeclaringType, method) {
        }
    }
}
