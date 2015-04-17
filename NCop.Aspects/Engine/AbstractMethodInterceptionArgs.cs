using System;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractMethodInterceptionArgs : AbstractMethodAdviceArgs
    {
        public abstract void Proceed();
        public Exception Exception { get; set; }
    }
}
