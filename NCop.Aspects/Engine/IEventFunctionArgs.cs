using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IEventFunctionArgs<TResult>
    {
        EventInfo Event { get; set; }
        TResult ReturnValue { get; set; }
        Func<TResult> Handler { get; set; }
        IEventBroker<Func<TResult>> EventBroker { get; }
    }
}