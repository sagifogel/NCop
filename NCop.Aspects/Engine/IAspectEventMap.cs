using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IAspectEventMap : IAspectEvent
    {
        EventInfo AspectEvent { get; }
        MethodInfo AspectAddEvent { get; }
        MethodInfo AspectRemoveEvent { get; }
        MethodInfo AspectInvokeEvent { get; }
    }
}
