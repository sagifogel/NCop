using NCop.Core;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IAspectEvent : IAspectMembers<EventInfo>, IMemberMap<EventInfo>
    {
    }
}
