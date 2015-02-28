using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public class GenericFunctionExecutionArgs : AbstractAdviceArgs, IFunctionExecutionArgs
    {
        public object ReturnType { get; protected set; }
        public Arguments Arguments { get; protected set; }
        public FlowBehavior FlowBehavior { get; protected set; }
    }
}
