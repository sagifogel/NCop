using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IFunctionArgs<TResult>
    {
        MethodInfo Method { get; set; }
        TResult ReturnValue { get; set; }
    }
}