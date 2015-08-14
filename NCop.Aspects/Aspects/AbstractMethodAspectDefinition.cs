using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal abstract class AbstractMethodAspectDefinition : AbstractAspectDefinition<MethodInfo>, IMethodAspectDefinition
    {
        internal AbstractMethodAspectDefinition(IAspect aspect, Type aspectDeclaringType, MethodInfo method, MemberInfo target)
            : base(aspectDeclaringType, target) {
            Aspect = aspect;
            Member = method;
        }
    }
}
