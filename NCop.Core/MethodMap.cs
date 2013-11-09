using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Core
{
    public class MethodMap : MemberMap<MethodInfo>, IMethodMap
    {
        public MethodMap(Type contractType, Type implementationType, MethodInfo contractMethod, MethodInfo implementationMethod)
            : base(contractType, implementationType, contractMethod, implementationMethod) {
        }
    }
}
