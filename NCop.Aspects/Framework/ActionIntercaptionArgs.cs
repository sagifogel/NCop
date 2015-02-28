using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
	public abstract class ActionInterceptionArgs : AbstractMethodInterceptionArgs, IActionInterceptionArgs
	{
        public abstract void Invoke();
	}
}
