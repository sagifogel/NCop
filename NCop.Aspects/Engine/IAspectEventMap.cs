using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IAspectEventMap : IAspectEvent
    {
        EventInfo AspectEvent { get; }
        MethodInfo AspectAddEvent { get; }
        MethodInfo AspectRaiseEvent { get; }
        MethodInfo AspectRemoveEvent { get; }
    }
}
