using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public class EventFunctionInterceptionAspect<TArg1, TResult> : IEventInterceptionAspect
    {
        [OnAddHandlerAdvice]
        public virtual void OnAddHandler(EventFunctionInterceptionArgs<TArg1, TResult> args) { }

        [OnRemoveHandlerAdvice]
        public virtual void OnRemoveHandler(EventFunctionInterceptionArgs<TArg1, TResult> args) { }

        [OnInvokeHandlerAdvice]
        public virtual void OnInvokeHandler(EventFunctionInterceptionArgs<TArg1, TResult> args) { }
    }
}
