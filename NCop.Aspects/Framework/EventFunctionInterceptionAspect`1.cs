using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public class EventFunctionInterceptionAspect<TArg1, TResult> : IEventInterceptionAspect
    {
        [OnAddEventHandlerAdvice]
        public virtual void OnAddHandler(EventFunctionInterceptionArgs<TArg1, TResult> args) { }

        [OnRemoveEventHandlerAdvice]
        public virtual void OnRemoveHandler(EventFunctionInterceptionArgs<TArg1, TResult> args) { }

        [OnInvokeEventHandlerAdvice]
        public virtual void OnInvokeHandler(EventFunctionInterceptionArgs<TArg1, TResult> args) { }
    }
}
