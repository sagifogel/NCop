using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Engine
{
    public interface IAspectMethodMap : IAspectMembers<MethodInfo>, IMemberMap<MethodInfo>
    {
        MethodInfo AspectMethod { get; }
    }
}
