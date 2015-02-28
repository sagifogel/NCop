using System.Reflection;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractPropertyAdviceArgs : AbstractAdviceArgs
    {   
        public MethodInfo Method { get; set; }
    }
}
