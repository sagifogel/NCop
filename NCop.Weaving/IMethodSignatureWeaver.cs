using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public interface IMethodSignatureWeaver : IWeaver
    {
        MethodBuilder Weave(MethodInfo methodInfo = null);
    }
}