using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IEventActionArgs<TArg1>
    {
        TArg1 Arg1 { get; set; }
        EventInfo Event { get; set; }
    }
}
