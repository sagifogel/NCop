using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public abstract class EventFunctionInterceptionArgs<TResult> : AbstractEventInterceptionArgs, IEventFunctionInterceptionArgs
    {
        public TResult ReturnValue { get; set; }
    }
}
