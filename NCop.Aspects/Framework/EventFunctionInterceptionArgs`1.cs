using System;

namespace NCop.Aspects.Framework
{
    public abstract class EventFunctionInterceptionArgs<TArg1, TResult> : EventFunctionInterceptionArgs<TResult>
    {
        public TArg1 Arg1 { get; set; }
    }
}
