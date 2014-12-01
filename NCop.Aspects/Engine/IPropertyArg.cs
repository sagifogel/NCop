using System.Reflection;

namespace NCop.Aspects.Engine
{
    public interface IPropertyArg<TArg>
    {
        TArg Value { get; set; }
        MethodInfo Method { get; set; }
    }
}
