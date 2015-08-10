
namespace NCop.Aspects.Framework
{
    public abstract class EventFunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> : EventFunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TResult>
    {
        public TArg5 Arg5 { get; set; }
    }
}
