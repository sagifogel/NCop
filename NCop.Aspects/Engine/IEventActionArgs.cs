using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IEventActionArgs
    {
        EventInfo Event { get; set; }
    }
}
