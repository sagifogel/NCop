using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public class MethodEndWeaver : IMethodEndWeaver
    {
        public void Weave(MethodInfo methodInfo, ILGenerator ilGenerator) {
            ilGenerator.Emit(OpCodes.Ret);
        }
    }
}
