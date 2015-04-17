using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public class ActionEventInterceptionAspect<TArg1, TArg2, TArg3> : IEventInterceptionAspect
    {
        [OnAddHandlerAdvice]
        public virtual void OnAddHandler(ActionEventInterceptionArgs<TArg1, TArg2, TArg3> args) { }

        [OnRemoveHandlerAdvice]
        public virtual void OnRemoveHandler(ActionEventInterceptionArgs<TArg1, TArg2, TArg3> args) { }

        [OnInvokeHandlerAdvice]
        public virtual void OnInvokeHandler(ActionEventInterceptionArgs<TArg1, TArg2, TArg3> args) { }
    }
}
