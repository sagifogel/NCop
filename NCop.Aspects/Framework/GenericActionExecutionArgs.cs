using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public abstract class GenericActionExecutionArgs : AbstractAdviceArgs
	{
		public Arguments Arguments { get; set; }
    }
}
