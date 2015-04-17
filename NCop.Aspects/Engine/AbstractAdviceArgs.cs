using System;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractAdviceArgs : IAdviceArgs
    {
        public object Instance { get; set; }
    }
}
