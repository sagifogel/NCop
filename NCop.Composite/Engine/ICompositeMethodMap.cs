using NCop.Aspects.Engine;
using NCop.Core;
using System.Reflection;

namespace NCop.Composite.Engine
{
    public interface ICompositeMethodMap : IAspectMembers<MethodInfo>, IMemberMap<MethodInfo>, IHasAspectDefinitions
    {
    }
}
