using NCop.Weaving.Extensions;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class PropertyDecoratorArgumentsWeaver : IArgumentsWeaver
    {
        private readonly MethodInfo methodInfoImpl = null;

        internal PropertyDecoratorArgumentsWeaver(MethodInfo methodInfoImpl) {
            this.methodInfoImpl = methodInfoImpl;
        }

        public void Weave(ILGenerator ilGenerator) {
            ilGenerator.EmitLoadArg(1);
            ilGenerator.Emit(OpCodes.Ldind_Ref);
        }
    }
}
