
namespace NCop.Aspects.Framework
{
	public abstract class ActionInterceptionArgs<TArg1, TArg2> : ActionInterceptionArgs<TArg1>
	{
        public TArg2 Arg2 { get; set; }
	}
}
