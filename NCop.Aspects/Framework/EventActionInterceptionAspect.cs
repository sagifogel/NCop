using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public class EventActionInterceptionAspect : IEventInterceptionAspect
    {
        [OnAddEventHandlerAdvice]
        public virtual void OnAddHandler(EventActionInterceptionArgs args) { }

        [OnRemoveEventHandlerAdvice]
        public virtual void OnRemoveHandler(EventActionInterceptionArgs args) { }

        [OnInvokeEventHandlerAdvice]
        public virtual void OnInvokeHandler(EventActionInterceptionArgs args) { }
    }
}
