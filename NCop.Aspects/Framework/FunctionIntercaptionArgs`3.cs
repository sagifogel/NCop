
namespace NCop.Aspects.Framework
{
	public abstract class FunctionInterceptionArgs<TArg1, TArg2, TArg3, TResult> : FunctionInterceptionArgs<TArg1, TArg2, TResult>
	{
        public TArg3 Arg3 { get; set; }
	}
}
