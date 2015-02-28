
namespace NCop.Aspects.Framework
{
    public abstract class FunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> : FunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TResult>
	{
        public TArg5 Arg5 { get; set; }
    }
}
