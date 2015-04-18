using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public class FunctionEventInterceptionAspect<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> : IEventInterceptionAspect
    {
        [OnAddHandlerAdvice]
        public virtual void OnAddHandler(EventFunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> args) { }

        [OnRemoveHandlerAdvice]
        public virtual void OnRemoveHandler(EventFunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> args) { }

        [OnInvokeHandlerAdvice]
        public virtual void OnInvokeHandler(EventFunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> args) { }
    }
}
