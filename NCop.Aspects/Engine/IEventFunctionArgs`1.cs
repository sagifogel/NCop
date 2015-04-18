using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IEventFunctionArgs<TArg1, TResult>
    {
        TArg1 Arg1 { get; set; }
        EventInfo Event { get; set; }
        TResult ReturnValue { get; set; }
    }
}
