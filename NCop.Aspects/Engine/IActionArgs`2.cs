using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IActionArgs<TArg1, TArg2>
    {
        TArg1 Arg1 { get; set; }
        TArg2 Arg2 { get; set; }
        MethodInfo Method { get; set; }
    }
}
