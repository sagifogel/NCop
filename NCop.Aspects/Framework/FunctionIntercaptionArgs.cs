using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionInterceptionArgs<TResult> : AbstractMethodInterceptionArgs, IFunctionInterceptionArgs
	{
        public abstract void Invoke();
        public TResult ReturnValue { get; set; }
	}
}
