using NCop.Core;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IAspectEventMap : IAspectMembers<EventInfo>, IMemberMap<EventInfo>
    {
        EventInfo AspectEvent { get; }
    }
}
