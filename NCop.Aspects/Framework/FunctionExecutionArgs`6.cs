
namespace NCop.Aspects.Framework
{
    public abstract class FunctionExecutionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> : FunctionExecutionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>
	{
        public TArg6 Arg6 { get; set; }
	}
}
