using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Engine
{
    public interface IAspectPropertyMap : IAspectMembers<PropertyInfo>, IMemberMap<PropertyInfo>
    {
        MethodInfo AspectGetProperty { get; }
        MethodInfo AspectSetProperty { get; }
    }
}
