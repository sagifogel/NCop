using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IEventActionArgs<TArg1, TArg2, TArg3, TArg4>
    {
        TArg1 Arg1 { get; set; }
        TArg2 Arg2 { get; set; }
        TArg3 Arg3 { get; set; }
        TArg4 Arg4 { get; set; }
        EventInfo Event { get; set; }
        Action<TArg1, TArg2, TArg3, TArg4> Handler { get; set; }
        IEventBroker<Action<TArg1, TArg2, TArg3, TArg4>> EventBroker { get; }
    }
}
