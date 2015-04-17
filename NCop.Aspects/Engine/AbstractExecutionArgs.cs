using NCop.Aspects.Framework;
using System;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractExecutionArgs : AbstractMethodAdviceArgs
    {
        public Exception Exception { get; set; }
        public FlowBehavior FlowBehavior { get; set; }

        protected AbstractExecutionArgs() {
            FlowBehavior = FlowBehavior.RethrowException;
        }
    }
}
