
namespace NCop.Aspects.Framework
{
    public abstract class EventActionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5> : EventActionInterceptionArgs<TArg1, TArg2, TArg3, TArg4>
    {
        public TArg5 Arg5 { get; set; }
    }
}
