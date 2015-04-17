using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public class FunctionEventInterceptionAspect<TArg1, TResult> : IEventInterceptionAspect
    {
        [OnAddHandlerAdvice]
        public virtual void OnAddHandler(FunctionEventInterceptionArgs<TArg1, TResult> args) { }

        [OnRemoveHandlerAdvice]
        public virtual void OnRemoveHandler(FunctionEventInterceptionArgs<TArg1, TResult> args) { }

        [OnInvokeHandlerAdvice]
        public virtual void OnInvokeHandler(FunctionEventInterceptionArgs<TArg1, TResult> args) { }
    }
}
