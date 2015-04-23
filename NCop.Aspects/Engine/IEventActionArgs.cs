using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IEventActionArgs
    {
        Action Handler { get; set; }
        EventInfo Event { get; set; }
        IEventBroker<Action> EventBroker { get; }
    }
}
