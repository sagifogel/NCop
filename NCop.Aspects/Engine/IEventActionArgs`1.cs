using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IEventActionArgs<TArg1>
    {
        TArg1 Arg1 { get; set; }
        EventInfo Event { get; set; }
        Action<TArg1> Handler { get; set; }
        IEventBroker<Action<TArg1>> EventBroker { get; }
    }
}
