using System;

namespace NCop.Aspects.Framework
{
    public abstract class EventFunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TResult> : EventFunctionInterceptionArgs<TArg1, TArg2, TArg3, TResult>
    {
        public TArg4 Arg4 { get; set; }
    }
}
