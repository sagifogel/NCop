using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IFunctionArgs<TArg1, TArg2, TResult>
    {
        TArg1 Arg1 { get; set; }
        TArg2 Arg2 { get; set; }
        MethodInfo Method { get; set; }
        TResult ReturnValue { get; set; }
    }
}
