using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public class FunctionEventInterceptionAspect<TResult> : IEventInterceptionAspect
    {
        [OnAddHandlerAdvice]
        public virtual void OnAddHandler(FunctionEventInterceptionArgs<TResult> args) { }

        [OnRemoveHandlerAdvice]
        public virtual void OnRemoveHandler(FunctionEventInterceptionArgs<TResult> args) { }

        [OnInvokeHandlerAdvice]
        public virtual void OnInvokeHandler(FunctionEventInterceptionArgs<TResult> args) { }
    }
}
