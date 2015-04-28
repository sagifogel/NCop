
namespace NCop.Aspects.Framework
{
    public abstract class EventActionInterceptionArgs<TArg1, TArg2> : EventActionInterceptionArgs<TArg1>
    {
        public TArg2 Arg2 { get; set; }
    }
}
