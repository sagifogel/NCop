using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public class FunctionEventInterceptionAspect<TResult> : IEventInterceptionAspect
    {
        [OnAddHandlerAdvice]
        public virtual void OnAddHandler(EventFunctionInterceptionArgs<TResult> args) { }

        [OnRemoveHandlerAdvice]
        public virtual void OnRemoveHandler(EventFunctionInterceptionArgs<TResult> args) { }

        [OnInvokeHandlerAdvice]
        public virtual void OnInvokeHandler(EventFunctionInterceptionArgs<TResult> args) { }
    }
}
