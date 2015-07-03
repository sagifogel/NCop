using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public class EventActionInterceptionAspect<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> : IEventInterceptionAspect
    {
        [OnAddEventHandlerAdvice]
        public virtual void OnAddHandler(EventActionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> args) { }

        [OnRemoveEventHandlerAdvice]
        public virtual void OnRemoveHandler(EventActionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> args) { }

        [OnInvokeEventHandlerAdvice]
        public virtual void OnInvokeHandler(EventActionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> args) { }
    }
}
