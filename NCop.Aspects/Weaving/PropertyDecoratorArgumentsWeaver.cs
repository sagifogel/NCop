using NCop.Aspects.Extensions;
using NCop.Core.Extensions;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
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
            var methodImplParameters = methodInfoImpl.GetParameters();
            Type aspectArgsType = methodInfoImpl.ToAspectArgumentContract();

            ilGenerator.EmitLoadArg(1);
            ilGenerator.Emit(OpCodes.Ldind_Ref);

            methodImplParameters.ForEach((param) => {
                var argPosition = param.Position + 1;
                var property = aspectArgsType.GetProperty("Arg".Fmt(argPosition));

                ilGenerator.EmitLoadArg(2);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
            });
        }
    }
}
