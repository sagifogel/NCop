using System;

namespace NCop.Aspects.Framework
{
    public abstract class EventFunctionInterceptionArgs<TArg1, TArg2, TArg3, TResult> : EventFunctionInterceptionArgs<TArg1, TArg2, TResult>
    {
        public TArg3 Arg3 { get; set; }
    }
}
