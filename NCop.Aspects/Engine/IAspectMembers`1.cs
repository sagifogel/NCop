using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Core;

namespace NCop.Aspects.Engine
{
    public interface IAspectMembers<out TMember> where TMember : MemberInfo
    {
        TMember Target { get; }
        IEnumerable<TMember> Members { get; }
    }
}
