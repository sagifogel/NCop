using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Framework
{
    public abstract class AbstractEventInterceptionArgs : AbstractAdviceArgs, IEventInterceptionAspect
    {
        public abstract void AddHandler();
        public EventInfo Event { get; set; }
        public Delegate Handler { get; set; }
        public abstract void RemoveHandler();
        public abstract void ProceedAddHandler();
        public abstract void ProceedInvokeHandler();
        public abstract void ProceedRemoveHandler();
    }
}
