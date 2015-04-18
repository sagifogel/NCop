using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public class EventActionInterceptionAspect<TArg1> : IEventInterceptionAspect
    {
        [OnAddHandlerAdvice]
        public virtual void OnAddHandler(EventActionInterceptionArgs<TArg1> args) { }

        [OnRemoveHandlerAdvice]
        public virtual void OnRemoveHandler(EventActionInterceptionArgs<TArg1> args) { }

        [OnInvokeHandlerAdvice]
        public virtual void OnInvokeHandler(EventActionInterceptionArgs<TArg1> args) { }
    }
}
