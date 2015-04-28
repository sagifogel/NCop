
namespace NCop.Aspects.Framework
{
    public abstract class EventActionInterceptionArgs<TArg1, TArg2, TArg3> : EventActionInterceptionArgs<TArg1, TArg2>
    {
        public TArg3 Arg3 { get; set; }
    }
}
