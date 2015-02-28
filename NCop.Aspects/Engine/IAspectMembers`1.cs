using System.Collections.Generic;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IAspectMembers<out TMember> where TMember : MemberInfo
    {
        TMember Target { get; }
        IEnumerable<TMember> Members { get; }
    }
}
