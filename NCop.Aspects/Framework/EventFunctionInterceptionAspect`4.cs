using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public class EventFunctionInterceptionAspect<TArg1, TArg2, TArg3, TArg4, TResult> : IEventInterceptionAspect
    {
        [OnAddHandlerAdvice]
        public virtual void OnAddHandler(EventFunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TResult> args) { }

        [OnRemoveHandlerAdvice]
        public virtual void OnRemoveHandler(EventFunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TResult> args) { }

        [OnInvokeHandlerAdvice]
        public virtual void OnInvokeHandler(EventFunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TResult> args) { }
    }
}
