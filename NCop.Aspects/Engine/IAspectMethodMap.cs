using NCop.Core;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IAspectMethodMap : IAspectMembers<MethodInfo>, IMemberMap<MethodInfo>
    {
        MethodInfo AspectMethod { get; }
    }
}
