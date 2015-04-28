using NCop.Aspects.Engine;
using System.Reflection;

namespace NCop.Aspects.Framework
{
    public abstract class AbstractEventInterceptionArgs : AbstractAdviceArgs, IEventInterceptionAspect
    {
        public EventInfo Event { get; set; }
        public abstract void ProceedAddHandler();
        public abstract void ProceedInvokeHandler();
        public abstract void ProceedRemoveHandler();
    }
}
