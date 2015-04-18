using NCop.Aspects.Engine;
using NCop.Core;
using System.Reflection;

namespace NCop.Composite.Engine
{
    public interface ICompositeEventMap : IAspectMembers<EventInfo>, IMemberMap<EventInfo>, IHasAspectDefinitions
    {
    }
}
