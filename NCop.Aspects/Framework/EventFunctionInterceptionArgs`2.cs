using System;

namespace NCop.Aspects.Framework
{
    public abstract class EventFunctionInterceptionArgs<TArg1, TArg2, TResult> : EventFunctionInterceptionArgs<TArg1, TResult>
    {
        public TArg2 Arg2 { get; set; }
    }
}
