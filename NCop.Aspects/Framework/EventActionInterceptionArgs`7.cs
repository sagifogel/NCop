
namespace NCop.Aspects.Framework
{
    public abstract class EventActionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> : EventActionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
    {
        public TArg7 Arg7 { get; set; }
    }
}
