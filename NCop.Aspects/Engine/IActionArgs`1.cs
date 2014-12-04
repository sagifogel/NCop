using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IActionArgs<TArg1>
    {
        TArg1 Arg1 { get; set; }
        MethodInfo Method { get; set; }
    }
}
