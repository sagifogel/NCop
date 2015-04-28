
namespace NCop.Aspects.Framework
{
    public abstract class EventActionInterceptionArgs<TArg1> : EventActionInterceptionArgs
    {
        public TArg1 Arg1 { get; set; }
    }
}
