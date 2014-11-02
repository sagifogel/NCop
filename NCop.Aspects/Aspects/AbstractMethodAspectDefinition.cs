using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal abstract class AbstractMethodAspectDefinition : AbstractAspectDefinition<MethodInfo>
    {
        internal AbstractMethodAspectDefinition(IAspect aspect, Type aspectDeclaringType, MemberInfo member)
            : base(aspect, aspectDeclaringType, member) {
        }
    }
}
