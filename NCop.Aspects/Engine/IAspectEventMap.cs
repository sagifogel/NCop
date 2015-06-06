using NCop.Core;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IAspectEventMap : IAspectEvent
    {
        EventInfo AspectEvent { get; }
    }
}
