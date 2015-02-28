using System;
using System.Reflection;

namespace NCop.Core
{
    public class MethodMap : MemberMap<MethodInfo>, IMethodMap
    {
        public MethodMap(Type contractType, Type implementationType, MethodInfo contractMethod, MethodInfo implementationMethod)
            : base(contractType, implementationType, contractMethod, implementationMethod) {
        }
    }
}
