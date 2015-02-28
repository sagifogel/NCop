
namespace NCop.Aspects.Framework
{
    public abstract class ActionExecutionArgs<TArg1, TArg2, TArg3> : ActionExecutionArgs<TArg1, TArg2>
	{
        public TArg3 Arg3 { get; set; }
	}
}
