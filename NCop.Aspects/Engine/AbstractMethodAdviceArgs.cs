using System.Reflection;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractMethodAdviceArgs : AbstractAdviceArgs
    {
        public MethodInfo Method { get; set; }
    }
}
