using NCop.Core;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IAspectPropertyMap : IAspectMembers<PropertyInfo>, IMemberMap<PropertyInfo>
    {
        bool IsPartial { get; }
        MethodInfo AspectGetProperty { get; }
        MethodInfo AspectSetProperty { get; }
    }
}
