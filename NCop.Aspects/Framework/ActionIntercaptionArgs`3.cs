
namespace NCop.Aspects.Framework
{
	public abstract class ActionInterceptionArgs<TArg1, TArg2, TArg3> : ActionInterceptionArgs<TArg1, TArg2>
	{
        public TArg3 Arg3 { get; set; }
	}
}
