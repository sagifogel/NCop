using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionExecutionArgs<TResult> : AbstractExecutionArgs, IFunctionExecutionArgs
	{
		public TResult ReturnValue { get; set; }
    }
}
