using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public class EventFunctionInterceptionAspect<TResult> : IEventInterceptionAspect
    {
        [OnAddEventHandlerAdvice]
        public virtual void OnAddHandler(EventFunctionInterceptionArgs<TResult> args) { }

        [OnRemoveEventHandlerAdvice]
        public virtual void OnRemoveHandler(EventFunctionInterceptionArgs<TResult> args) { }

        [OnInvokeEventHandlerAdvice]
        public virtual void OnInvokeHandler(EventFunctionInterceptionArgs<TResult> args) { }
    }
}
