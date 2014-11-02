using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IMethodAdviceArgs : IAdviceArgs
    {
        MethodInfo Method { get; }
    }
}
