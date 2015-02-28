using NCop.Aspects.Framework;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractExecutionArgs : AbstractMethodAdviceArgs
    {
        public FlowBehavior FlowBehavior { get; set; }

        protected AbstractExecutionArgs() {
            FlowBehavior = FlowBehavior.RethrowException;
        }
    }
}
