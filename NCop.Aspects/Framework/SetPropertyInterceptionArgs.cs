using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
	public abstract class SetPropertyInterceptionArgs<TArg> : AbstractMethodInterceptionArgs, IFunctionInterceptionArgs
	{
		public TArg Value { get; set; }
	}
}
