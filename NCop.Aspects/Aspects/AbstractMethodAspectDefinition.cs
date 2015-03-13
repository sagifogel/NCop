using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal abstract class AbstractMethodAspectDefinition : AbstractAspectDefinition, IMethodAspectDefinition
    {
        internal AbstractMethodAspectDefinition(IAspect aspect, Type aspectDeclaringType, MethodInfo method)
            : base(aspectDeclaringType) {
            Aspect = aspect;
            Method = method;
        }
    }
}
