using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public class FunctionEventInterceptionAspect<TArg1, TArg2, TArg3, TArg4, TResult> : IEventInterceptionAspect
    {
        [OnAddHandlerAdvice]
        public virtual void OnAddHandler(FunctionEventInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TResult> args) { }

        [OnRemoveHandlerAdvice]
        public virtual void OnRemoveHandler(FunctionEventInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TResult> args) { }

        [OnInvokeHandlerAdvice]
        public virtual void OnInvokeHandler(FunctionEventInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TResult> args) { }
    }
}
