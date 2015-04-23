using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IEventFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>
    {
        TArg1 Arg1 { get; set; }
        TArg2 Arg2 { get; set; }
        TArg3 Arg3 { get; set; }
        TArg4 Arg4 { get; set; }
        TArg5 Arg5 { get; set; }
        TArg6 Arg6 { get; set; }
        EventInfo Event { get; set; }
        TResult ReturnValue { get; set; }
        Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Handler { get; set; }
        IEventBroker<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>> EventBroker { get; }
    }
}
