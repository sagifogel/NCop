using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IActionArgs
    {
        MethodInfo Method { get; set; }
    }
}
