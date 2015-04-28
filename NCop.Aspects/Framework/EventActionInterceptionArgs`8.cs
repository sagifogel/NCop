
namespace NCop.Aspects.Framework
{
    public abstract class EventActionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> : EventActionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
    {
        public TArg8 Arg8 { get; set; }
    }
}
