using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class AspectMethodMap : AbstractMemberMap<MethodInfo>, IAspectMethodMap
    {
        public AspectMethodMap(Type contractType, Type implementationType, MethodInfo contractMethod, MethodInfo implementationMethod, MethodInfo aspectMethod)
            : base(contractType, implementationType, contractMethod, implementationMethod) {
            AspectMethod = aspectMethod;
            AddIfNotNull(() => aspectMethod);
        }

        public MethodInfo AspectMethod { get; private set; }
    }
}

