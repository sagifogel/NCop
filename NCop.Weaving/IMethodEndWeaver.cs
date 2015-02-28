using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public interface IMethodEndWeaver
    {
        void Weave(MethodInfo methodInfo, ILGenerator ilGenerator);
    }
}
