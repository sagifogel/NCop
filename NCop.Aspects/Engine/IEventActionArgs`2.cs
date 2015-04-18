using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IEventActionArgs<TArg1, TArg2>
    {
        TArg1 Arg1 { get; set; }
        TArg2 Arg2 { get; set; }
        EventInfo Event { get; set; }
    }
}
