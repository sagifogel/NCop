using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
    internal abstract class AbstractMethodAspectDefinition : AbstractAspectDefinition, IMethodAspectDefinition
    {
        internal AbstractMethodAspectDefinition(IAspect aspect, Type aspectDeclaringType, MethodInfo method)
            : base(aspect, aspectDeclaringType) {
            Method = method;
        }

        public MethodInfo Method { get; protected set; }
    }
}
